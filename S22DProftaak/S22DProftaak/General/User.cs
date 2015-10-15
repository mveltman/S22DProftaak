using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    /// <summary>
    /// This is the class for all users
    /// This class holds all information about the user and their permissions
    /// </summary>
    public class User
    {
        public UserTypeEnum Type { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public User(UserTypeEnum type, string userName, string firstName, string lastName)
        {
            this.Type = type;
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
        }  // sets the usertype, username, first and lastname
    }
}
