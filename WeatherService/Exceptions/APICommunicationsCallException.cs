using System;
using System.Runtime.Serialization;

namespace WeatherService.Exceptions
{
    public class APICommunicationsCallException : Exception
    {
        public static string DefaultFailureMessage = "Communications with Provider failed.";

        public APICommunicationsCallException() : base(DefaultFailureMessage) { }
        public APICommunicationsCallException(string message) : base(message) { }
        public APICommunicationsCallException(string message, Exception exception) : base(message, exception) { }        
    }
}

