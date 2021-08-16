using System;

namespace DeliveryService.API.CustomException
{
    public class DeliveryException : Exception
    {
        public int StatusCode { get; set; }
        public DeliveryException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
