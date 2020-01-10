using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Basic.Domain.Domain.Entities;

namespace Workflow.HR.Domain.Abstract
{
    public interface IEmployeeMembershipCoefficientsRepository
    {
        void Save(B_EmployeeMembershipCoefficients employeeMembershipCoefficients, int userId);
        void SaveAndFlush(B_EmployeeMembershipCoefficients employeeMembershipCoefficients, int userId);
        B_EmployeeMembershipCoefficients Load(int employeeMembershipCoefficientsId);
        void Delete(int employeeMembershipCoefficientsId, int userId);
    }
}
