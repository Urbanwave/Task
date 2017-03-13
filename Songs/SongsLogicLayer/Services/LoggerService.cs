using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SongsLogicLayer.Services
{
    public class LoggerService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void TryLog(string message)
        {
            logger.Info(message);
        }
    }
}
