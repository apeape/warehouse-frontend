using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace WarehouseFrontend
{
    public class NotificationClient
    {
        private SortedList<NotificationMessage.Type, MethodInfo> messageHandlers = new SortedList<NotificationMessage.Type, MethodInfo>();

        private IPEndPoint serverEndPoint;
        private TcpClient client;
        X509CertificateCollection clientCerts = new X509CertificateCollection();
        SslStream sslStream;

        private int rpcId;

        public const int timeout = 25000;

        // Size of receive buffer.
        public const int bufferSize = 65536;

        // Receive buffer.
        byte[] recvBuf = new byte[bufferSize];

        // Receive String
        public StringBuilder recvStringBuffer = new StringBuilder();

        // expected length of current message being received
        int msgLen;

        public NotificationClient(string server, int port, string cerFileName)
        {
            SetupMessageHandlers();

            IPAddress address = Dns.GetHostEntry(server).AddressList[0];
            serverEndPoint = new IPEndPoint(address, port);

            if (!File.Exists(cerFileName))
            {
                throw new FileNotFoundException("can't find ssl cert file '" + cerFileName + "'");
            }

            clientCerts.Add(X509Certificate.CreateFromCertFile(cerFileName));
        }

        public bool Connect()
        {
            try
            {
                client = new TcpClient(serverEndPoint.Address.ToString(), serverEndPoint.Port);
            }
            catch (SocketException e)
            {
                Console.WriteLine("failed to connect to notification server: " + e.Message);
                if (e.InnerException != null) Console.WriteLine(e.InnerException);
                return false;
            }

            sslStream = new SslStream(client.GetStream(), false,
                new RemoteCertificateValidationCallback(ValidateRemoteCertificate));

            // Set timeouts
            sslStream.ReadTimeout = timeout;
            sslStream.WriteTimeout = timeout;

            try
            {
                sslStream.AuthenticateAsClient(serverEndPoint.Address.ToString(), clientCerts,
                    SslProtocols.Tls, false);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("authenticating notification SSL client failed, "
                    + e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("inner exception: "
                        + e.InnerException.Message);
                }
                client.Close();
                return false;
            }

            Console.WriteLine("ssl connection established to notification server");

            sslStream.BeginRead(recvBuf, 0, recvBuf.Length, new AsyncCallback(Receive), this);

            return true;
        }

        public void getNewNotifications()
        {
            Invoke("getNewNotifications");
        }

        public void getNotificationCount()
        {
            Invoke("getNotificationCount");
        }

        public void getOldNotifications(int first, int last)
        {
            Invoke("getOldNotifications", first, last);
        }

        public void generateNotification(NotificationMessage.NotificationData notification)
        {
            Invoke("generateNotification", notification);
        }

        public void Send(object message)
        {
            string serializedMsg = JsonConvert.SerializeObject(message);
            byte[] buf = Encoding.UTF8.GetBytes(serializedMsg.Length + ':' + serializedMsg);
            sslStream.Write(buf);
            sslStream.Flush();
        }

        // this shit needs serious testing
        public void Receive(IAsyncResult ar)
        {
            // Read data from the remote device.
            int bytesRead = sslStream.EndRead(ar);

            if (bytesRead > 0)
            {
                recvStringBuffer.Append(Encoding.UTF8.GetString(recvBuf, 0, bytesRead));
                string buffer = recvStringBuffer.ToString();

                if (msgLen == 0 && buffer.Contains(':')) // new msg legth received
                {
                    // try to parse length
                    if (int.TryParse(buffer.Substring(0, buffer.IndexOf(':')), out msgLen))
                    {
                        buffer = buffer.Substring(buffer.IndexOf(':')); // trim length from received string
                        recvStringBuffer = new StringBuilder(buffer);
                    }
                    else // this shouldn't happen
                    {
                        Console.WriteLine("got bad msg len");
                        recvStringBuffer = new StringBuilder();
                    }
                }
                if (msgLen != 0 && recvStringBuffer.Length >= msgLen) // message completely read
                {
                    string msg = recvStringBuffer.ToString().Substring(0, msgLen);
                    recvStringBuffer.Remove(0, msgLen); // remove current message
                    msgLen = 0;

                    // handle message
                    var msgObj = JsonConvert.DeserializeObject<NotificationMessage.JsonData>(msg);

                    // find the message handler method for this message type
                    var handler = messageHandlers[(NotificationMessage.Type)msgObj.type];

                    if (handler != null)
                    {
                        Console.WriteLine("received notification message: " + Enum.GetName(typeof(NotificationMessage.Type), msgObj.type));
                        Console.WriteLine(msgObj.data);
                        // invoke it
                        handler.Invoke(this, new object[] { msgObj.data });
                    }
                }
            }

            // continue reading
            sslStream.BeginRead(recvBuf, 0, recvBuf.Length, new AsyncCallback(Receive), ar);
        }

        public void Invoke(string method, params object[] args)
        {
            JObject callData = new JObject();
            callData.Add(new JProperty("id", ++rpcId));
            callData.Add(new JProperty("method", method));
            callData.Add(new JProperty("params", args));

            NotificationMessage.JsonData call = new NotificationMessage.JsonData(NotificationMessage.Type.rpc, callData);

            Send(call);
            //JsonConvert.DeserializeObject<TResult>(Receive());
        }

        #region Handlers

        [MessageHandler(NotificationMessage.Type.error)]
        public void HandleErrorResult(string error)
        {
            Console.WriteLine("error: " + error);
        }

        [MessageHandler(NotificationMessage.Type.rpcResult)]
        public void HandleRpcResult()
        {
        }

        [MessageHandler(NotificationMessage.Type.downloaded)]
        public void HandleDownloaded(WarehouseObject.ReleaseData release)
        {
        }

        [MessageHandler(NotificationMessage.Type.downloadError)]
        public void HandleDownloadError(NotificationMessage.DownloadError downloadError)
        {
        }

        [MessageHandler(NotificationMessage.Type.downloadDeleted)]
        public void HandleDownloadDeleted(WarehouseObject.ReleaseData release)
        {
        }

        [MessageHandler(NotificationMessage.Type.serviceMessage)]
        public void HandleServiceMessage(NotificationMessage.ServiceMessage serviceMessage)
        {
        }

        [MessageHandler(NotificationMessage.Type.notification)]
        public void HandleNotification(NotificationMessage.NotificationData notification)
        {
        }

        [MessageHandler(NotificationMessage.Type.notificationCount)]
        public void HandleNotificationCount(int count)
        {
        }

        [MessageHandler(NotificationMessage.Type.newNotificationResults)]
        public void HandleNewNotificationResults(List<NotificationMessage.NotificationData> newNotifications)
        {
        }

        [MessageHandler(NotificationMessage.Type.oldNotificationResults)]
        public void HandleOldNotificationResults(List<NotificationMessage.NotificationData> oldNotifications)
        {
        }

        #endregion

        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(
        object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors policyErrors
        )
        {
            // allow any old dodgy certificate...
            return true;
        }

        public void SetupMessageHandlers()
        {
            // find all methods tagged MessageHandler
            var methods = typeof(NotificationClient).GetMethods()
                .Where(q => q.IsDefined(typeof(MessageHandlerAttribute), false));

            // store in a lookup based on operation
            foreach (var m in methods)
            {
                var type = ((MessageHandlerAttribute)Attribute
                    .GetCustomAttribute(m, typeof(MessageHandlerAttribute))).type;
                messageHandlers.Add(type, m);
            }
            Console.WriteLine(messageHandlers.Count + " message handlers loaded");
        }

        public class MessageHandlerAttribute : Attribute
        {
            public NotificationMessage.Type type { get; set; }

            public MessageHandlerAttribute(NotificationMessage.Type type)
            {
                this.type = type;
            }
        }
    }
}
