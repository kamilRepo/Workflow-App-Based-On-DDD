using Workflow.Dashboard.Interface.Presentation.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Application.Abstract
{
    public interface IMyPortalService
    {
        AccessPolicyDto CheckAccessPolicy(AccessPolicyDto accessPolicyDto);
    }
}
