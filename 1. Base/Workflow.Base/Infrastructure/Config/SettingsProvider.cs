using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Config
{
    public abstract class SettingsProvider
    {
        private static IBaseSettings _baseSettings;
        private static IWebSettings _webSettings;

        public static IBaseSettings BaseSettings
        {
            get { return _baseSettings; }
            set
            {
                if (_baseSettings == null)
                {
                    _baseSettings = value;
                }
            }
        }

        public static IWebSettings WebSettings
        {
            get { return _webSettings; }
            set
            {
                if (_webSettings == null)
                {
                    _webSettings = value;
                }
            }
        }

        internal static void ResetBaseSettings()
        {
            _baseSettings = null;
        }

        internal static void ResetWebSettings()
        {
            _webSettings = null;
        }
    }
}

