using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Domain.Abstract
{
    public interface IEmployeesAddressRepository
    {
        void Save(B_EmployeeAddress employeeAddress, int userId);
        void SaveAndFlush(B_EmployeeAddress employeeAddress, int userId);
        B_EmployeeAddress Load(int employeeAddressId);
        void Delete(int employeeAddressId, int userId);
    }
}
