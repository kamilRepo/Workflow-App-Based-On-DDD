using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }        

        public string EmployeeNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public string Education { get; set; }

        public byte[] Image { get; set; }

        public string OrganizationalCell { get; set; }
        
        public string Position { get; set; }

        public int DirectSupervisorID { get; set;}

        public string GridValue { get; private set; }

        public EmployeeDto() 
        {
            GridValue = "empty";
        }

        public EmployeeDto(int id, string firstName, string lastName, string employeeNumber,
            string phoneNumber, string mobileNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;            
            EmployeeNumber = employeeNumber;
            PhoneNumber = phoneNumber;
            MobilePhoneNumber = mobileNumber;
            Email = email;
            GridValue = "empty";
        }

        public EmployeeDto(string firstName, string lastName, string employeeNumber,
            string phoneNumber, string mobileNumber, string email, string pesel, string education)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeNumber = employeeNumber;
            PhoneNumber = phoneNumber;
            MobilePhoneNumber = mobileNumber;
            Email = email;
            Pesel = pesel;
            GridValue = "empty";
            Education = education;
        }

        public void SetGridValue(string value)
        {
            GridValue = value;
        }

        public string BuildGridValue()
        {
            var sb = new StringBuilder();

            sb.Append("<strong><div style=\"text-transform: uppercase\">");
            sb.Append(LastName);
            sb.Append(" ");
            sb.Append(FirstName);
            sb.Append("</div></strong>");

            sb.Append(Position);
            sb.Append("<br/><br/>");

            sb.Append(" #PhoneNumberLabel#: ");
            sb.Append(PhoneNumber);
            sb.Append(" ");
            sb.Append("<br/>");

            sb.Append(" #MobileNumberLabel#: ");
            sb.Append(MobilePhoneNumber);
            sb.Append(" ");
            sb.Append("<br/>");

            sb.Append(" #EmailLabel#: ");
            sb.Append("<label style=\"text-transform: lowercase\">");
            sb.Append(Email);
            sb.Append("</label>");

            return sb.ToString();
        }

        public string BuildGridValueTwo()
        {
            var sb = new StringBuilder();

            sb.Append("<strong><div style=\"text-transform: uppercase\">");
            sb.Append(LastName);
            sb.Append(" ");
            sb.Append(FirstName);
            sb.Append("</div></strong>");

            sb.Append(Position);
            sb.Append("<br/><br/>");

            sb.Append(" #EmployeeNumberLabel#: ");
            sb.Append(EmployeeNumber);
            sb.Append(" ");
            sb.Append("<br/>");

            sb.Append(" #EmailLabel#: ");
            sb.Append("<label style=\"text-transform: lowercase\">");
            sb.Append(Email);
            sb.Append("</label>");

            return sb.ToString();
        }
    }
}
