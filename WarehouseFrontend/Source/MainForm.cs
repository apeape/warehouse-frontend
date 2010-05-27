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
        private JsonRpcProxy warehouse;
        private WarehouseObject.BytesTransferred previousXfer;

        public bool closed = false;

        public class bwChartValue
        {
            public double speed;
            public DateTime time;
        }

        private Queue<bwChartValue> dlChart = new Queue<bwChartValue>(25);
        private Queue<bwChartValue> ulChart = new Queue<bwChartValue>(25);
 
        public MainForm()
        {
            InitializeComponent();
            Win32.AllocConsole();

            Console.Title = "warehouse console";
            Console.WindowHeight = 15;

            foreach (string ft in Enum.GetNames(typeof(WarehouseObject.FilterType)))
            {
                filterType.Properties.Items.Add(ft);
                filterType.SelectedIndex = 0;
            }

            try
            {
                string url = File.ReadAllText("JsonRpcServiceUrl.txt");
                warehouse = new JsonRpcProxy(url, "ssl.pfx");

                if (warehouse == null)
                    throw new Exception("something went horribly wrong");

                new Thread(delegate() // new thread
                    {
                        warehouse.siteNames = warehouse.GetSiteNames();

                        if (warehouse.siteNames.Count > 0)
                        {
                            Console.WriteLine("got " + warehouse.siteNames.Count + " sites");

                            if (!closed)
                            {
                                this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                                {
                                    foreach (string site in warehouse.siteNames)
                                    {
                                        getSiteStatsButton.Properties.Items.Add(site);
                                        searchsite.Properties.Items.Add(site);
                                    }
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
                    }).Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
            }
        }

        private void bwtimer_Tick(object sender, EventArgs e)
        {
            new Thread(delegate() // new thread
                {
                    var xfer = warehouse.getBytesTransferred();
                    xfer.date = Util.UnixTimeStampToDateTime(xfer.timestamp);
                    if (previousXfer != null)
                    {
                        var elapsed = xfer.timestamp - previousXfer.timestamp;

                        var downloaded = xfer.downloaded - previousXfer.downloaded;
                        var uploaded = xfer.uploaded - previousXfer.uploaded;

                        var dlSpeed = (downloaded / 1024) / elapsed; // kibibytes/sec
                        var ulSpeed = (uploaded / 1024) / elapsed; // kibibytes/sec


                        dlChart.Enqueue(new bwChartValue() { speed = dlSpeed * 0.008192, time = xfer.date }); // megabits/sec
                        if (dlChart.Count > 25)
                            dlChart.Dequeue();
                        ulChart.Enqueue(new bwChartValue() { speed = ulSpeed * 0.008192, time = xfer.date }); // megabits/sec
                        if (ulChart.Count > 25)
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
                    var stats = warehouse.GetSiteStatistics(getSiteStatsButton.Text);
                    if (!closed && stats != null)
                    {
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            rlscount.Text = stats.releaseCount.ToString();
                            totalsize.Text = Util.FormatBytes(stats.totalSize);
                        });
                    }
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
                    try
                    {
                        var filters = warehouse.ListFilters();

                        foreach (var f in filters)
                            f.type = Enum.GetName(typeof(WarehouseObject.FilterType), f.release_filter_type);

                        if (!closed && filters.Count > 0)
                        {
                            this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                            {
                                filtersGridControl.DataSource = filters.ToDataTable();
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.InnerException);
                    }
                }).Start();
        }

        private List<int> getSelectedFilterIndices()
        {
            var rows = (filtersGridControl.DataSource as DataTable).Rows;
            List<int> indices = new List<int>();
            foreach (DataRow row in rows)
            {
                if ((bool)row["selected"] == true)
                {
                    var index = rows.IndexOf(row) + 1;
                    indices.Add(index);
                }
            }

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
                foreach (var sr in siteresults)
                {
                    foreach (var r in sr.results)
                    {
                        r.site = sr.site;
                        r.sizeString = Util.FormatBytes(r.size);
                    }
                }
                this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                {
                    var allresults = siteresults[0].results.ToDataTable();
                    for (int i = 1; i < siteresults.Count; i++)
                    {
                        siteresults[i].results.ToDataTable(allresults);
                    }
                    Console.WriteLine("got " + allresults.Rows.Count + " results");
                    searchResultsGridControl.DataSource = allresults;
                });

            }).Start();
        }

        private void gridViewSearch_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRowView rowView = (DataRowView)gridViewSearch.GetRow(e.RowHandle);
            //var row = (filtersGridControl.DataSource as DataTable).Rows[e.RowHandle];
            var id = rowView.Row.ItemArray[5].ToString();
            var site = rowView.Row.ItemArray[4].ToString();
            downloadbyid.Text = id;
            searchsite.SelectedIndex = searchsite.Properties.Items.IndexOf(site);
        }

        private void getTorrents(bool hideComplete)
        {
            new Thread(delegate() // new thread
            {
                try
                {
                    var torrents = warehouse.GetTorrents();

                    Console.WriteLine("got " + torrents.Count + " torrents");

                    foreach (var f in torrents)
                    {
                        f.percentDone = (f.bytesDone / f.size) * 100;
                        f.downloadSpeedKiB = f.downloadSpeed / 1024;
                        f.uploadSpeedKiB = f.uploadSpeed / 1024;
                        f.sizeString = Util.FormatBytes(f.size);
                        //f.type = Enum.GetName(typeof(WarehouseObject.FilterType), f.release_filter_type);
                    }

                    if (hideComplete)
                    {
                        Console.WriteLine("hiding " + torrents.Count(q => q.percentDone == 100) + " completed torrents");
                        torrents.RemoveAll(q => q.percentDone == 100);
                    }

                    if (!closed && torrents.Count > 0)
                    {
                        this.BeginInvoke((ThreadStart)delegate() // back to UI thread
                        {
                            torrentsGridControl.DataSource = torrents.ToDataTable();
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.InnerException);
                }
            }).Start();
        }

        private void refreshTorrents_Click(object sender, EventArgs e)
        {
            getTorrents(hidecompleted.Checked);
        }

        private void gridViewRtorrent_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            try
            {
                if (e.Column.Name == "torrentSize")
                {
                    DataRowView dr1 = (gridViewRtorrent.DataSource as DataView)[e.ListSourceRowIndex1];
                    DataRowView dr2 = (gridViewRtorrent.DataSource as DataView)[e.ListSourceRowIndex2];
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(dr1["size"],
                        dr2["size"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void gridViewSearch_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            try
            {
                if (e.Column.Name == "size")
                {
                    DataRowView dr1 = (gridViewSearch.DataSource as DataView)[e.ListSourceRowIndex1];
                    DataRowView dr2 = (gridViewSearch.DataSource as DataView)[e.ListSourceRowIndex2];
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(dr1["size"],
                        dr2["size"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void assigncategory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string category = assigncategory.Text;
            if (category == null || category.Length == 0) return;

            new Thread(delegate() // new thread
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
                }).Start();
        }

        private void hidecompleted_CheckedChanged(object sender, EventArgs e)
        {
            getTorrents(hidecompleted.Checked);
        }
    }
}
