using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeAddressDto : ApplicationActionResult
    {
        public int Id { get; private set; }

        public string Street { get; private set; }

        public string BuildingNo { get; private set; }

        public string LocalNo { get; private set; }

        public string PostalCode { get; private set; }

        public string City { get; private set; }

        public string PostOffice { get; private set; }

        public bool IsCorrespondence { get; private set; }

        public EmployeeAddressDto(int id, string street, string buildingNo, string localNo, 
            string postalCode, string city, string postOffice, bool isCorrespondence)
        {
            Id = id;
            Street = street;
            BuildingNo = buildingNo;
            LocalNo = localNo;
            PostalCode = postalCode;
            City = city;
            PostOffice = postOffice;
            IsCorrespondence = isCorrespondence;
        }
    }
}
