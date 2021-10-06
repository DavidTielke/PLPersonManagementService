using System;
using System.Runtime.Serialization;

namespace ServiceClient.Services
{
    [Serializable]
    public class DataStoreException : Exception
    {
        public DataStoreException()
        {
        }

        public DataStoreException(string message) : base(message)
        {
        }

        public DataStoreException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DataStoreException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}