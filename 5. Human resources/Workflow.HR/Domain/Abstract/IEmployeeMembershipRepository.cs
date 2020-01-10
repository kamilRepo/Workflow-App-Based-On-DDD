using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Domain.Abstract
{
    public interface IEmployeeMembershipRepository
    {
        void Save(B_EmployeeMembership employeeMembership, int userId);
        void SaveAndFlush(B_EmployeeMembership employeeMembership, int userId);
        B_EmployeeMembership Load(int employeeMembershipId);
        void Delete(int employeeMembershipId, int userId);
    }
}
