using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_EmployeeMembershipCoefficients : Entity
    {
        public B_Employee Employee { get; set; }

        public B_OrganizationalUnit OrganizationalUnit { get; set; }

        public B_OrganizationalCell OrganizationalCell { get; set; }

        public B_Silo Silo { get; set; }

        public float Coefficient { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
