using System;

namespace AddressService.Contracts
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
