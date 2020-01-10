using Workflow.Base.DDD.Domain;
using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Contract : Entity
    {
        public B_Employee Employee { get; set; }

        public float DimensionTime { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime DismissDate { get; set; }

        public DateTime AnnexDate { get; set; }

        public string TypeContract { get; set; }

        public float Salary { get; set; }
    }
}
