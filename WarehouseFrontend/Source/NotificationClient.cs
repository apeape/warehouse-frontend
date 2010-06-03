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

namespace WarehouseFrontend
{
    public class NotificationClient
    {
        private IPEndPoint serverEndPoint;
        private TcpClient client;
        X509CertificateCollection clientCerts = new X509CertificateCollection();
        SslStream sslStream;

        public NotificationClient(string server, int port, string cerFileName)
        {
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

            return true;
        }

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
    }
}
