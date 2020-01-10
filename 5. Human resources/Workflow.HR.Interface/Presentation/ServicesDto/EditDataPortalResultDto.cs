using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Presentation.ServicesDto
{
    public class EditDataPortalResultDto : ApplicationActionResult
    {
        public int EmployeeId { get; set; }

        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public string Education { get; set; }

        public string BankAccount { get; set; }

        public string Street { get; set; }

        public string BuildingNo { get; set; }

        public string LocalNo { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }
        
        public string PostOffice { get; set; }

        public string StreetCo { get; set; }

        public string BuildingNoCo { get; set; }

        public string LocalNoCo { get; set; }

        public string PostalCodeCo { get; set; }

        public string CityCo { get; set; }

        public string PostOfficeCo { get; set; }
    }
}
