using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Inspection : Entity
    {
        public B_Employee Employee { get; set; }

        public string Entitlement { get; set; }

        public string Comments { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ?ToDate { get; set; }
    }
}
