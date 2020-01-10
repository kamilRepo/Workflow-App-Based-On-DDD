using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_GroupEmployee : Entity
    {
        public B_Group Group { get; set; }

        public B_Employee Employee { get; set; }
    }
}
