#region License, Terms and Conditions
//
// Jayrock - A JSON-RPC implementation for the Microsoft .NET Framework
// Written by Atif Aziz (atif.aziz@skybow.com)
// Copyright (c) Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 2.1 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jelly
{
    #region Imports

    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Services.Protocols;
    using Jayrock.Json;
    using WarehouseFrontend;

    #endregion

    public class JsonRpcClient : HttpWebClientProtocol
    {
        private int _id;

        public virtual object Invoke(string method, params object[] args)
        {
            string action = method + "(" + Util.ArrayToStringGeneric(args, ", ") + ") ";
            //Console.WriteLine(action);

            return Util.RetryAction<object>(() =>
                {
                    WebRequest request = GetWebRequest(new Uri(Url));
                    request.Method = "POST";
                    request.Timeout = 45000;

                    using (Stream stream = request.GetRequestStream())
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        JsonObject call = new JsonObject();
                        call["id"] = ++_id;
                        call["method"] = method;
                        call["params"] = args;
                        call.Export(new JsonTextWriter(writer));
                    }

                    using (HttpWebResponse response = (HttpWebResponse)GetWebResponse(request))
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        JsonObject answer = new JsonObject();

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception(action + "got Bad HTTP response: " + response.StatusCode);
                        }
                        else
                        {
                            answer.Import(new JsonTextReader(reader));
                        }

                        object errorObject = answer["error"];

                        if (errorObject != null)
                            OnError(errorObject);

                        return answer["result"];
                    }
                }, action, 20, 100); // retry with delay

            throw new Exception(action + "failed, too many retries");
        }

        protected virtual void OnError(object errorObject) 
        {
            JsonObject error = errorObject as JsonObject;
                        
            if (error != null)
                throw new JsonRpcException(error["message"] as string);

            throw new JsonRpcException(errorObject as string);
        }
    }
}
