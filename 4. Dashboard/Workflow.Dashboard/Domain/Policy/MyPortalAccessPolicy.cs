using Workflow.Base.DDD.Application;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Dashboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Dashboard.Domain.Policy
{
    [DomainPolicyImplementation]
    public class MyPortalAccessPolicy : IMyPortalAccessPolicy
    {
        public ISystemUser SystemUser { private set; get; }

        public MyPortalAccessPolicy(ISystemUser systemUser)
        {
            SystemUser = systemUser;
        }

        public bool IsAccess(int userId)
        {
            return SystemUser.UserId == userId;
        }
    }
}
