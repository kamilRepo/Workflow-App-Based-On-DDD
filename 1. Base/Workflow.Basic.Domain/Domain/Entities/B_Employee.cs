using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Employee : Entity
    {
        public B_User User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeeNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public string Education { get; set; }

        public Sex Sex { get; set; }

        public TypeEmployee TypeEmployee { get; set; }

        public Nullable<DateTime> Date { get; set; }
    }
}
