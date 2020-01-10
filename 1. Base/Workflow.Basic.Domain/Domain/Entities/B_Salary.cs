using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Salary : Entity
    {
        public B_Employee Employee { get; set; }

        public double BaseSalary { get; set; }

        public double DiscretionaryBonus { get; set; }

        public double MasterBonus { get; set; }

        public double Bonus { get; set; }

        public DateTime Date { get; set; }
    }
}
