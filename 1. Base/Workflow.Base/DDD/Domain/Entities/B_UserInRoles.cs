using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.DDD.Domain.Entities
{
    public class B_UserInRoles : Entity
    {
        public B_User User { set; get; }
        public B_Role Role { set; get; }
    }
}
