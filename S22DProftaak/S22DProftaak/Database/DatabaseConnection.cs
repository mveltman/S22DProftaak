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

        public bool PlaceTrain(int trainnumber, int railnumber, int railposition, out string error)
        {
            if(ValidateRailNr(railnumber, out error) || ValidateSector(railposition, railnumber, out error))
            {
               
            int railsectionid = -1;
            error = "";
            try
            {
                string query  = "SELECT rs.ID FROM RAILSECTION rs, RAIL r WHERE rs.RAIL_ID = r.ID AND r.TNUMBER = :railnumber AND rs.POSITION = :railposition";

                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("railnumber", railnumber);
                command.Parameters.Add("railposition", railposition);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    railsectionid = Convert.ToInt32(datareader["ID"]);
                }

                query = "UPDATE TRAM SET RAILSECTION_ID = :railsectionid WHERE TRAMNUMBER = :tramnumber";
                command = CreateOracleCommand(query);
                command.Parameters.Add("railsectionid", railsectionid);
                command.Parameters.Add("tramnumber", trainnumber);
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
            else
            {
                error = "er ging iets fout met de rail of/en railpositie";
                return false;
            }
        }
        public bool ValidateRailNr(int railnr, out string error)
        {
            error = "";
            try
            {
                string query = "SELECT TNUMBER FROM RAIL WHERE TNUMBER = :railnr";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("railnr", railnr);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                error = "spoornummer bestaat niet.";
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ValidateSector(int railposition, int railnr, out string error)
        {
            error = "";
            try
            {
                string query = "SELECT POSITION FROM RAILSECTION rs, RAIL r WHERE r.ID = rs.RAIL_ID AND r.TNUMBER = :railnr AND rs.POSITION = :railposition";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("railnr", railnr);
                command.Parameters.Add("railposition", railposition);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                error = "sectornummer bestaat niet.";
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
                string query = "SELECT rs.STATUS FROM RAILSECTION rs, RAIL r WHERE rs.RAIL_ID = r.ID AND r.TNUMBER = :RAILNUMBER AND rs.POSITION = :POSITION";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("RAILNUMBER", rs.RailNumber);
                command.Parameters.Add("POSITION", rs.Position);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    if (Convert.ToString(datareader["STATUS"]) == "Open")
                    {
                        currentstatus = "Blocked";
                        status = false;
                    }
                    else
                    {
                        currentstatus = "Open";
                        status = true;
                    }
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

            try
            {
                
                string query = "UPDATE RAILSECTION SET STATUS = :STATUS WHERE Rail_Id = (select id from rail where tnumber = :railnumber) AND POSITION = :POSITION";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("STATUS", currentstatus);
                command.Parameters.Add("RAILNUMBER", rs.RailNumber);
                command.Parameters.Add("POSITION", rs.Position);
                conn.Open();
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
        public bool CheckArrived(int tramnumber, out string error)
        {
            error = "";
            try
            {
                string query = "SELECT ARRIVED FROM REQUESTING WHERE ARRIVED = 1 AND TRAINNUMBER = :trainnumber";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("trainnumber", tramnumber);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    return true;
                }
                return false;
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
                conn.Open();
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
                    AmountOfRows = 0;
                    return true;
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

        public bool GetTrainLocation(int trainnumber, out int railnumber, out int railposition , out string error)
        {
            railnumber = -1;
            railposition = -1;
            error = "";
            try
            {
                string query = "SELECT rs.POSITION, r.TNUMBER FROM RAILSECTION RS, RAIL R, TRAM T WHERE RS.RAIL_ID = R.ID AND T.RAILSECTION_ID = RS.ID AND T.TRAMNUMBER = :tramnumber";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("tramnumber", trainnumber);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    railnumber = Convert.ToInt32(datareader["TNUMBER"]);
                    railposition = Convert.ToInt32(datareader["POSITION"]);
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


        public bool CheckForRequests(out int trainnumber,out string _error)
        {
            trainnumber = -1;
            _error = "";
            
            try
            {
                string query = "SELECT TRAMNUMBER FROM REQUESTING WHERE RAILNUMBER IS null";

                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
                while(datareader.Read())
                {
                    trainnumber = Convert.ToInt32(datareader["TRAMNUMBER"]);
                }
                return true;
            }
            catch(Exception e)
            {
                _error = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool RemoveTrainRailSection(int tramnummer, out string error)
        {
            error = "";
            try
            {

                string query = "UPDATE TRAM SET RAILSECTION_ID = NULL WHERE TRAM.TRAMNUMBER = :TRAMNUMBER";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("TRAMNUMBER", tramnummer);
                ExecuteNonQuery(com);
                com.Dispose();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;

            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool CheckRailStatus(int Railnumber, int Railposition,  out bool status, out string _error)
        {
            status = false;
            _error = "";
             try
             {

                
         
                 
                     string query = "SELECT rs.STATUS FROM RAILSECTION rs, RAIL r WHERE rs.RAIL_ID = r.ID AND r.TNUMBER = :RAILNUMBER AND rs.POSITION = :POSITION";
                     OracleCommand command = CreateOracleCommand(query);
                     command.Parameters.Add("RAILNUMBER", Railnumber);
                     command.Parameters.Add("POSITION", Railposition);
                     OracleDataReader datareader = ExecuteQuery(command);
                     while (datareader.Read())
                     {
                         if (Convert.ToString(datareader["STATUS"]) == "Open")
                         {
                             status = false;
                         }
                         else
                         {
                             status = true;
                         }
                     }

                     return true;
             }
            catch(Exception e)
             {
                 _error = e.ToString();
                 return false;
             }
            finally
             {
                 conn.Close();
             }
        }
        public bool GetRailInfo(int railnr, out List<string> infoStr, out string error)
        {
            error = "";
            infoStr = new List<string>();
            try
            {
                // The query to get the position of each railsection and its status. And in case it has one, the train on it.
                string query = "SELECT rs.POSITION, rs.STATUS, rs.ID FROM RAILSECTION rs " +
                 "WHERE RAIL_ID = ( SELECT ID FROM RAIL WHERE TNUMBER = :railnr ) ORDER BY POSITION ASC";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("railnr", railnr);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    string pos = Convert.ToString(datareader["POSITION"]),
                      stats = Convert.ToString(datareader["STATUS"]);
                    int rsid = Convert.ToInt32(datareader["ID"]);

                    string query2 = "SELECT TRAMNUMBER FROM TRAM WHERE RAILSECTION_ID = :rsid";
                    OracleCommand command2 = CreateOracleCommand(query2);
                    command2.Parameters.Add("rsid", rsid);
                    OracleDataReader datareader2 = ExecuteQuery(command2);
                    int tnum = -1;
                    // if tram is null, it won't get a result.
                    while (datareader2.Read())
                    {
                        tnum = Convert.ToInt32(datareader2["TRAMNUMBER"]);
                        infoStr.Add("Section| " + pos + " |Status| " + stats + " |Tramnummer| " + tnum);
                        break;
                    }
                    if (tnum == -1) infoStr.Add("Section| " + pos + " |Status| " + stats + " |Tramnummer| Geen Tram");
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally { conn.Close(); }
        }


        #region actions
        public bool GetNrOfRowsRepair(string table, string row, out int AmountOfRows, out string error)
        {
            error = "";
            AmountOfRows = -1;

            try
            {
                string query = "SELECT MAX(id) as NVALUE FROM action";
                OracleCommand command = CreateOracleCommand(query);
                // command.Parameters.Add("rw", row);
                //command.Parameters.Add("tabl", table);
                OracleDataReader datareader = ExecuteQuery(command);
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        try
                        {
                            AmountOfRows = Convert.ToInt32(datareader["NVALUE"]) + 1;

                        }
                        catch (Exception)
                        {

                            AmountOfRows = 1;
                        }




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
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetRepairActions(out List<Action.Repair> repact, out string error)
        {
            error = "";
            repact = new List<Action.Repair>();

            try
            {
                string query = "SELECT TRAM.buildyear, tram.tramnumber,tram.tmodel ,  ACTION.*FROM TRAM INNER JOIN ACTION ON TRAM.ID = ACTION.TRAM_ID where EndTime is null and TType = 'Repair'";
                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    bool stat;
                    if ((string)datareader["status"] == "Finished")
                    {
                        stat = true;
                    }
                    else stat = false;
                    int id = Convert.ToInt32(datareader["ID"]);
                    string desc = (string)datareader["TASK"];
                    DateTime buildYear = (DateTime)datareader["buildyear"];
                    string model = (string)datareader["tmodel"];
                    int tramNumber = Convert.ToInt32(datareader["TramNumber"]);
                    repact.Add(new Action.Repair(desc, id, new Train(buildYear.Year, model, tramNumber), stat));
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool RedoActiveC(Action.Clean act, out string error)
        {
            error = "";


            try
            {
                string query = "SELECT TUSER_USERNAME, ACTION_ID FROM TUSER_ACTION WHERE ACTION_ID = :act";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("act", act.ID);
                OracleDataReader datareader = ExecuteQuery(command);

                while (datareader.Read())
                {
                    string query2 = "update tuser set status = 'Available' where username = :username";
                    OracleCommand command2 = CreateOracleCommand(query2);
                    command2.Parameters.Add("username", (string)datareader["TUSER_USERNAME"]);
                    ExecuteNonQuery(command2);

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

        public bool RedoActiveR(Action.Repair act, out string error)
        {
            error = "";


            try
            {
                string query = "SELECT TUSER_USERNAME, ACTION_ID FROM TUSER_ACTION WHERE ACTION_ID = :act";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("act", act.ID);
                OracleDataReader datareader = ExecuteQuery(command);

                while (datareader.Read())
                {
                    string query2 = "update tuser set status = 'Available' where username = :username";
                    OracleCommand command2 = CreateOracleCommand(query2);
                    command2.Parameters.Add("username", (string)datareader["TUSER_USERNAME"]);
                    ExecuteNonQuery(command2);

                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetRepairActions(string username, out List<Action.Repair> repact, out string error)
        {
            error = "";
            repact = new List<Action.Repair>();

            try
            {
                string query = "SELECT TRAM.*,  ACTION.*FROM TRAM, ACTION, TUSER_ACTION WHERE TRAM.ID = ACTION.TRAM_ID AND TUSER_ACTION.ACTION_ID = ACTION.ID AND TUSER_ACTION.TUSER_USERNAME = :username AND EndTime is null AND TType = 'Repair'";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("username", username);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    bool stat;
                    if ((string)datareader["status"] == "Finished")
                    {
                        stat = true;
                    }
                    else stat = false;
                    int id = Convert.ToInt32(datareader["ID"]);
                    string desc = (string)datareader["TASK"];
                    DateTime buildYear = (DateTime)datareader["buildyear"];
                    string model = (string)datareader["tmodel"];
                    int tramNumber = Convert.ToInt32(datareader["TramNumber"]);
                    repact.Add(new Action.Repair(desc, id, new Train(buildYear.Year, model, tramNumber), stat));
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetCleanActions(out List<Action.Clean> clact, out string error)
        {
            error = "";
            clact = new List<Action.Clean>();

            try
            {
                string query = "SELECT TRAM.Buildyear, tram.tramnumber,tram.tmodel ,  ACTION.*FROM TRAM INNER JOIN ACTION ON TRAM.ID = ACTION.TRAM_ID where EndTime is null and TType = 'Clean'";
                OracleCommand command = CreateOracleCommand(query);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    bool stat;
                    if ((string)datareader["status"] == "Finished")
                    {
                        stat = true;
                    }
                    else stat = false;
                    int id = Convert.ToInt32(datareader["ID"]);
                    string desc = (string)datareader["TASK"];
                    DateTime buildYear = (DateTime)datareader["buildyear"];
                    string model = (string)datareader["tmodel"];
                    int tramNumber = Convert.ToInt32(datareader["TramNumber"]);
                    clact.Add(new Action.Clean(desc, id, new Train(buildYear.Year, model, tramNumber), stat));
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetCleanActions(string username, out List<Action.Clean> clact, out string error)
        {
            error = "";
            clact = new List<Action.Clean>();

            try
            {
                string query = "SELECT TRAM.*,  ACTION.*FROM TRAM, ACTION, TUSER_ACTION WHERE TRAM.ID = ACTION.TRAM_ID AND TUSER_ACTION.ACTION_ID = ACTION.ID AND TUSER_ACTION.TUSER_USERNAME = :username AND EndTime is null and TType = 'Clean'";
                OracleCommand command = CreateOracleCommand(query);
                command.Parameters.Add("username", username);
                OracleDataReader datareader = ExecuteQuery(command);
                while (datareader.Read())
                {
                    bool stat;
                    if ((string)datareader["status"] == "Finished")
                    {
                        stat = true;
                    }
                    else stat = false;
                    int id = Convert.ToInt32(datareader["ID"]);
                    string desc = (string)datareader["TASK"];
                    DateTime buildYear = (DateTime)datareader["buildyear"];
                    string model = (string)datareader["tmodel"];
                    int tramNumber = Convert.ToInt32(datareader["TramNumber"]);
                    clact.Add(new Action.Clean(desc, id, new Train(buildYear.Year, model, tramNumber), stat));
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }




        public bool GetAllUsers(string status, out List<User> usr, out string error)
        {
            error = "";
            usr = new List<User>();
            string str = "";
            try
            {
                if (status == "Repair")
                {
                    str = "Mechanic";
                }
                else
                {
                    str = "Cleaner";
                }
                string query = "SELECT PERMISSION.PERMISSION,  TUSER.USERNAME,  TUSER.FIRSTNAME,  TUSER.LASTNAME FROM TUSER INNER JOIN TUSER_PERMISSION ON TUSER.USERNAME = TUSER_PERMISSION.TUSER_USERNAME INNER JOIN PERMISSION ON PERMISSION.ID = TUSER_PERMISSION.PERMISSION_ID where PERMISSION.PERMISSION = :status ";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("status", str);
                OracleDataReader read = ExecuteQuery(com);
                while (read.Read())
                {
                    string userName = (string)read["Username"];
                    string firstName = (string)read["FirstName"];
                    string lastName = (string)read["LastName"];
                    User us;
                    if (status == "Repair")
                        us = new User(UserTypeEnum.Repairsman, userName, firstName, lastName);
                    else
                        us = new User(UserTypeEnum.Cleaner, userName, firstName, lastName);

                    usr.Add(us);
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ChangeActionRepair(Action.Repair act, out string error)
        {//EstimatedEndTime = :estimatedEndTime 
            error = "";
            try
            {
                string query = "update ACTION set TASK = :tsk, ESTIMATEDENDDATE = :estimatedEndTime  where ID = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("tsk", act.Note);
                com.Parameters.Add("estematedEndTime", act.EstimatedDateEnd);
                com.Parameters.Add("id", act.ID);


                ExecuteNonQuery(com);
                com.Dispose();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool ChangeActionClean(Action.Clean act, out string error)
        {//EstimatedEndTime = :estimatedEndTime 
            error = "";
            try
            {
                string query = "update ACTION set TASK = :tsk, ESTIMATEDENDDATE = :estimatedEndTime  where ID = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("tsk", act.Note);
                com.Parameters.Add("estematedEndTime", act.EstimatedDateEnd);
                com.Parameters.Add("id", act.ID);


                ExecuteNonQuery(com);
                com.Dispose();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool ChangeActionRepair(Action.Clean act, out string error)
        {//EstimatedEndTime = :estimatedEndTime 
            error = "";
            try
            {
                string query = "update ACTION set TASK = :tsk  where ID = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", Convert.ToInt32(act.ID));
                com.Parameters.Add("tsk", (string)act.Note);
                //com.Parameters.Add("estematedEndTime", act.EstimatedDateEnd);
                ExecuteNonQuery(com);
                com.Dispose();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool ActivateAction(List<General.User> usr, Action.Repair act, out string error)
        {
            error = "";
            try
            {
                foreach (User item in usr)
                {
                    string query = "insert into TUser_Action(TUser_Username, Action_id) values(:UserId, :ActionId)";
                    OracleCommand com = CreateOracleCommand(query);
                    com.Parameters.Add("UserId", item.UserName);
                    com.Parameters.Add("ActionId", act.ID);

                    ExecuteNonQuery(com);
                    com.Dispose();
                    conn.Close();

                    string query3 = "update TUSER set status = 'Not Available' where USERNAME = :UserId";
                    OracleCommand com3 = CreateOracleCommand(query3);
                    com3.Parameters.Add("UserId", item.UserName);
                    ExecuteNonQuery(com3);
                    com3.Dispose();
                    conn.Close();

                }
                //EstimatedEndTime = :estimatedEndTime    Not yet in the create
                string query2 = "update action set ESTIMATEDENDDATE = :estimatedEndTime,  StartTime = :Time, status = 'Finished' where id = :id";
                OracleCommand com2 = CreateOracleCommand(query2);
                com2.Parameters.Add("estimatedEndTime", act.EstimatedDateEnd);
                com2.Parameters.Add("Time", act.DateStart);
                com2.Parameters.Add("id", act.ID);
                ExecuteNonQuery(com2);
                com2.Dispose();


            }
            catch (Exception e)
            {
                error = e.Message;
                return false;

            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public bool ActivateActionC(List<General.User> usr, Action.Clean act)
        {
            string error = "";
            try
            {
                foreach (User item in usr)
                {
                    string query = "insert into TUser_Action(TUser_Username, Action_id) values(:UserId, :ActionId)";
                    OracleCommand com = CreateOracleCommand(query);
                    com.Parameters.Add("UserId", item.UserName);
                    com.Parameters.Add("ActionId", act.ID);

                    ExecuteNonQuery(com);
                    com.Dispose();
                    conn.Close();

                    string query3 = "update TUSER set status = 'Not Available' where USERNAME = :UserId";
                    OracleCommand com3 = CreateOracleCommand(query3);
                    com3.Parameters.Add("UserId", item.UserName);
                    ExecuteNonQuery(com3);
                    com3.Dispose();
                    conn.Close();

                }
                //EstimatedEndTime = :estimatedEndTime    Not yet in the create
                string query2 = "update action set ESTIMATEDENDDATE = :estimatedEndTime,  StartTime = :Time, status = 'Finished' where id = :id";
                OracleCommand com2 = CreateOracleCommand(query2);
                com2.Parameters.Add("estimatedEndTime", act.EstimatedDateEnd);
                com2.Parameters.Add("Time", act.DateStart);
                com2.Parameters.Add("id", act.ID);
                ExecuteNonQuery(com2);
                com2.Dispose();


            }
            catch (Exception e)
            {
                error = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public bool CreateActionRepair(Action.Repair act, out string error)
        {
            error = "";
            try
            {

                int Id = 0;
                string errors = "";
                int id2 = 0;
                string query = "insert into action(id, Task,TType,status,tram_id) values(:id,:note,:type, 'Unfinished', :tram)";
                if (GetNrOfRowsRepair("ACTION", "id", out Id, out errors))
                {
                    if (GetTramId(out id2, act.Tram.TramNumber))
                    {

                        OracleCommand com = CreateOracleCommand(query);
                        com.Parameters.Add("id", Id);
                        com.Parameters.Add("note", act.Note);
                        com.Parameters.Add("type", "Repair");
                        com.Parameters.Add("tram", id2);
                        ExecuteNonQuery(com);
                        com.Dispose();

                    }
                }

                return true;


            }
            catch (Exception e)
            {
                error = e.Message;

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool CreateActionClean(Action.Clean act, out string error)
        {
            error = "";
            try
            {

                int Id = 0;
                string errors = "";
                int id2 = 0;
                string query = "insert into action(id, Task,TType,status,tram_id) values(:id,:note,:type, 'Unfinished', :tram)";
                if (GetNrOfRowsRepair("ACTION", "id", out Id, out errors))
                {
                    if (GetTramId(out id2, act.Tram.TramNumber))
                    {

                        OracleCommand com = CreateOracleCommand(query);
                        com.Parameters.Add("id", Id);
                        com.Parameters.Add("note", act.Note);
                        com.Parameters.Add("type", "Clean");
                        com.Parameters.Add("tram", id2);
                        ExecuteNonQuery(com);


                    }
                }

                return true;


            }
            catch (Exception e)
            {
                error = e.Message;

            }
            finally
            {
                conn.Close();
            }
            return false;
        }


        public bool FinishActionRepair(Action.Repair act, out string error)
        {
            error = "";
            try
            {
                string query = "update action set ENDTIME = :end where ID = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("end", act.DateEnd);
                com.Parameters.Add("id", act.ID);
                ExecuteNonQuery(com);
                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;

            }
            finally
            {
                conn.Close();
            }
        }
        public bool FinishActionClean(Action.Clean act, out string error)
        {
            error = "";
            try
            {
                string query = "update action set ENDTIME = :end where ID = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("end", Convert.ToDateTime(act.DateEnd));
                com.Parameters.Add("id", act.ID);

                ExecuteNonQuery(com);
                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;

            }
            finally
            {
                conn.Close();
            }
        }

        public bool GetTram(out Train tram, int number)
        {
            string error = "";
            tram = null;
            try
            {

                string query = "select * from tram where tramnumber = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", number);

                OracleDataReader value = ExecuteQuery(com);
                while (value.Read())
                {
                    DateTime buildYear = (DateTime)value["buildyear"];
                    string model = (string)value["tmodel"];
                    int tramNumber = Convert.ToInt32(value["TramNumber"]);
                    tram = new Train(buildYear.Year, model, tramNumber);
                }
                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool GetTramId(out int tramid, int number)
        {
            tramid = -1;
            try
            {

                string query = "select tram.id from tram where tramnumber = :id";
                OracleCommand com = CreateOracleCommand(query);
                com.Parameters.Add("id", number);

                OracleDataReader value = ExecuteQuery(com);
                while (value.Read())
                {
                    tramid = Convert.ToInt32(value["ID"]);
                }
                return true;

            }
            catch (Exception)
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

