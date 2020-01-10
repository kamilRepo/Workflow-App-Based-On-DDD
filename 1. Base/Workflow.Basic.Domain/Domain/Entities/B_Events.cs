using Workflow.Basic.Domain.Domain;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Events : AggregateRoot
    {
        public EventType EventType { get; set; }

        public int ObjectEvents { get; set; }

        public string TableName { get; set; }

        public int StateBefore { get; set; }

        public int StateAfter { get; set; }        

        public string UserIP { get; set; }
    }
}
