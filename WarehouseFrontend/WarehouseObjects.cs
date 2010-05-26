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
        }

        public class SearchResultData
        {
            public string name;
            public string section;
            public long size;
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime date;
            public string site;
            public int id;
            public string sizeString;
        }

        public class SearchResult
        {
            public string site;
            public List<SearchResultData> results;
        }

        public class SearchResultOld
        {
            List<SearchResultData> SceneAccess;
            List<SearchResultData> TorrentVault;
            List<SearchResultData> TorrentLeech;
        }

        public class BytesTransferred
        {
            public long Downloaded;
            public long Uploaded;
        }

        public class SiteStatistics
        {
            public long releaseCount;
            public long totalSize;
        }
    }
}
