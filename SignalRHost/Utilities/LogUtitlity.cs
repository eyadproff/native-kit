using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Utilities
{
    public class LogUtitlity
    {
        public static void LogException(ILogger _logger, Exception e) {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
        }
        
    }
}
