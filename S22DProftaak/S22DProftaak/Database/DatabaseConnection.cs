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
        private string dataSource = "//";

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
       





        #region RepairSystem
      

     public bool   GetActions(string status, out List<Action.Action> act) 
     {
         act = null;
        string error = "";
        
            
                 try{
                 string query = "Select * from action a,tram t where a.Tram_id = t.id amd EndTime is null and TType = ':action'";
                       OracleCommand com = CreateOracleCommand(query);
                     com.Parameters.Add("action" , status);
                 List<OracleDataReader> List = ExecuteMultiQuery(com);
                     foreach (OracleDataReader item in List)
                     {
                         string desc = (string)item["TASK"];
                         int id = (int)item["ID"];
                         int buildYear = (int)item["buildyear"];
                         string model = (string)item["tmodel"];
                         int tramNumber = (int)item["TramNumber"];
                         if(status == "Repair")

                         {

                         act.Add(new Action.Repair(desc,id,new Train(buildYear,model,tramNumber)));
                         }
                         else if (status == "Clean")
                         {
                            // act.Add(new Action.Clean(desc,id));
                         }
                         
                     }
	               
                     }
                     catch(Exception e)
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
     public bool   GetAllUsers(string status, out List<User> usr)
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
		string userName = (string)item["Username"] ;
        string firstName = (string)item["FirstName"]   ;
       string lastName = (string)item["LastName"];
                 usr.Add(new User(UserTypeEnum.Repairsman,userName,firstName,lastName));

        
	}

         }
         catch(Exception e)
         {
             
         }
         finally
         {
             conn.Close();
         }
         return true;
     }
     public bool   ChangeAction(Action.Action act)    
     {  
       string  error = "update tram set Task = ':task' , EstimatedEndTime = ':estimatedEndTime' where ID = ':id'";
         try
         {
             string query = "";
             OracleCommand com = CreateOracleCommand(query);
             com.Parameters.Add("id", act.ID);
             com.Parameters.Add("task",act.Note);
             com.Parameters.Add("estematedEndTime", act.EstimatedDateEnd);
             ExecuteNonQuery(com);
             com.Dispose();
         }
         catch(Exception e)
         {

         }
         finally 
         {
             conn.Close();
         }
         return true;
     }
     public bool   ActivateAction(List<General.User> usr, Action.Action act)
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
             com2.Parameters.Add("estimatedEndTime",act.EstimatedDateEnd);
             com2.Parameters.Add("note", act.Note);
             com2.Parameters.Add("Time", act.DateStart);
             com2.Parameters.Add("id", act.ID);
             ExecuteNonQuery(com2);
             com2.Dispose();


         }
         catch(Exception e)
         {

         }
         finally
         {
             conn.Close();
         }
         return true;
     }
     public bool   CreateAction(Action.Action act)
     {
       string  error = "";
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
             if (!GetNrOfRows("action","id",out Id,out errors))
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


     public bool       GetUserActions(General.User usr, out List<Action.Action> act)
     {
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


                act.Add(new Action.Repair( note, dateStart, Id, estimatedDateEnd,new Train(buildYear,model,tramNumber)));



             }
             com.Dispose();
         }
         catch (Exception)
         {
             
             throw;
         }
         finally
         {
             conn.Close();
         }
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

              OracleDataReader value =  ExecuteQuery(com);
              int buildYear = (int)value["buildyear"];
                string model = (string)value["tmodel"];
                int tramNumber = (int)value["TramNumber"];
                tram = new Train(buildYear,model,tramNumber);
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

        #endregion

#region test
       
#endregion
    }
}
