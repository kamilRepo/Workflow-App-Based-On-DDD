using Workflow.Base.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Workflow.Base.Infrastructure.Loggers
{
    public class Logger : ILogger
    {
        #region Dependencies

        private readonly log4net.ILog _log;
        private static Logger _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        public log4net.ILog Log
        {
            get
            {
                return _log;
            }
        }

        #endregion

        #region Constructor

        private Logger()
        {
            _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        #endregion

        #region ILogger members

        public void LogInfo(string msg)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            _log.Info(string.Format("{0} {1,-22} {2,-18} - {3}", DateTime.Now.ToDateTimeStringSafe(), this.GetType().Name, sf.GetMethod().Name, msg));
        }
        public void LogError(string msg, Exception ex)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            _log.Error(string.Format("{0} {1,-22} {2,-18} - {3}", DateTime.Now.ToDateTimeStringSafe(), this.GetType().Name, sf.GetMethod().Name, msg), ex);
        }
        public void LogDebug(string msg)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            _log.Debug(string.Format("{0} {1,-22} {2,-18} - {3}", DateTime.Now.ToDateTimeStringSafe(), this.GetType().Name, sf.GetMethod().Name, msg));
        }
        public void LogWarn(string msg)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            _log.Warn(string.Format("{0} {1,-22} {2,-18} - {3}", DateTime.Now.ToDateTimeStringSafe(), this.GetType().Name, sf.GetMethod().Name, msg));
        }

        #endregion
    }
}
