using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data.LoggerMocks
{
#pragma warning disable CS1591
    public interface ILoggerMockRepository<T>
    {
        public void LogError(Exception ex, string message, params object[] args);

        public void LogInformation(string message);
    }
#pragma warning restore CS1591
}
