using System;
using System.Runtime.Serialization;

namespace ServiceClient.Services
{
    [Serializable]
    public class PersonProcessException : Exception
    {
        public PersonProcessException()
        {
        }

        public PersonProcessException(string message) : base(message)
        {
        }

        public PersonProcessException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PersonProcessException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}