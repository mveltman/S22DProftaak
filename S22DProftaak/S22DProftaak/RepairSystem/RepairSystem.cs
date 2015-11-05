using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.Database;
using S22DProftaak.Action;

namespace S22DProftaak.RepairSystem // commented because the references don't work.
{
    public class RepairSystem
    {
        public RepairSystem()
        {
            throw new NotImplementedException();
        }

        public bool ApplyRepairSession(Repair repair, List<User> Repairsman, DateTime time)
        {
            // koppel Action Id met Repairs shit
            throw new NotImplementedException();
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
        public bool ActivateRepair(Repair action)
        {
            action.ActivateRepair(); 
            // throw action into database
            return true;

        }
        

        public bool GetTramSpoor(out Train train, int spoor, int sector)
        {
            throw new NotImplementedException();
        }
    }
}