using Workflow.Base.CQRS.Commands.Attributes;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Dashboard.Domain.Services;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.DDD.Application.Metadata;

namespace Workflow.Dashboard.Application.Services
{
    [ApplicationService]
    public class MyPortalService : IMyPortalService
    {
        #region Finders



        #endregion
        #region DomainServices

        public AccessPolicyService AccessPolicyService { set; get; }

        #endregion
        #region AppServices


        #endregion
        #region Repositories



        #endregion

        #region IMyPortalService members

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.MyPortalServiceCheckAccessPolicy, "CheckingPermissions")]
        public AccessPolicyDto CheckAccessPolicy(AccessPolicyDto accessPolicyDto)
        {      
            accessPolicyDto.SetIsAccess(
                AccessPolicyService.CheckAccessInMyPortal(
                    accessPolicyDto.SystemUserId,
                    accessPolicyDto.UserReviewId
                )
            );

            accessPolicyDto.Success = true;

            return accessPolicyDto;
        }

        #endregion
    }
}
