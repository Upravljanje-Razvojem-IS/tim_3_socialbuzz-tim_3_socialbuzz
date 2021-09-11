using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Dtos
{
    public class SaveLogDto
    {
        public HttpResponseDto Response { get; set; }
        public HttpRequestDto Request { get; set; }
        public Guid UserId { get; set; }
        public RequestErrorDto Error { get; set; }
    }
}
