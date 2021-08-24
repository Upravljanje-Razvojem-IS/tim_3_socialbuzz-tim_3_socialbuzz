using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data.LoggerMocks
{
    public class LoggerMockRepository<T> : ILoggerMockRepository<T>
    {
        private readonly ILogger<T> logger;

        public LoggerMockRepository(ILogger<T> logger)
        {
            this.logger = logger;
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            logger.LogError(ex, message, args);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }
    }
}
