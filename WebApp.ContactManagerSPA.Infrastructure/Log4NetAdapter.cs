using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ContactManagerSPA.Infrastructure
{
    public class Log4NetAdapter:ILogAdapter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetAdapter));

        static Log4NetAdapter()
        {
            XmlConfigurator.Configure();
        }

        public void Log(LoggingLevel level, string message)
        {
            lock (log)
            {
                switch (level)
                {
                    case LoggingLevel.Error:
                        log.Error(message);
                        break;
                    case LoggingLevel.Warning:
                        log.Warn(message);
                        break;
                    case LoggingLevel.Debug:
                        log.Debug(message);
                        break;
                    case LoggingLevel.Fatal:
                        log.Fatal(message);
                        break;
                    default:
                        log.Info(message);
                        break;
                }
            }
        }
    }
}
