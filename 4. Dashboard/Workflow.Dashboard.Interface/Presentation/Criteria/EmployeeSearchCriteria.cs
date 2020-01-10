using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.BaseDto;

namespace Workflow.Dashboard.Interface.Presentation.Criteria
{
    public class EmployeeSearchCriteria : ApplicationActionResult
    {
        // constraints
        public int EmployeeID { get; set; }

        public int DirectSupervisorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }

        public string Section { get; set; }

        public string OrganizationalUnit { get; set; }

        public string OrganizationalCell { get; set; }

        public string Room { get; set; }

        public string EmployeeNumber { get; set; }

        // pagination support
        private int _pageNumber;
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value < 0 ? 0 : value; }
        }

        private int _itemsPerPage = 10;
        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
            set { _itemsPerPage = value < 1 ? 1 : value; }
        }

        public EmployeeSearchCriteria()
        {

        }

        public bool HasValue(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
