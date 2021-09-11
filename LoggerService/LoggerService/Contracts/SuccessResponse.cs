using System;

namespace LoggerService.Contracts
{
    public class SuccessResponse<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
