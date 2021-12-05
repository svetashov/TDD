using System;
using System.Runtime.Serialization;

namespace Tests
{
    public class CacheEmptyException : Exception
    {
        public CacheEmptyException()
        {
        }

        public CacheEmptyException(string message) : base(message)
        {
        }

        public CacheEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CacheEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}