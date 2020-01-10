using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workflow.Web.Forms.App.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace Workflow.Web.Forms.App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
