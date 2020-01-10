using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Dashboard.Domain.Abstract;
using Workflow.Dashboard.Domain.Factory;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Domain.Services
{
    [DomainService]
    public class AccessPolicyService
    {
        public IEmployeeMembershipFinder EmployeeMembershipFinder { set; get; }

        public MyPortalAccessPolicyFactory MyPortalAccessPolicyFactory { set; get; }

        public bool CheckAccessInMyPortal(int systemUserId, int userReviewId)
        {
            bool result = false;
            int tempId = userReviewId;
            int prevId = userReviewId;

            MyPortalAccessPolicyFactory.SetSystemUser(systemUserId);
            IMyPortalAccessPolicy accessPolicy = MyPortalAccessPolicyFactory.CreateMyPortalAccessPolicy();

            tempId = EmployeeMembershipFinder.FindDirectSupervisorId(tempId);

            if (accessPolicy.IsAccess(tempId))
                return true;

            while (!result && prevId != tempId && tempId != 0)
            {
                prevId = tempId;
                tempId = EmployeeMembershipFinder.FindDirectSupervisorId(tempId);
                result = accessPolicy.IsAccess(tempId);
            }

            return result;
        }
    }
}
