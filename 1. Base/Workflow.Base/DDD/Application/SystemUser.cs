using Workflow.Base.Infrastructure.Attributes;

namespace Workflow.Base.DDD.Application
{
    [Component]
    public class SystemUser : ISystemUser
    {
        public int UserId
        {
            set;
            get;
        }
    }
}
