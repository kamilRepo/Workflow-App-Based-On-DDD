using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeSalaryDto : ApplicationActionResult
    {
        public double BaseSalary { get; set; }

        public double DiscretionaryBonus { get; set; }

        public double MasterBonus { get; set; }

        public double Bonus { get; set; }

        public string EquivalentVacation { get; set; }

        public EmployeeSalaryDto() { }

        public EmployeeSalaryDto(double baseSalary, double discretionaryBonus, double masterBonus,
            double bonus, string equivalentVacation)
        {
            BaseSalary = baseSalary;
            DiscretionaryBonus = discretionaryBonus;
            MasterBonus = masterBonus;
            Bonus = bonus;
            EquivalentVacation = equivalentVacation;
        }
    }
}
