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
        private string user = "dbi334041"; //User name of the database
        private string pw = "EG4DSBe1fC"; // password of the database
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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                List<OracleDataReader> result = new List<OracleDataReader>();
                    while (reader.Read())
                    {
                        result.Add(reader);
                    }
                
                return result;
            }
            catch
            {
                return null;
            }
        }
        public OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                reader.Read();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        public bool ExecuteNonQuery(OracleCommand command)
        {
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
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
                string query = "SELECT * FROM XX WHERE login = :login AND password= :password";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("login", loginName);
                command.Parameters.Add("password", Password);
                OracleDataReader dataReader = ExecuteQuery(command);
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


        #region ManagementSystem

        public bool OpenRails(out List<RailSection> railsections,out string error)
        {
            railsections = null;
            error = "";
            try
            {
                string query = "SELECT RS.POSITION, RS.STATUS, R.TNUMBER FROM RAIL R, RAILSECTION RS WHERE RS.RAIL_ID = R.ID";
                OracleCommand command = CreateOracleCommand(query);
                List<OracleDataReader> datareaders = ExecuteMultiQuery(command);
                foreach(OracleDataReader o in datareaders)
                {
                    
                    int position = (int)o["POSITION"];
                    string status = (string)o["STATUS"];
                    int railnumber = (int)o["TNUMBER"];
                    bool statusbool;
                    if(status == "Open")
                    {
                        statusbool = false;
                    }
                    else
                    {
                        statusbool = true;
                    }
                    railsections.Add(new RailSection(position, railnumber, statusbool));
                }
                return true;
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool GetTrains(out List<Train> trains,out string error)
        {

            trains = new List<Train>(); 
            error = "";
            object number = null ;
            DateTime datebuildyear;
            string model;
            try
            {
                string query = "SELECT BUILDYEAR, TMODEL, TRAMNUMBER FROM TRAM";
                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
               while (datareader.Read())
                {
                    datebuildyear = (DateTime)datareader["BUILDYEAR"];
                    model = (string)datareader["TMODEL"];
                    number = datareader["TRAMNUMBER"];
                        trains.Add(new Train(datebuildyear.Year, model, Convert.ToInt32(number))); 
                }
                return true;
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        public bool GetOneTrainInfo(int TrainNumber, out Train t, out string error)
        {
            error = "";
            t = null;
            try
            {
                string query = "SELECT * FROM TRAM WHERE ID = :TRAMNUMBER";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("TRAMNUMBER", TrainNumber);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    t = new Train((int)datareader["BUILDYEAR"], (string)datareader["TMODEL"], TrainNumber);
                }
                return true;

            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool BlockRail(RailSection rs, out bool status, out string error)
        {
             status = false;
             error = "";
             string currentstatus = "";
            try
            {
                string query = "SELECT STATUS FROM RAILSECTION WHERE RAIL_ID = :RAILNUMBER AND POSITION = :POSITION";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("RAILNUMBER", rs.RailNumber);
                command.Parameters.Add("POSITION", rs.Position);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    if(Convert.ToString(datareader["STATUS"]) == "Open")
                    {
                        currentstatus = "Open";
                        status = false;
                    }
                    else
                    {
                        currentstatus = "Blocked";
                        status = true;
                    }
                }

            }
            catch(Exception e)
            {
                error = e.ToString();
            }
            finally
            {
                conn.Close();
            }

            try
            {
                string query = "UPDATE RAILSECTION SET STATUS = ':STATUS' WHERE Rail_Id = :RAILNUMBER AND POSITION = :POSITION";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("RAILNUMBER",rs.RailNumber);
                command.Parameters.Add("POSITION",rs.Position);
                command.Parameters.Add("STATUS", currentstatus);

                int updates = command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool MoveTrain(RailSection newrs, int tramid, out string error)
        {
            error = "";
            
            try
            {
                string query = "UPDATE TRAM SET RAILSECTION_ID = :RS WHERE ID = :tramid";
                
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("RS", newrs.Position);
                command.Parameters.Add("tramid", tramid);
                int updates = command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool AnyRequests(out int tramnummer,out string error)
        {
             tramnummer = 0;
             error = "";

             try
             {
                 string query = "SELECT * FROM Requesting WHERE RAILNUMBER IS NULL";
                 OracleCommand command = CreateOracleCommand(query);
                 OracleDataReader datareader = ExecuteQuery(command);
                 while(datareader.Read())
                 {
                     if(datareader.HasRows)
                     {
                         tramnummer = (int)datareader["TRAMNUMBER"];
                     }
                 }
                 return true;
             }
            catch(Exception e)
             {
                 error = e.ToString();
                 return false;    
             }
            finally
             {
                 conn.Close();
             }
        }

        public bool CompleteRequest(int tramnumber, int railnumber, int railposition, out string error)
        {
            error = "";

            try
            {
                string query = "UPDATE REQUESTING SET Railposition = :railposition, Railnumber = :railnumber WHERE TRAMNUMBER = :tramnumber";

                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("railposition", railposition);
                command.Parameters.Add("railnumber", railnumber);
                command.Parameters.Add("tramnumber", tramnumber);
                int updates = command.ExecuteNonQuery();
                command.Dispose();
                if(updates == 1)
                {
                    return true;
                }
                else
                {
                    error = "something went wrong";
                    return false;
                }
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool GetNrOfRows(string table, string row, out int AmountOfRows, out string error)
        {
            error = "";
            AmountOfRows = -1;

            try
            {
                string query = "SELECT MAX(:row) as NVALUE FROM :table";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("row", row);
                command.Parameters.Add("table", table);
                OracleDataReader datareader = ExecuteQuery(command);
                if(datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        AmountOfRows = (int)datareader["NVALUE"];
                    }
                    return true;
                }
                else
                {
                    return false;
                }
           
                
            }
            catch(Exception e)
            {
                error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
       // public bool GetTrainLocation(int trainnumber, , out string error)
    }
}
