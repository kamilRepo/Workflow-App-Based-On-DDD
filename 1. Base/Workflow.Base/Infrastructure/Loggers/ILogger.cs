using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Loggers
{
    public interface ILogger
    {
        void LogInfo(string msg);
        void LogError(string msg, Exception ex);
        void LogDebug(string msg);
        void LogWarn(string msg);
    }
}
