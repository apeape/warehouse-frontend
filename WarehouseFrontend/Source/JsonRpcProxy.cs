using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Jayrock.Json;
using Jelly;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;

namespace WarehouseFrontend
{
    public class JsonRpcProxy
    {
        public JsonRpcClient client = new JsonRpcClient();
        public List<string> siteNames = new List<string>();

        public JsonRpcProxy(string url, string sslCertFile)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            delegate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            InstallCertificate(sslCertFile);

            client.Url = url;
            //client.ClientCertificates.Add(X509Certificate2.CreateFromCertFile(sslCertFile));
        }

        public void InstallCertificate(string cerFileName)
        {
            if (!File.Exists(cerFileName))
            {
                throw new FileNotFoundException("can't find ssl cert file '" + cerFileName + "'");
            }

            X509Certificate2 certificate = new X509Certificate2(cerFileName);

            // this fails without admin rights apparently so it can go to hell
            /*
            X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadWrite);

            if (!store.Certificates.Contains(certificate))
            {
                store.Add(certificate);
                Console.WriteLine("installed ssl certificate");
            }

            store.Close();
            */

            client.ClientCertificates.Add(certificate);
        }

        public bool TestConnection()
        {
            return (((JsonNumber)client.Invoke("sum", 2, 2)).ToInt32() == 4);
        }

        public List<string> GetSiteNames()
        {
            return JsonConvert.DeserializeObject<List<string>>(((JsonArray)client.Invoke("getSiteNames")).ToString());
        }

        public bool DownloadTorrentById(string siteName, int id)
        {
            return (bool)client.Invoke("downloadTorrentById", siteName, id);
        }

        public WarehouseObject.SiteStatistics GetSiteStatistics(string siteName)
        {
            var stats = JsonConvert.DeserializeObject<WarehouseObject.SiteStatistics>(((JsonObject)client.Invoke("getSiteStatistics", siteName)).ToString());
            return (WarehouseObject.SiteStatistics) stats;
        }

        public void AssignCategoryToFilters(string category, List<int> filterIndices)
        {
            client.Invoke("assignCategoryToFilters", category, filterIndices);
        }

        public void DeleteCategory(string category)
        {
            client.Invoke("deleteCategory", category);
        }

        public bool DownloadTorrentByName(string torrentName)
        {
            return (bool)client.Invoke("downloadTorrentByName", torrentName);
        }

        public void ConvertFilterIndices(List<int> filterIndices)
        {
            client.Invoke("convertFilterIndices", filterIndices);
        }

        public void AddFilter(string filterName, WarehouseObject.FilterType filterType)
        {
            client.Invoke("addFilter", filterName, filterType);
        }

        public void AddFilter(string filterName, string filterType)
        {
            client.Invoke("addFilter", filterName, filterType);
        }

        public List<WarehouseObject.Filter> ListFilters()
        {
            return JsonConvert.DeserializeObject<List<WarehouseObject.Filter>>(((JsonArray)(client.Invoke("listFilters"))).ToString());
        }

        public void DeleteFilters(List<int> filterIndices)
        {
            client.Invoke("deleteFilters", filterIndices.ToArray());
        }

        public void ClearFilters()
        {
            client.Invoke("clearFilters");
        }

        public long GetFreeSpace()
        {
            return ((JsonNumber)client.Invoke("getFreeSpace")).ToInt64();
        }

        public WarehouseObject.BytesTransferred getBytesTransferred()
        {
            return JsonConvert.DeserializeObject<WarehouseObject.BytesTransferred>(((JsonObject)client.Invoke("getBytesTransferred")).ToString());
        }

        public bool IsAdministrator()
        {
            return (bool)client.Invoke("isAdministrator");
        }

        public int GetReleaseSizeLimit()
        {
            return 0;
        }
        public int GetSearchResultCountMaximum()
        {
            return 0;
        }

        public List<WarehouseObject.SearchResult> Search(string regEx)
        {
            return JsonConvert.DeserializeObject<List<WarehouseObject.SearchResult>>(((JsonArray)client.Invoke("search", regEx)).ToString());
        }

        public List<WarehouseObject.TorrentStatus> GetTorrents()
        {
            return JsonConvert.DeserializeObject<List<WarehouseObject.TorrentStatus>>(((JsonArray)client.Invoke("getTorrents")).ToString());
        }
    }
}
