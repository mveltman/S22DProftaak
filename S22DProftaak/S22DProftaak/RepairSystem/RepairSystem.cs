using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.Database;
using S22DProftaak.Action;







namespace S22DProftaak.RepairSystem
{
    public class RepairSystem
    {
        public List<General.RailSection> RailList;
        private string _error;
        private List<Action.Repair> _repairlist = new List<Action.Repair>();
        public List<Action.Repair> repairlist { get { return _repairlist; } } 
        Database.DatabaseConnection SQL = new Database.DatabaseConnection();
        public RepairSystem()
        {
            
        }

        public bool GetWorkers(out List<User> Use)
        {
            Use = new List<User>();
            if (SQL.GetAllUsers("Repair", out Use))
            {
                return true;
            }
            return false;
        }// Gets Alle workers who can Repair

        public bool SetEndTime(Action.Action act)
        {

            act.AddEndDate(DateTime.Now);
            if (SQL.FinishAction(act))
            {
                return true;
            }
            return false;

        }
        public bool ApplyRepairSession(Repair repair, List<User> Repairsman, DateTime time)
        {
            repair.ActivateAction(time);
            SQL.ActivateAction(Repairsman, repair);
            return true;
        }

        public bool CreateRepair(int number, string Desc)
        {
            Train tram = null;
            if (SQL.GetTram(out tram, number))
            {
                Action.Repair action = new Action.Repair(Desc, tram);
                SQL.CreateAction(action); // creates a new action based on the the given information
            }

            return false;


        }

        public bool GetRepairTasks()
        {
            if (SQL.GetRepairActions(out _repairlist, out _error))
            {
                return true;
            }
            return false;
        }

        public bool GetRepairTasks(string username)
        {
            if (SQL.GetRepairActions(username, out _repairlist, out _error))
            {
                return true;
            }
            return false;
        }





        public bool UpdateRepaired(Action.Action action, string Descrition, DateTime EstimatedEndTime)
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