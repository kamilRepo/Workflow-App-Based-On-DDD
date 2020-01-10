using Workflow.Base.DDD.Application;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Dashboard.Domain.Abstract;
using Workflow.Dashboard.Domain.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Dashboard.Domain.Factory
{
    [DomainFactory]
    public class MyPortalAccessPolicyFactory
    {
        private ISystemUser SystemUser { set; get; }

        public void SetSystemUser(int userId)
        {
            SystemUser = new SystemUser();
            SystemUser.UserId = userId;
        }

        public IMyPortalAccessPolicy CreateMyPortalAccessPolicy()
        {
            if(SystemUser == null)
                throw new ApplicationLayerException(
                        "UnknownUserSystem", 
                        ErrorNumbers.MyPortalAccessPolicyFactoryCreateMyPortalAccessPolicy,
                        SystemUser.UserId
                    );

            IMyPortalAccessPolicy accessPolicy = new MyPortalAccessPolicy(SystemUser);

            return accessPolicy;
        }
    }
}
