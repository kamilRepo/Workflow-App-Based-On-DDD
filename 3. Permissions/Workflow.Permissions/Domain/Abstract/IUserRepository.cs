using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Permissions.Domain.Abstract
{
    public interface IUserRepository
    {
        void Save(B_User user, int userId);
        void SaveAndFlush(B_User user, int userId);
        B_User Load(int userId);
        B_User GetUserByLogin(string login);
    }
}
