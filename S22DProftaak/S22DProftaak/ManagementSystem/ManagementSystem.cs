using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.Action;

namespace S22DProftaak.BeheerSysteem
{
    /// <summary>
    /// management class
    /// </summary>
    class ManagementSystem
    {
        Database.DatabaseConnection db = new Database.DatabaseConnection();
        public ManagementSystem()
        {
            throw new NotImplementedException();
        }
        public bool OpenRemise()
        {
            throw new NotImplementedException();
        }
        public bool OpenRails()
        {
            throw new NotImplementedException();
        }
        public bool OpenAction(Repair action)// action action aanpassen
        {
            throw new NotImplementedException();
        }
        public bool OpenAction(Clean action)// action action aanpassen
        {
            throw new NotImplementedException();
        }
        public bool BlockRail(RailSection railsection)
        {
            throw new NotImplementedException();
            // todo: return db.ToggleRailsectStatus(railsection));
        }
        public bool ApplyForAction(Repair action) //aanpassen
        {
            throw new NotImplementedException();
        }
        public bool ApplyForAction(Clean action) //aanpassen
        {
            throw new NotImplementedException();
        }
    }
}
