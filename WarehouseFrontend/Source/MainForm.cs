using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Jayrock.Json;
using Jelly;
using System.Security.Cryptography.X509Certificates;
//using Jayrock.Json.Conversion;
using System.Collections;
using Newtonsoft.Json;
using DevExpress.XtraCharts;
using System.Threading;
using System.Linq.Expressions;
using MoreLinq;
using System.IO;

namespace WarehouseFrontend
{
    public partial class MainForm : Form
    {
        private bool bwTimerLock = false;
        private JsonRpcProxy warehouse;
        private WarehouseObject.BytesTransferred previousXfer;
        private NotificationClient notificationClient;

        public bool closed = false;

        public class bwChartValue
        {
            public double speed { get; set; }
            public DateTime time { get; set; }
        }

        private Queue<bwChartValue> dlChart = new Queue<bwChartValue>();
        private Queue<bwChartValue> ulChart = new Queue<bwChartValue>();

        const string JsonRpcUrlFilename = "JsonRpcServiceUrl.txt";
        const string NotificationServiceFilename = "NotificationService.txt";
        const string sslCertFilename = "ssl.pfx";
 
        public MainForm()
        {
            InitializeComponent();
            Win32.AllocConsole();

            Console.Title = "warehouse console";
            Console.WindowHeight = 15;

            filterType.Properties.Items.AddRange(Enum.GetNames(typeof(WarehouseObject.FilterType)));
            filterType.SelectedIndex = 0;

            SafetyWrapper(() =>
            {
                string url = File.ReadAllText(JsonRpcUrlFilename);
                warehouse = new JsonRpcProxy(url, sslCertFilename);

                if (warehouse == null)
                    throw new Exception("something went horribly wrong");

                string[] notificationServer = File.ReadAllText(NotificationServiceFilename).Split(':');
                
                string notificationServerAddress = notificationServer[0];
                int notificationServerPort = Int32.Parse(notificationServer[1]);

                notificationClient = new NotificationClient(notificationServerAddress, notificationServerPort, sslCertFilename);

                new Thread(delegate() // new thread
                    {
                        SafetyWrapper(() =>
                        {
                            notificationClient.Connect();
                        });
                    }).Start();

                new Thread(delegate() // new thread
                    {
                        SafetyWrapper(() =>
                        {
                            warehouse.siteNames = warehouse.GetSiteNames();

                            if (warehouse.siteNames.Count > 0)
                            {
                                Console.WriteLine("got " + warehouse.siteNames.Count + " sites");

                                if (!closed)
                                {
                                    this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                    {
                                        getSiteStatsButton.Properties.Items.AddRange(warehouse.siteNames);
                                        searchsite.Properties.Items.AddRange(warehouse.siteNames);

                                        getSiteStatsButton.SelectedIndex = 0;
                                        searchsite.SelectedIndex = 0;
                                    });
                                }

                                var space = warehouse.GetFreeSpace();

                                if (!closed)
                                {
                                    this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                    {
                                        freespace.Text = Util.FormatBytes(space);
                                        bwtimer.Start();
                                    });
                                }

                                listFilters();

                                getTorrents(hidecompleted.Checked);
                            }
                        });
                    }).Start();
            });
        }

        private void bwtimer_Tick(object sender, EventArgs e)
        {
            if (bwTimerLock == true) return; // shitty mutex-like system to stop more than 1 update from going at a time
            bwTimerLock = true;
            new Thread(delegate() // new thread
                {
                    if (!SafetyWrapper(() =>
                        {
                            var xfer = warehouse.getBytesTransferred();
                            xfer.date = Util.UnixTimeStampToDateTime(xfer.timestamp);
                            if (previousXfer != null)
                            {
                                var elapsed = xfer.timestamp - previousXfer.timestamp;

                                var downloaded = xfer.downloaded - previousXfer.downloaded;
                                var uploaded = xfer.uploaded - previousXfer.uploaded;

                                var dlSpeed = (downloaded / Util.bytesToKibibytes) / elapsed; // kibibytes/sec
                                var ulSpeed = (uploaded / Util.bytesToKibibytes) / elapsed; // kibibytes/sec


                                dlChart.Enqueue(new bwChartValue() { speed = dlSpeed / Util.kibibytesToMegabits, time = xfer.date }); // megabits/sec
                                if (dlChart.Count > 45)
                                    dlChart.Dequeue();
                                ulChart.Enqueue(new bwChartValue() { speed = ulSpeed / Util.kibibytesToMegabits, time = xfer.date }); // megabits/sec
                                if (ulChart.Count > 45)
                                    ulChart.Dequeue();

                                if (!closed)
                                {
                                    this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                    {
                                        dlspeed.Text = String.Format("{0:0.0} KiB/s", dlSpeed);
                                        ulspeed.Text = String.Format("{0:0.0} KiB/s", ulSpeed);

                                        bwChartControl.Series["download"].DataSource = dlChart.ToDataTable();
                                        bwChartControl.Series["upload"].DataSource = ulChart.ToDataTable();

                                        // Specify data members to bind the series.
                                        bwChartControl.Series["download"].ArgumentDataMember = "time";
                                        bwChartControl.Series["download"].ValueDataMembers.AddRange(new string[] { "speed" });

                                        bwChartControl.Series["upload"].ArgumentDataMember = "time";
                                        bwChartControl.Series["upload"].ValueDataMembers.AddRange(new string[] { "speed" });                                     
                                    });
                                }
                            }
                            previousXfer = xfer;
                            bwTimerLock = false;
                        }))
                    {
                        // exception, stop the timer
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            Console.WriteLine("stopping bw update timer");
                            if (!closed) bwtimer.Stop();
                        });
                    }

                }).Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
        }

        private void getSiteStatsButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.Contains("stats"))
            {
                new Thread(delegate() // new thread
                    {
                        SafetyWrapper(() =>
                            {
                                var stats = warehouse.GetSiteStatistics(getSiteStatsButton.Text);
                                if (!closed && stats != null)
                                {
                                    this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                    {
                                        rlscount.Text = stats.releaseCount.ToString();
                                        totalsize.Text = Util.FormatBytes(stats.totalSize);
                                    });
                                }
                            });
                    }).Start();
            }
        }

        private void refreshfilters_Click(object sender, EventArgs e)
        {
            listFilters();
        }

        private void listFilters()
        {
            new Thread(delegate() // new thread
                {
                    SafetyWrapper(() =>
                        {
                            var filters = warehouse.ListFilters();
                            Console.WriteLine("got " + filters.Count + " filter(s)");

                            if (!closed && filters.Count > 0)
                            {
                                this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                {
                                    filtersGridControl.DataSource = filters;
                                });
                            }
                        });
                }).Start();
        }

        private List<int> getSelectedFilterIndices()
        {
            List<int> indices = new List<int>();

            var filters = (List<WarehouseObject.Filter>)filtersGridControl.DataSource;

            foreach (WarehouseObject.Filter filter in filters)
                if (filter.selected) indices.Add(filters.IndexOf(filter) + 1);

            return indices;
        }

        private void deletefilters_Click(object sender, EventArgs e)
        {
            List<int> indices = getSelectedFilterIndices();

            var res = MessageBox.Show("really delete " + indices.Count + " filter(s)?", "hey", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                new Thread(delegate() // new thread
                {
                    warehouse.DeleteFilters(indices);
                    listFilters();
                }).Start();
                Console.WriteLine("deleted " + indices.Count + " filter(s)");
            }
        }

        private void addfilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            new Thread(delegate() // new thread
            {
                warehouse.AddFilter(addfilter.Text, filterType.Text);
                if (!closed)
                {
                    this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                    {
                        addfilter.Text = "";
                    });
                }
                listFilters();
            }).Start();
        }

        private void downloadbyid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            new Thread(delegate() // new thread
            {
                if (e.Button.Caption.Contains("name"))
                {
                    if (warehouse.DownloadTorrentByName(downloadbyid.Text))
                    {
                        Console.WriteLine("successfully queued " + downloadbyid.Text);
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            downloadbyid.Text = "";
                        });
                    }
                    else
                        Console.WriteLine("release not found");
                }
                else
                {
                    int id;
                    if (!int.TryParse(downloadbyid.Text, out id))
                    {
                        Console.WriteLine(downloadbyid.Text + " is not an int :(");
                    }
                    else if (warehouse.DownloadTorrentById(searchsite.Text, int.Parse(downloadbyid.Text)))
                    {
                        Console.WriteLine("successfully queued " + searchsite.Text + " " + downloadbyid.Text);
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            downloadbyid.Text = "";
                        });
                    }
                    else
                        Console.WriteLine("release not found");
                    
                }
            }).Start();
        }

        private void searchButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            new Thread(delegate() // new thread
            {
                var siteresults = warehouse.Search(searchButton.Text);
                List<WarehouseObject.ReleaseData> allresults = new List<WarehouseObject.ReleaseData>();
                foreach (var sr in siteresults)
                {
                    sr.results.ForEach(r => r.site = sr.site);

                    allresults.AddRange(sr.results);
                }
                this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                {
                    Console.WriteLine("got " + allresults.Count + " results");
                    searchResultsGridControl.DataSource = allresults;
                });

            }).Start();
        }

        private void gridViewSearch_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var row = (WarehouseObject.ReleaseData)gridViewSearch.GetRow(e.RowHandle);
            downloadbyid.Text = row.id.ToString();
            searchsite.SelectedIndex = searchsite.Properties.Items.IndexOf(row.site);
        }

        private void getTorrents(bool hideComplete)
        {
            new Thread(delegate() // new thread
            {
                SafetyWrapper(() =>
                {
                    var torrents = warehouse.GetTorrents();

                    Console.WriteLine("got " + torrents.Count + " torrents");

                    if (hideComplete)
                    {
                        Console.WriteLine("hiding " + torrents.Count(q => q.percentDone == 100) + " completed torrents");
                        torrents.RemoveAll(q => q.percentDone == 100);
                    }

                    if (!closed && torrents.Count > 0)
                    {
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            torrentsGridControl.DataSource = torrents;
                        });
                    }
                });
            }).Start();
        }

        private void refreshTorrents_Click(object sender, EventArgs e)
        {
            getTorrents(hidecompleted.Checked);
        }

        private void gridViewRtorrent_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            SafetyWrapper(() =>
            {
                if (e.Column.Name == "torrentSize")
                {
                    DataRowView dr1 = (gridViewRtorrent.DataSource as DataView)[e.ListSourceRowIndex1];
                    DataRowView dr2 = (gridViewRtorrent.DataSource as DataView)[e.ListSourceRowIndex2];
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(dr1["size"],
                        dr2["size"]);
                }
            });
        }

        private void gridViewSearch_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            SafetyWrapper(() =>
            {
                if (e.Column.Name == "size")
                {
                    DataRowView dr1 = (gridViewSearch.DataSource as DataView)[e.ListSourceRowIndex1];
                    DataRowView dr2 = (gridViewSearch.DataSource as DataView)[e.ListSourceRowIndex2];
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(dr1["size"],
                        dr2["size"]);
                }
            });
        }

        private void assigncategory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string category = assigncategory.Text;
            if (category == null || category.Length == 0) return;

            new Thread(delegate() // new thread
                {
                    SafetyWrapper(() =>
                        {
                            if (e.Button.Caption.Contains("delete"))
                            {
                                warehouse.DeleteCategory(category);
                            }
                            else // assign category to selected
                            {
                                List<int> indices = getSelectedFilterIndices();
                                warehouse.AssignCategoryToFilters(category, indices);
                            }
                            listFilters();
                        });
                }).Start();
        }

        private void hidecompleted_CheckedChanged(object sender, EventArgs e)
        {
            getTorrents(hidecompleted.Checked);
        }

        private bool SafetyWrapper(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(action.Method.Name + "() failed");
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
