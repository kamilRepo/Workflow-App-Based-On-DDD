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
    public class B_OrganizationalCell : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
