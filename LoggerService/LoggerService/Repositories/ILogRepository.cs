using LoggerService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerService.Repositories
{
    public interface ILogRepository
    {

        public IList<Log> GetLogsForQuery(IQueryable<Log> query);
        public IQueryable<Log> GetBasicQuery();
        public Log GetById(Guid id);
        public Log SaveLog(Log log);
    }
}
