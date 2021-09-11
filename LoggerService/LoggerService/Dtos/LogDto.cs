using System;

namespace LoggerService.Dtos
{
    public class LogDto
    {
        public Guid Id { get; set; }
        public HttpResponseDto Response { get; set; }
        public HttpRequestDto Request { get; set; }
        public UserDto User { get; set; }
        public RequestErrorDto Error { get; set; }
    }
}
