﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace WarehouseFrontend
{
    public class NotificationMessage
    {
        public enum Type
        {
            notification,
            queued,
            downloaded,
            downloadError,
            downloadDeleted,
            serviceMessage,
            rpc,
            rpcResult,
            newNotificationResults,
            oldNotificationResults,
            notificationCount,
            error,
            test,
        }

        public class NotificationData
        {
            //[JsonConverter(typeof(IsoDateTimeConverter))]
            public double time { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Type type { get; set; }
            public string content { get; set; }
        }

        public class Notification
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public Type type { get; set; }
            public NotificationData data { get; set; }

            public Notification(Type type)
            {
                this.type = type;
            }

            public Notification(Type type, NotificationData data)
            {
                this.type = type;
                this.data = data;
            }
        }

        public class DownloadError
        {
            public WarehouseObject.ReleaseData release { get; set; }
            public string message { get; set; }
        }

        public class ServiceMessage
        {
            public string severity { get; set; }
            public string message { get; set; }
        }

        public class JsonData
        {
            [JsonIgnore]
            public string error { get; set; }
            //public int id { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Type type { get; set; }
            public JObject data { get; set; }

            public JsonData(Type type)
            {
                this.type = type;
            }

            public JsonData(Type type, JObject data)
            {
                this.type = type;
                this.data = data;
            }
        }
    }
}
