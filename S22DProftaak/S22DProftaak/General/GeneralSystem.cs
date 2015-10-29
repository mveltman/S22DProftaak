using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    class GeneralSystem
    {
        public static User LoggedUser;
        private Database.DatabaseConnection db = new Database.DatabaseConnection();
        public GeneralSystem()
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string Password, out string error)
        {
            error = "";
            User tempusr = new User(UserTypeEnum.Cleaner, "Henk", "Henk", "De Boer");
            if (!db.Login(out tempusr, userName, Password)) error = "Could not login user";
            else return true;
            return false;
        }

        public User GetLoggedUser()
        {
            return LoggedUser;
        }
    }
}
