using InversionOfControl.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Entities.Implementations
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;
        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string text)
        {
            Console.WriteLine(_logger.Log(text));
        }

        public string LogMessage(string text)
        {
            return _logger.Log(text);
        }
    }
}
