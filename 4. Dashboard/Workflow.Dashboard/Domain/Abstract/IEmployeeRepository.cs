using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        void Save(B_Employee employee, int userId);
        void SaveAndFlush(B_Employee employee, int userId);
        B_Employee Load(int employeeId);
    }
}
