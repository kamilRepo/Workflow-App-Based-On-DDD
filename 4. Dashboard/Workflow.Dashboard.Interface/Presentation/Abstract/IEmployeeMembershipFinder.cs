using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Abstract
{
    public interface IEmployeeMembershipFinder
    {
        int FindDirectSupervisorId(int id);

        int FindBranchOrganizationalCellId(int branchId, int organizationalCellId);
    }
}
