using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.Action;
using S22DProftaak.Database;


namespace S22DProftaak.CleanSystem
{
    public class CleanSystem
    {
        public List<General.RailSection> RailList;
        Database.DatabaseConnection SQL = new Database.DatabaseConnection();
        public CleanSystem()
        {

        }

        public bool GetWorkers(out List<User> Use)
        {
            Use = new List<User>();
            if (SQL.GetAllUsers("Clean", out Use))
            {
                return true;
            }
            return false;
        }// Gets Alle workers who can clean

        public bool SetEndTime(Action.Action act)
        {
            act.AddEndDate(DateTime.Now);
            if (SQL.FinishAction(act))
            {
                return true;
            }
            return false;
        }
        public bool ApplyCleanSession(Clean clean, List<User> Cleansman, DateTime time)
        {
            clean.ActivateAction(time);
            SQL.ActivateAction(Cleansman, clean);
            return true;
        }

        public bool CreateClean(int number, string Desc)
        {
            Train tram = null;
            if (SQL.GetTram(out tram, number))
            {
                Action.Clean action = new Action.Clean(Desc, tram);
                SQL.CreateAction(action); // creates a new action based on the the given information
            }
            return false;
        }
        public bool CreateClean(int number, string Desc, out string error)
        {
            Train tram = null;
            error = "";
            if (SQL.GetTram(out tram, number, out error))
            {
                Action.Clean action = new Action.Clean(Desc, tram);
                return SQL.CreateAction(action, out error); // creates a new action based on the the given information and returns whether it succeeded
            }
            return false;
        }
        public bool GetCleanTasks(out List<Action.Action> Cleans)
        {
            Cleans = null;
            if (SQL.GetActions("Clean", out Cleans))
            {
                return true;
            }
            return false;
        }
        public bool UpdateCleaned(Action.Action action, string Descrition, DateTime EstimatedEndTime)
        {
            action.ChangeInfo(Descrition, EstimatedEndTime);
            SQL.ChangeAction(action);
            return true;
        }

        public bool UpdateUser(User user, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
