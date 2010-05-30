using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WarehouseFrontend
{
    public class JsonRpcException : Exception, ISerializable
    {
        public JsonRpcException()
        {
            // Add implementation.
        }
        public JsonRpcException(string message)
        {
            // Add implementation.
        }
        public JsonRpcException(string message, Exception inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        protected JsonRpcException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    }
}
