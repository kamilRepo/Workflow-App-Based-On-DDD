using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Workflow.Web.Forms.App
{
    public class WebSessionScopeAccessor : IScopeAccessor
    {
        public void Dispose()
        {
            var scope = PerWebSessionLifestyleModule.YieldScope();
            if (scope != null)
            {
                scope.Dispose();
            }
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            return PerWebSessionLifestyleModule.GetScope();
        }
    }
}