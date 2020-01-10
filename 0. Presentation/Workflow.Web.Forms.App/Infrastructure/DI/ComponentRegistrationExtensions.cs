using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Workflow.Web.Forms.App
{
    public static class ComponentRegistrationExtensions
    {
        public static BasedOnDescriptor LifestylePerSession(this BasedOnDescriptor reg)
        {
            return reg.LifestyleScoped<WebSessionScopeAccessor>();
        }
    }
}