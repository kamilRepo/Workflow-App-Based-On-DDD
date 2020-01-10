using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_EmployeeMembership : Entity
    {
        public B_Employee Employee { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ?ToDate { get; set; }

        public B_OrganizationalUnit OrganizationalUnit { get; set; }

        public B_OrganizationalCell OrganizationalCell { get; set; }

        public B_Section Section { get; set; }  

        public string Position { get; set; }

        public string Room { get; set; }

        public B_Employee DirectSupervisor { get; set; } 
    }
}
