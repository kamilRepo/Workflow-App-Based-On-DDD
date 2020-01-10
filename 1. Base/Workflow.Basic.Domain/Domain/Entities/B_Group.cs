using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Group : Entity
    {
        public B_Group Group { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Preview { get; set; }

        public bool Edit { get; set; }
    }
}
