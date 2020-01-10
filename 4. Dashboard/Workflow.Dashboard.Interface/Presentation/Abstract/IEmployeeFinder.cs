using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Abstract
{
    public interface IEmployeeFinder
    {
        EmployeeDto FindEmployee(int id);

        List<EmployeeDto> FindEmployees(EmployeeSearchCriteria criteria);

        EmployeeMembershipDto FindEmployeeMembership(int id);

        List<EmployeeAddressDto> FindEmployeeAdress(int id);
    }
}
