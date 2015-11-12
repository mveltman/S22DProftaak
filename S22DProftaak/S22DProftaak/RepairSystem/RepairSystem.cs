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

        public bool GetWorkers(out List<User> Use, out string error)
        {
            Use = new List<User>();
            return SQL.GetAllUsers("Repair", out Use, out error);

        }// Gets Alle workers who can Repair

        public bool SetEndTime(Action.Repair act, out string error)
        {

            act.AddEndDate(DateTime.Now);
            return SQL.FinishActionRepair(act, out error);

        }
        public bool ApplyRepairSession(Repair repair, List<User> Repairsman, DateTime time, out string error)
        {

            repair.ActivateAction(time);
            return SQL.ActivateAction(Repairsman, repair, out error);

        }

        public bool CreateRepair(int number, string Desc, out string error)
        {
            Train tram = null;
            SQL.GetTram(out tram, number);
            Action.Repair action = new Action.Repair(Desc, tram);
            return SQL.CreateActionRepair(action, out error); // creates a new action based on the the given information     


        }
        public bool Redo(Action.Repair act, out string error)
        {
            return SQL.RedoActiveR(act, out error);
        }

        public bool GetRepairTasks()
        {
            return SQL.GetRepairActions(out _repairlist, out _error);

        }


        public bool GetRepairTasks(string username)
        {

            return SQL.GetRepairActions(username, out this._repairlist, out _error);
        }





        public bool UpdateRepaired(Action.Repair action, string Descrition, DateTime EstimatedEndTime, out string error)
        {


            action.ChangeInfo(Descrition, EstimatedEndTime);
            return SQL.ChangeActionRepair(action, out error);


        }

        public bool UpdateUser(User user, bool active)
        {
            throw new NotImplementedException();
        }




    }
}