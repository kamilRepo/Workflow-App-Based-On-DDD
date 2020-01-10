using Workflow.Basic.Domain.Domain;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_SalaryDeductions : Entity
    {
        public B_Employee Employee { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public SalaryDeductionsType SalaryDeductionsType { get; set; }

        public double Amount { get; set; }

        public string ContractNumber { get; set; }

        public double FirstInstallmentCapital { get; set; }

        public double FirstInstallmentInterest { get; set; }

        public double MonthlyCycle { get; set; }

        public string RegistrationNumber { get; set; }
    }
}
