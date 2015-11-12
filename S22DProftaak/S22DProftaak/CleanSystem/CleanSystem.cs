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
        private string _error;
        private List<Action.Clean> _cleanlist = new List<Action.Clean>();
        public List<Action.Clean> cleanlist { get { return _cleanlist; } }
        Database.DatabaseConnection SQL = new Database.DatabaseConnection();
        public CleanSystem()
        {

        }

        public bool GetWorkers(out List<User> Use, out string error)
        {
            Use = new List<User>();
            return SQL.GetAllUsers("Clean", out Use, out error);
        }// Gets Alle workers who can clean

        public bool SetEndTime(Action.Clean act, out string error)
        {

            act.AddEndDate(DateTime.Now);
            return SQL.FinishActionClean(act, out error);


        }
        public bool ApplyCleanSession(Clean clean, List<User> Cleansman, DateTime time)
        {
            time = DateTime.Now;
            clean.ActivateAction(time);
            SQL.ActivateActionC(Cleansman, clean);
            return true;
        }

        public bool CreateClean(int number, string Desc)
        {
            Train tram = null;
            SQL.GetTram(out tram, number);
            Action.Clean action = new Action.Clean(Desc, tram);
            return SQL.CreateActionClean(action, out _error); // creates a new action based on the the given information   


        }
        public bool Redo(Action.Clean act, out string error)
        {
            return SQL.RedoActiveC(act, out error);
        }
        public bool GetCleanTasks()
        {

            return SQL.GetCleanActions(out this._cleanlist, out _error);
        }
        public bool GetCleanTasks(string username)
        {

            return SQL.GetCleanActions(username, out this._cleanlist, out _error);
        }





        public bool UpdateCleaned(Action.Clean action, string Descrition, DateTime EstimatedEndTime, out string error)
        {


            action.ChangeInfo(Descrition, EstimatedEndTime);
            SQL.ChangeActionClean(action, out error);

            return true;
        }

        public bool UpdateUser(User user, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
