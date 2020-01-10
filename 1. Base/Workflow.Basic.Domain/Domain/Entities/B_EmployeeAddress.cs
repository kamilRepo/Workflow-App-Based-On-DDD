using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_EmployeeAddress : Entity
    {
        public B_Employee Employee { get; set; }

        public string Street { get; set; }

        public string BuildingNo { get; set; }

        public string LocalNo { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }
        
        public string PostOffice { get; set; }

        public bool IsCorrespondence { get; set; }  
    }
}
