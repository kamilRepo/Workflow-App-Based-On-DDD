using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.CQRS.Commands.Handler;
using Workflow.Base.Infrastructure.Utilities;
using Workflow.Permissions.Domain.Abstract;
using Workflow.Permissions.Interface.Application.Handlers;

namespace Workflow.Permissions.Application.Commands.Handlers
{
    public class AccountLoginHandler : ICommandHandler<AccountLoginCommand>
    {
        #region Finders



        #endregion
        #region DomainServices



        #endregion
        #region AppServices


        #endregion
        #region Repositories

        public IUserRepository UserRepository { get; set; }
        public IUserMembershipRepository UserMembershipRepository { get; set; }

        #endregion

        #region Handle

        public void Handle(AccountLoginCommand command)
        {
            var user = UserRepository.GetUserByLogin(command.LoginDto.UserName);
            var listUserMembership = UserMembershipRepository.GetUserMembershipForUser(user);
            string hash;
            bool result = false;

            foreach (var item in listUserMembership)
            {
                hash = string.Format("1000:{0}:{1}", item.PasswordSalt, item.Password);
                if (PasswordHash.ValidatePassword(command.LoginDto.Password, hash))
                    result = true;
            }

            command.ReturnValue = result;
            command.Success = true;
        }

        #endregion
    }
}
