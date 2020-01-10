using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Workflow.Base.CQRS.Commands;
using Workflow.Permissions.Interface.Presentation.Abstract;
using Workflow.Permissions.Interface.Presentation.FindersDto;

namespace Workflow.Web.Mvc.App.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        public IRolesFinder RolesFinder { get; set; }

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] listRoles = GetRolesForUser(username);

            return listRoles.Any(r => r == roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            RolesFinder = ContainerInit._container.Resolve<IRolesFinder>();
            IList<RoleDto> listRoles = RolesFinder.FindUserRoles(username);

            if (listRoles == null)
                return new string[] { };

            return listRoles.Select(lr => lr.RoleName).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            RolesFinder = ContainerInit._container.Resolve<IRolesFinder>();
            List<RoleDto> listRoles = RolesFinder.FindRoles();

            return listRoles.Select(r => r.RoleName).ToArray();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}