using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.DDD.Domain.Entities
{
    public class B_UserOAuthMembership : Entity
    {
        public string Provider { set; get; }

        public string ProviderUserId { set; get; }

        public B_User User { set; get; }
    }
}
