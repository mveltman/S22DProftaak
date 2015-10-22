using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace S22DProftaak.Database
{
    class DatabaseConnection
    {
        private OracleConnection conn;
        private OracleCommand command;
        private string user = ""; //User name of the database
        private string pw = ""; // password of the database
        private string dataSource = "//";

        public DatabaseConnection()
        {
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User id=" + user + ";Password=" + pw + ";Data Source=" + dataSource + ";";
        }
        public bool CoupleDB()
        {
            string user = "dbi318713"; //Dit is de gebruikersnaam
            string pw = "V7brKp3nww"; //Dit is het wachtwoord
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #region login user check
        public bool Login(out User logusr, string loginName, string Password)
        {

            User tempUsr = new User(UserTypeEnum.Cleaner, "Henk", "Henk", "De Boer");
            logusr = tempUsr;
            return true;
            throw new NotImplementedException();
            //to be implemented correctly. This is a template!!!
            try
            {
                conn.Open();
                string query = "SELECT * FROM XX WHERE login = :login AND password= :password";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("login", loginName));
                command.Parameters.Add(new OracleParameter("password", Password));
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string enumConv = Convert.ToString(dataReader["Type"]);
                    UserTypeEnum usrtype;
                    if (enumConv == "Admin") usrtype = UserTypeEnum.Admin;
                    else if (enumConv == "Cleaner") usrtype = UserTypeEnum.Cleaner;
                    else if (enumConv == "Repairsman") usrtype = UserTypeEnum.Repairsman;
                    else usrtype = UserTypeEnum.Driver;
                    string username = Convert.ToString(dataReader["Username"]),
                        fName = Convert.ToString(dataReader["firstname"]),
                        lName = Convert.ToString(dataReader["lastname"]);
                    tempUsr = new User(usrtype, username, fName, lName);
                    break;
                }
                logusr = tempUsr;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
