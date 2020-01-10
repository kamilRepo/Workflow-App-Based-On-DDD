using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_GroupSites : Entity
    {
        public B_Group Group { get; set; }

        public Guid Site { get; set; }

        public Guid PartPage { get; set; }
    }
}
