﻿using System;
using System.Runtime.Serialization;

namespace LruCache
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException()
        {
        }

        public KeyNotFoundException(string message) : base(message)
        {
        }

        public KeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}