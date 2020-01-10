using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.DDD.Domain.Entities
{
    public class B_ApplicationError : Entity
    {
        public ErrorNumbers ErrorNumber { get; set; }

        public string Message { get; set; }

        public string MessageContent { get; set; }

        public bool IsUserError { get; set; }
    }
}
