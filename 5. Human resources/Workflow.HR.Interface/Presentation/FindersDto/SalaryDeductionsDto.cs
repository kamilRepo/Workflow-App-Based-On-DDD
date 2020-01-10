using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Presentation.FindersDto
{
    public class SalaryDeductionsDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string FromDateST { get; set; }

        public string ToDateST { get; set; }

        public int SalaryDeductionsType { get; set; }

        public double Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeeNumber { get; set; }

        public string LastFirstName { get; set; }

        public string ContractNumber { get; set; }

        public double FirstInstallmentCapital { get; set; }

        public double FirstInstallmentInterest { get; set; }

        public double MonthlyCycle { get; set; }

        public string RegistrationNumber { get; set; }

        public SalaryDeductionsDto() { }

        public SalaryDeductionsDto(DateTime fromDate, DateTime? toDate,
            int salaryDeductionsType, double amount, int employeeId)
        {
            FromDate = fromDate;
            ToDate = toDate;
            SalaryDeductionsType = salaryDeductionsType;
            Amount = amount;
            EmployeeId = employeeId;
        }

        public void SetFromDateST()
        {
            FromDateST = FromDate.ToShortDateString();
        }

        public void SetToDateST()
        {
            ToDateST = string.Empty;
            if (ToDate != null)
                ToDateST = ToDate.Value.ToShortDateString();
        }
    }

    [Serializable]
    public class SalaryDeductionsDtoList
    {
        public List<SalaryDeductionsDto> SDDList { get; set; }
    }
}
