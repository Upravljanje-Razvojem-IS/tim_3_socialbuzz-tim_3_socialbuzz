using LoggerService.Database;
using LoggerService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerService.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LoggerServiceDatabase _context;
        public LogRepository(LoggerServiceDatabase context)
        {
            _context = context;
        }

        public IQueryable<Log> GetBasicQuery()
        {
            return _context.LogEntries.AsQueryable();
        }

        public Log GetById(Guid id)
        {
            return _context
                .LogEntries
                .Include(l => l.User)
                .FirstOrDefault(l => l.Id.Equals(id));
        }

        public IList<Log> GetLogsForQuery(IQueryable<Log> query)
        {
            return query.ToList();
        }

        public Log SaveLog(Log log)
        {
            log = _context.Add(log).Entity;
            _context.SaveChanges();
            return log;
        }
    }
}
