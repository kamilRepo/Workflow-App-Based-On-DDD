using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;
using Workflow.Base.CQRS.Commands;
using Workflow.Permissions.Interface.Application.Handlers;
using Workflow.Permissions.Interface.Presentation.ServicesDto;

namespace Workflow.Web.Api.Infrastructure
{
    public class CustomMembershipProvider : SimpleMembershipProvider
    {
        public IGate Gate { get; set; }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
            //TODO
            //var args = new ValidatePasswordEventArgs(username, password, true);
            //OnValidatingPassword(args);

            //if (args.Cancel)
            //{
            //    status = MembershipCreateStatus.InvalidPassword;
            //    return null;
            //}

            //if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            //{
            //    status = MembershipCreateStatus.DuplicateEmail;
            //    return null;
            //}

            //var user = GetUser(username, true);

            //if (user == null)
            //{
            //    var userObj = new User { UserName = username, Password = GetMd5Hash(password), UserEmailAddress = email };

            //    using (var usersContext = new UsersContext())
            //    {
            //        usersContext.AddUser(userObj);
            //    }

            //    status = MembershipCreateStatus.Success;

            //    return GetUser(username, true);
            //}
            //status = MembershipCreateStatus.DuplicateUserName;

            //return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return base.GetUser(username, userIsOnline); 
            //TODO
            //var usersContext = new UsersContext();
            //var user = usersContext.GetUser(username);
            //if (user != null)
            //{
            //    var memUser = new MembershipUser("CustomMembershipProvider", username, user.UserId, user.UserEmailAddress,
            //                                                string.Empty, string.Empty,
            //                                                true, false, DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.MinValue,
            //                                                DateTime.Now, DateTime.Now);
            //    return memUser;
            //}
            //return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            Gate = ContainerInit._container.Resolve<IGate>();

            var loginDto = new LoginDto()
            {
                UserName = username,
                Password = password
            };

            var accountLoginCommand = new AccountLoginCommand(loginDto);
            Gate.Dispatch(accountLoginCommand);

            return accountLoginCommand.ReturnValue;
        }
    }
}
