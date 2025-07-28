using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPAssignment3.Program;

namespace OOPAssignment3.Classes
{
    internal struct Credentials
    {
        public string Password { get; set; }
        public UserRole Roles { get; set; }

        public Credentials(string password, UserRole roles)
        {
            Password = password;
            Roles = roles;
        }
    }
}
