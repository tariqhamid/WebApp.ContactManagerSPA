using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ContactManagerSPA.Infrastructure
{
    public interface ILogAdapter
    {
        void Log(LoggingLevel level, string message);
    }
}
