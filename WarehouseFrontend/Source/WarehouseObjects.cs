using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WarehouseFrontend
{
    public class WarehouseObject
    {
        public enum FilterType { name, nfo, genre }

        public class Filter
        {
            public string filter { get; set; }
            public string category { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public FilterType release_filter_type { get; set; }

            public bool selected { get; set; }
            public string type { get; set; }
        }

        public class SearchResultData
        {
            public string name { get; set; }
            public string section { get; set; }
            public long size { get; set; }
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime date { get; set; }
            public string site { get; set; }
            public int id { get; set; }

            public string sizeString { get { return Util.FormatBytes(size); } }
        }

        public class SearchResult
        {
            public string site { get; set; }
            public List<SearchResultData> results { get; set; }
        }

        public class BytesTransferred
        {
            public long downloaded { get; set; }
            public long uploaded { get; set; }
            //[JsonConverter(typeof(IsoDateTimeConverter))]
            public double timestamp { get; set; }
            public DateTime date { get; set; }
        }

        public class SiteStatistics
        {
            public long releaseCount { get; set; }
            public long totalSize { get; set; }
        }

        public class TorrentStatus
        {
            public string infoHash { get; set; }
            public string name { get; set; }
            public long downloadSpeed { get; set; }
            public long uploadSpeed { get; set; }
            public int fileCount { get; set; }
            public long size { get; set; }
            public long bytesDone { get; set; }

            public double percentDone { get { return Math.Round(((double)bytesDone / (double)size) * 100, 1); } }
            public string sizeString { get { return Util.FormatBytes(size); } }
            public double downloadSpeedKiB { get { return Math.Round((double)downloadSpeed / 1024, 0); } }
            public double uploadSpeedKiB { get { return Math.Round((double)uploadSpeed / 1024, 0); } }
        }
    }
}
