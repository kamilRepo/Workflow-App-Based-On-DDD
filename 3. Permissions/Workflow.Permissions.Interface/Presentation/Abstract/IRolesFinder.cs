using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Permissions.Interface.Presentation.FindersDto;

namespace Workflow.Permissions.Interface.Presentation.Abstract
{
    public interface IRolesFinder
    {
        List<RoleDto> FindRoles();
        IList<RoleDto> FindUserRoles(string userName);
    }
}
