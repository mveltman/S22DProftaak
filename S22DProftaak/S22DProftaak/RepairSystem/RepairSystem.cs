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
        Database.DatabaseConnection SQL = new Database.DatabaseConnection();
        public RepairSystem()
        {
            throw new NotImplementedException();
        }

        public bool GetWorkers(out List<User> Use)
        {
            Use = new List<User>();
            return true;// To implement : 
        }

        public bool SetEndTime(Action.Action act)
        {

            act.AddEndDate(DateTime.Now);
            return true;
        }
        public bool ApplyRepairSession(Repair repair, List<User> Repairsman, DateTime time)
        {
            repair.ActivateRepair(time); 
            return true;
        }

        public bool CreateRepair(int spoor, int sector, string Desc)
        {
            RailList = new List<General.RailSection>();
            foreach (General.RailSection rail in RailList)
            {
                if ((Int32)rail.RailNumber == spoor && rail.Position == Convert.ToInt16(sector))
                {
                    General.Train train;
                    if (GetTramSpoor(out train, spoor, sector))
                    {
                        Action.Repair action = new Action.Repair(Desc, rail, train); // Get tram on specified rail
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                    // To database
                }
                // koppel Action Id met Repairs shit

            } return true;
        }

        public bool GetRepairTasks(out List<Action.Repair> Repairs ,bool completed)
        {
            throw new NotImplementedException();
        }

    

       

        public bool UpdateRepaired(Repair action, string Descrition, DateTime EstimatedEndTime)
        {
            if (Descrition == "")
            {
                Descrition = action.Note;
            } 
            if(EstimatedEndTime ==  Convert.ToDateTime("5-11-2015 0:09"))
            {
                EstimatedEndTime = action.EstimatedDateEnd;
            }
            else
            {
                EstimatedEndTime = Convert.ToDateTime("5-11-2015 0:09");
            }
            action.ChangeInfo(Descrition, EstimatedEndTime);
            return true;
        }

        public bool UpdateUser(User user, bool active)
        {
            throw new NotImplementedException();
        }
     
        

        public bool GetTramSpoor(out Train train, int spoor, int sector)
        {
            throw new NotImplementedException();
        }
    }
}