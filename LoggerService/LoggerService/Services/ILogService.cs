using LoggerService.Dtos;
using LoggerService.Model;
using System.Collections.Generic;

namespace LoggerService.Services
{
    public interface ILogService
    {
        public LogDto SaveLog(SaveLogDto logDto);
        public IList<LogDto> GetLogs(LogParamsDto logParams);
    }
}
