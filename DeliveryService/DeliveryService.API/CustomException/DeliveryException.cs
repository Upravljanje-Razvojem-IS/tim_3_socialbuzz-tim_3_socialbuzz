using System;
using System.Runtime.Serialization;

namespace DeliveryService.API.CustomException
{
    [Serializable]
    public class DeliveryException : Exception
    {
        public int StatusCode { get; set; }
        public DeliveryException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }

        /* Code Smell S925 - implementation of serializable exception class ?
         https://stackoverflow.com/questions/60311969/sonarcube-does-not-like-my-implementation-of-serializable-exception-class/65340361#65340361 
        */
        protected DeliveryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
