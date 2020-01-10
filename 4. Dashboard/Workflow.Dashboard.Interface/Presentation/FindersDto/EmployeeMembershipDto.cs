using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeMembershipDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public string OrganizationalUnit { get; set; }

        public string ManagerBranchName { get; set; }

        public string ManagerBranchSurName { get; set; }

        public string ManagerBranchEmail{ get; set; }

        public string Section { get; set; }

        public string Room { get; set; }

        public string OrganizationalCell { get; set; }

        public string Position { get; set; }

        public EmployeeMembershipDto() { }

        public EmployeeMembershipDto(string organizationalUnit, string managerBranchName, string managerBranchSurName,
            string managerBranchEmail, string section, string room, string organizationalCell,
            string position)
        {
            OrganizationalUnit = organizationalUnit;
            ManagerBranchName = managerBranchName;
            ManagerBranchSurName = managerBranchSurName;
            ManagerBranchEmail = managerBranchEmail;
            Section = section;
            Room = room;
            OrganizationalCell = organizationalCell;
            Position = position;
        }
    }
}
