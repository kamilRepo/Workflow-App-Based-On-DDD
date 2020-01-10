using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Permissions.Domain.Abstract
{
    public interface IUserMembershipRepository
    {
        void Save(B_UserMembership userMembership, int userId);
        void SaveAndFlush(B_UserMembership userMembership, int userId);
        B_UserMembership Load(int userMembershipId);
        IList<B_UserMembership> GetUserMembershipForUser(B_User user);
    }
}
