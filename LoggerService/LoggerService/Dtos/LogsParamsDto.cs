using System;

namespace LoggerService.Dtos
{
    public class LogParamsDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid UserId { get; set; }
    }
}
