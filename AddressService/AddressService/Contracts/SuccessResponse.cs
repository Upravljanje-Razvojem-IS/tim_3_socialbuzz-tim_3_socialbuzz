using System;

namespace AddressService.Contracts
{
    public class SuccessResponse<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
