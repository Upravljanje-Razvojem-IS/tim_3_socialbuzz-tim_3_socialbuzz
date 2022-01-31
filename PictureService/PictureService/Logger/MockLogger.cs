using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Logger
{
    public class MockLogger
    {

        private readonly ILogger<MockLogger> _logger;

        public MockLogger(ILogger<MockLogger> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
