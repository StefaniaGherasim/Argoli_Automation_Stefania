﻿using System;
using System.Runtime.Serialization;

namespace Argoli_Automation_Stefania.Utilities
{
    [Serializable]
    internal class BrowserTypeException : Exception
    {
        public BrowserTypeException()
        {
        }

        public BrowserTypeException(string message) : base("unsupported browser type"  +message)
        {
            
        }

        public BrowserTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BrowserTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}