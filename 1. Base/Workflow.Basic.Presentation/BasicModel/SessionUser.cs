using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workflow.Basic.Presentation.BasicModels
{
    [Serializable]
    public class SessionUser
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public bool All { get; set; }

        public bool AuthorizedPersons { get; set; }

        public bool EditingCapabilities { get; set; }

        public bool OwnData { get; set; }


        public SessionUser(int id, string name, string surname, string email, bool all,
            bool authorizedPersons, bool editingCapabilities, bool ownData)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            All = all;
            AuthorizedPersons = authorizedPersons;
            EditingCapabilities = editingCapabilities;
            OwnData = ownData;
        }

    }
}