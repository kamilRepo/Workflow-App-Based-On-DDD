using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.ServicesDto
{
    public class AccessPolicyDto : ApplicationActionResult
    {
        public int SystemUserId { get; set; }

        public int UserReviewId { get; set; }

        public bool IsAccess { get; set; }

        public AccessPolicyDto() { }

        public AccessPolicyDto(int systemUserId, int userReviewId)
        {
            SystemUserId = systemUserId;
            UserReviewId = userReviewId;
        }

        public void SetIsAccess(bool value)
        {
            IsAccess = value;
        }
    }
}
