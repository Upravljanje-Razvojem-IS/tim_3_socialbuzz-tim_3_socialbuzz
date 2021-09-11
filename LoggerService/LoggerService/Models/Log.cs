using System;

namespace LoggerService.Model
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public HttpResponse Response{ get; set; }
        public HttpRequest Request { get; set; }
        public User User{ get; set; }
        public RequestError Error { get; set; }

    }
}
