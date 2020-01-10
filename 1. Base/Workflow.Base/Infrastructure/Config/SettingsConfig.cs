using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsProvider = Workflow.Base.Infrastructure.Config.SettingsProvider;

namespace Workflow.Base.Infrastructure.Config
{
    [ExcludeFromCodeCoverage]
    public static class SettingsConfig
    {
        public static Settings ConfigureSettings()
        {
            var settings = (Settings)ConfigurationManager.GetSection("settings");
            SettingsProvider.BaseSettings = settings;
            SettingsProvider.WebSettings = settings;

            return settings;
        }
    }
}
