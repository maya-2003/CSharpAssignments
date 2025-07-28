using OOPAssignment3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPAssignment3.Program;

namespace OOPAssignment3.Classes
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        private Dictionary<string, Credentials> usersData = new()
    {
        { "maya", new Credentials("maya10", UserRole.Admin | UserRole.User) },
        { "hana",  new Credentials("hana20", UserRole.User) },
        { "mai",  new Credentials("mai50", UserRole.Manager | UserRole.User) }
    };

        public void AddUser(string username, string password, UserRole roles)
        {
            if (usersData.ContainsKey(username))
            {
                Console.WriteLine("Username already exists");
                return;
            }

            usersData[username] = new Credentials(password, roles);
            Console.WriteLine("User data added successfully");
        }


        public bool AuthenticateUser(string username, string password)
        {
            if (usersData.TryGetValue(username, out var credentials))
            {
                return credentials.Password == password;
            }
            return false;
        }

        public bool AuthorizeUser(string username, UserRole requiredRole)
        {
            if (usersData.TryGetValue(username, out var credentials))
            {
                return (credentials.Roles & requiredRole) == requiredRole;
            }
            return false;
        }
    }
}
