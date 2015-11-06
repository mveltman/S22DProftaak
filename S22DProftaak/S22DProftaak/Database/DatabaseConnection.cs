using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace S22DProftaak.Database
{
    class DatabaseConnection
    {
        private OracleConnection conn;
        private OracleCommand command;
        private string user = ""; //User name of the database
        private string pw = ""; // password of the database
        private string dataSource = "//192.168.15.50:1521/fhictora";

        // boa constructor
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
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + dataSource + ";";
            try
            {
                conn.Open();
                return true;
            }
            catch { return false; }
            finally { conn.Close(); }
        }
        public OracleCommand CreateOracleCommand(string sql)
        {

            OracleCommand command = new OracleCommand(sql, this.conn);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }
        public List<OracleDataReader> ExecuteMultiQuery(OracleCommand command)
        {
            try
            {
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                List<OracleDataReader> result = new List<OracleDataReader>();
                while (reader.Read()) result.Add(reader);
                return result;
            }
            catch { return null; }
        }
        public OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                return reader;
            }
            catch { return null; }
        }
        public bool ExecuteNonQuery(OracleCommand command)
        {
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
        }

        #region login user check
        public bool Login(out User logusr, string loginName, string Password, out string error)
        {

            User tempUsr = new User(UserTypeEnum.Cleaner, "Henk", "Henk", "De Boer");
            logusr = tempUsr;
            error = "";
            try
            {
                string query = "SELECT per.PERMISSION, us.USERNAME, us.FIRSTNAME, us.LASTNAME " +
                    "FROM TUSER us INNER JOIN TUSER_PERMISSION usper "+
                    "ON us.USERNAME = usper.TUSER_USERNAME " +
                    "INNER JOIN PERMISSION per ON per.ID = usper.PERMISSION_ID " +
                    "WHERE us.USERNAME = :login AND us.TPASSWORD = :password";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("login", loginName);
                command.Parameters.Add("password", Password);
                OracleDataReader dataReader = ExecuteQuery(command);
                while (dataReader.Read())
                {
                    string enumConv = Convert.ToString(dataReader["PERMISSION"]);
                    UserTypeEnum usrtype;

                    if (enumConv == "Administrator") usrtype = UserTypeEnum.Admin;
                    else if (enumConv == "Cleaner") usrtype = UserTypeEnum.Cleaner;
                    else if (enumConv == "Mechanic") usrtype = UserTypeEnum.Repairsman;
                    else usrtype = UserTypeEnum.Driver;

                    string username = Convert.ToString(dataReader["USERNAME"]),
                        fName = Convert.ToString(dataReader["FIRSTNAME"]),
                        lName = Convert.ToString(dataReader["LASTNAME"]);
                    tempUsr = new User(usrtype, username, fName, lName);
                }
                logusr = tempUsr;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
            finally { conn.Close(); }
        }
        #endregion

        #region EntranceExit

        public bool EnterTrain(Train train, RailSection railsection, out string error)
        {
            error = "";

            return false;
        }
        public bool MoveTrain(Train train, User usr, out string error)
        {
            error = "";

            try
            {
                string query = "INSERT INTO TIMETABLE(ID, TRAM_ID, TUSER_USERNAME, TIME)" +
                    "VALUES(0, :tramID, :usrnam, :time)";//"UPDATE TABLE TIMETABLE SET TIME = :time WHERE TRAM_ID = :tramID AND TIME IS NULL;";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("tramid", train.TramNumber);
                command.Parameters.Add("usrnam", train.TramNumber);
                command.Parameters.Add("time", DateTime.Now);
                command.ExecuteNonQuery();

                query = "UPDATE TABLE TRAM SET RAILSECTION_ID = (SELECT railposition FROM REQUESTING WHERE TRAMNUMBER= :tramID) WHERE ID = :tramID ;";
                command = CreateOracleCommand(query);
                command.Parameters.Add("railsect", train.TramNumber);

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetRails(out List<Rail> rails, out string error)
        {
            error = "Not implemented";
            rails = new List<Rail>();
            return false;
            
        }
        #endregion
        public bool GetTrains(out List<Train> trains, out string error)
        {
            trains = null;
            error = "";
            try
            {
                string query = "SELECT BUILDYEAR, TMODEL, TRAMNUMBER FROM TRAM";
                OracleCommand command = CreateOracleCommand(query);
                List<OracleDataReader> datareaders = ExecuteMultiQuery(command);
                foreach (OracleDataReader o in datareaders)
                {
                    int buildyear = (int)o["BUILDYEAR"];
                    string model = (string)o["TMODEL"];
                    int number = (int)o["TRAMNUMBER"];

                    trains.Add(new Train(buildyear, model, number));
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool AddRequest(Train train, out string error)
        {
            error = "";
            try
            {
                string query = "INSERT INTO REQUEST(RAILPOSITION, RAILNUMBER, TRAMNUMBER) VALUES( null, null, :trainID)";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("trainID", train.TramNumber);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally { conn.Close(); }
        }
        public bool RemoveRequest(Train train, out string error)
        {
            error = "";
            try
            {
                string query;
                query = "DELETE FROM REQUEST WHERE TRAMNUMBER = :tramnum";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("tramnum", train.TramNumber);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally { conn.Close(); }
        }
    }
}