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


            string user = "dbi334041"; //Dit is de gebruikersnaam
            string pw = "EG4DSBe1fC"; //Dit is het wachtwoord
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
                // reader.Read();
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
                    "FROM TUSER us INNER JOIN TUSER_PERMISSION usper " +
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

        public bool AddRequest(Train train, out string error)
        {
            error = "";
            try
            {
                string query = "INSERT INTO REQUESTING(TRAMNUMBER) VALUES(:trainID)";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("trainID", train.TramNumber);
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
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
        public bool GetRequest(Train Tram, out RailSection railsect, out string error)
        {
            railsect = null;
            error = "";
            int test1 = -1;
            int test2 = -1;
            int railsectiont;
            int railnumbert;
            bool test = false;
            try
            {
                string query = "SELECT RAILPOSITION, RAILNUMBER, TRAMNUMBER FROM Requesting";
                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    if (datareader["RAILPOSITION"] != System.DBNull.Value)
                    {
                        test1 = Convert.ToInt32(datareader["RAILPOSITION"]);
                        railsectiont = test1;
                    }
                    if (datareader["RAILNUMBER"] != System.DBNull.Value)
                    {
                        test2 = Convert.ToInt32(datareader["RAILNUMBER"]);
                        railnumbert = test2;
                    }

                    if (test1 < 0 && test2 < 0)
                        return false;
                    else
                        railsectiont = test1;
                    railnumbert = test2;
                    railsect = new RailSection(railsectiont, railnumbert, test);

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



        #endregion
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
        //public bool GetTrains(out List<Train> trains, out string error)
        //{
        //    trains = null;
        //    error = "";
        //    try
        //    {
        //        string query = "SELECT BUILDYEAR, TMODEL, TRAMNUMBER FROM TRAM";
        //        OracleCommand command = CreateOracleCommand(query);
        //        List<OracleDataReader> datareaders = ExecuteMultiQuery(command);
        //        foreach (OracleDataReader o in datareaders)
        //        {
        //            int buildyear = (int)o["BUILDYEAR"];
        //            string model = (string)o["TMODEL"];
        //            int number = (int)o["TRAMNUMBER"];

        //            trains.Add(new Train(buildyear, model, number));
        //        }
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.ToString();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //}


        #region ManagementSystem

        public bool OpenRails(out List<RailSection> railsections, out string error)
        {
            railsections = null;
            error = "";
            try
            {
                string query = "SELECT RS.POSITION, RS.STATUS, R.TNUMBER FROM RAIL R, RAILSECTION RS WHERE RS.RAIL_ID = R.ID";
                OracleCommand command = CreateOracleCommand(query);
                List<OracleDataReader> datareaders = ExecuteMultiQuery(command);
                foreach (OracleDataReader o in datareaders)
                {

                    int position = (int)o["POSITION"];
                    string status = (string)o["STATUS"];
                    int railnumber = (int)o["TNUMBER"];
                    bool statusbool;
                    if (status == "Open")
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

        public bool GetTrains(out List<Train> trains, out string error)
        {

            trains = new List<Train>();
            error = "";
            object number = null;
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
        public bool GetOneTrainInfo(int TrainNumber, out Train t, out string error)
        {
            error = "";
            t = null;
            DateTime buildyear;
            try
            {
                string query = "SELECT * FROM TRAM WHERE TRAMNUMBER = :TRAMNUMBER";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("TRAMNUMBER", TrainNumber);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    buildyear = (DateTime)datareader["BUILDYEAR"];
                    t = new Train(buildyear.Year, (string)datareader["TMODEL"], TrainNumber);
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
                while (datareader.Read())
                {
                    if (Convert.ToString(datareader["STATUS"]) == "Open")
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
            catch (Exception e)
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
                command.Parameters.Add("RAILNUMBER", rs.RailNumber);
                command.Parameters.Add("POSITION", rs.Position);
                command.Parameters.Add("STATUS", currentstatus);

                int updates = command.ExecuteNonQuery();
                command.Dispose();
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

        public bool AnyRequests(out int tramnummer, out string error)
        {
            tramnummer = 0;
            error = "";

            try
            {
                string query = "SELECT * FROM Requesting WHERE RAILNUMBER IS NULL";
                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    if (datareader.HasRows)
                    {
                        tramnummer = (int)datareader["TRAMNUMBER"];
                    }
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
                if (updates == 1)
                {
                    return true;
                }
                else
                {
                    error = "something went wrong";
                    return false;
                }
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
                if (datareader.HasRows)
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
        #endregion

        // public bool GetTrainLocation(int trainnumber, , out string error)


        #region action
        public bool GetActions(string status, out List<Action.Action> act)
        {
            act = null;
            string error = "";


            try
            {
                string query = "Select * from action a,tram t where a.Tram_id = t.id and EndTime is null and TType = ':action'";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("action", status);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    string desc = (string)datareader["TASK"];
                    int id = (int)datareader["ID"];
                    int buildYear = (int)datareader["buildyear"];
                    string model = (string)datareader["tmodel"];
                    int tramNumber = (int)datareader["TramNumber"];
                    if (status == "Repair")
                    {

                        act.Add(new Action.Repair(desc, id, new Train(buildYear, model, tramNumber)));
                    }
                    else if (status == "Clean")
                    {
                        // act.Add(new Action.Clean(desc,id));
                    }

                }

            }
            catch (Exception e)
            {
                error = "Something went wrong";

            }
            finally
            {
                conn.Close();
            }



            return true;
        }

        //public bool    GetActionsInProgress(string status, out List<Action.Action> act)
        //{
        //   string error = "";
        //    act = null;
        //    try
        //    {
        //        string query = "select * from actionwhere a.Tram_ID = t.ID and TType = ':status' and status = 'Finished' and EndTime is null ";
        //        OracleCommand com = CreateOracleCommand(query);
        //        com.Parameters.Add("status", status);
        //        List<OracleDataReader> list = ExecuteMultiQuery(com);
        //        foreach (OracleDataReader item in list)
        //        {
        //            DateTime time = (DateTime)item["StartTime"];
        //            int id = (int)item["ID"];
        //            string desc = (string)item["Task"];
        //            DateTime time2 = (DateTime)item["EstematedEndTime"]; 
        //            int buildYear = (int)item["buildyear"];
        //            string model = (string)item["tmodel"];
        //            int tramNumber = (int)item["TramNumber"];
        //             if(status == "Repair")
        //                    {

        //                    act.Add(new Action.Repair(desc,time,id,time2,new Train(buildYear,model,tramNumber)));
        //                    }
        //                    else if (status == "Clean")
        //                    {
        //                       // act.Add(new Action.Clean(desc,id));
        //                    }

        //        }


        //    }
        //    catch(Exception e)
        //    {
        //        error = "Something went wrong";
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return true;
        //}
        public bool GetAllUsers(string status, out List<User> usr)
        {
            string error = "";
            usr = null;
            try
            {
                string query = "select * from user where ";// uhm query 
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("status", status);
                List<OracleDataReader> list = ExecuteMultiQuery(com);
                foreach (OracleDataReader item in list)
                {
                    string userName = (string)item["Username"];
                    string firstName = (string)item["FirstName"];
                    string lastName = (string)item["LastName"];
                    usr.Add(new User(UserTypeEnum.Repairsman, userName, firstName, lastName));


                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool ChangeAction(Action.Action act)
        {
            string error = "update tram set Task = ':task' , EstimatedEndTime = ':estimatedEndTime' where ID = ':id'";
            try
            {
                string query = "";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", act.ID);
                com.Parameters.Add("task", act.Note);
                com.Parameters.Add("estematedEndTime", act.EstimatedDateEnd);
                ExecuteNonQuery(com);
                com.Dispose();
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool ActivateAction(List<General.User> usr, Action.Action act)
        {
            string error = "";
            try
            {
                foreach (User item in usr)
                {
                    string query = "insert into TUser_Action(TUser_Username, Action_id) values(':UserId', ':ActionId')";
                    OracleCommand com = CreateOracleCommand(query);
                    com.Parameters.Add("UserId", item.UserName);
                    com.Parameters.Add("ActionId", act.ID);
                    ExecuteNonQuery(com);
                    com.Dispose();

                }
                string query2 = "update action set EstimatedEndTime = 'estimatedEndTime' , Task = ':note', StartTime = 'Time' where id = ':id'";
                OracleCommand com2 = CreateOracleCommand(query2);
                com2.Parameters.Add("estimatedEndTime", act.EstimatedDateEnd);
                com2.Parameters.Add("note", act.Note);
                com2.Parameters.Add("Time", act.DateStart);
                com2.Parameters.Add("id", act.ID);
                ExecuteNonQuery(com2);
                com2.Dispose();


            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool CreateAction(Action.Action act)
        {
            //string error = "";
            try
            {
                string type;
                if (act is Action.Repair)
                {
                    type = "Repair";

                }
                else
                {
                    type = "Clean";
                }
                int Id = 0;
                string errors = "";

                string query = "insert into action(id, Task,TType) values(':id',':note','type')";
                if (!GetNrOfRows("action", "id", out Id, out errors))
                {
                    OracleCommand com = CreateOracleCommand(query);
                    com.Parameters.Add("id", Id);
                    com.Parameters.Add("note", act.Note);
                    com.Parameters.Add("type", type);
                    ExecuteNonQuery(com);
                    com.Dispose();
                }




            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool CreateAction(Action.Action act, out string error)
        {
            error = "";
            try
            {
                string type;
                if (act is Action.Repair)
                {
                    type = "Repair";
                }
                else
                {
                    type = "Clean";
                }
                int Id = 0;
                string errors = "";
                string query = "insert into action(id, Task,TType) values(':id',':note','type')";
                if (!GetNrOfRows("action", "id", out Id, out errors))
                {
                    OracleCommand com = CreateOracleCommand(query);
                    com.Parameters.Add("id", Id);
                    com.Parameters.Add("note", act.Note);
                    com.Parameters.Add("type", type);
                    ExecuteNonQuery(com);
                    com.Dispose();
                }
            }
            catch (Exception)
            {
                error = "An error occured. Updating the database has failed.";
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public bool GetUserActions(General.User usr, out List<Action.Action> act, out string error)
        {
            error = "";
            act = null;
            try
            {
                string query = "Take the action and tram for this user";
                OracleCommand com = CreateOracleCommand(query);
                List<OracleDataReader> list = ExecuteMultiQuery(com);
                foreach (OracleDataReader item in list)
                {
                    string note = (string)item["Task"];
                    DateTime estimatedDateEnd = (DateTime)item["estematedDateEnd"];
                    DateTime dateStart = (DateTime)item["StartTime"];
                    int Id = (int)item["ID"];
                    int buildYear = (int)item["buildyear"];
                    string model = (string)item["tmodel"];
                    int tramNumber = (int)item["TramNumber"];
                    act.Add(new Action.Repair(note, dateStart, Id, estimatedDateEnd, new Train(buildYear, model, tramNumber)));
                }
                com.Dispose();
            }
            catch (Exception)
            {
                error = "This query doesn't exist. To be implemented.?";
                return false;
            }
            finally {  conn.Close(); }
            user = null;
            return true;
        }

        public bool FinishAction(Action.Action act)
        {
            try
            {
                string query = "update tram set DateEnd = ':end' where id = ':id'";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", act.ID);
                com.Parameters.Add("end", act.DateEnd);
                ExecuteNonQuery(com);
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool GetTram(out Train tram, int number)
        {
            tram = null;
            try
            {

                string query = "select * from tram where tramnumber = ':id'";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", number);

                OracleDataReader value = ExecuteQuery(com);
                int buildYear = (int)value["buildyear"];
                string model = (string)value["tmodel"];
                int tramNumber = (int)value["TramNumber"];
                tram = new Train(buildYear, model, tramNumber);
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetTram(out Train tram, int number, out string error)
        {
            tram = null;
            error = "";
            try
            {

                string query = "select * from tram where tramnumber = ':id'";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", number);

                OracleDataReader value = ExecuteQuery(com);
                int buildYear = (int)value["buildyear"];
                string model = (string)value["tmodel"];
                int tramNumber = (int)value["TramNumber"];
                tram = new Train(buildYear, model, tramNumber);
                return true;

            }
            catch
            {
                error = "Either the database was disconected or the query did not return an answer.";
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


        public bool HasArrived(Train _currentTram, out string _error)
        {
            
            _error = "";
            try
            {
                string query = "update REQUESTING SET ARRIVED = 1 WHERE TRAMNUMBER = :TRAMNUMBER";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("TRAMNUMBER", _currentTram.TramNumber);
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                com.ExecuteNonQuery();
                
                
                return true;
                
              
            }
             catch (Exception e)
            {
                _error = e.ToString();
                return false;
            }
            finally
            {
                this.conn.Close();
            }

        }
    }
}

