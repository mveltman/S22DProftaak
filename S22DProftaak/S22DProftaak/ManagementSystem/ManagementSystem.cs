using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using System.Windows.Forms;
using S22DProftaak.Database;
using S22DProftaak.Action;

namespace S22DProftaak.ManagementSystem
{
    /// <summary>
    /// management class
    /// </summary>
    public class ManagementSystem
    {
        private List<Train> trains = new List<Train>();
        private DatabaseConnection db = new DatabaseConnection();
        
        public ManagementSystem()
        {
            
        }
        public bool GetTrains()
        {
            //this.trains = db.GetTrains();
            throw new NotImplementedException();
        }
        public bool OpenRemise()
        {
            //db
            throw new NotImplementedException();
        }
        public bool OpenRails()
        {
            //db.
            throw new NotImplementedException();
        }
        public bool OpenAction(Action.Action action)// action action aanpassen
        {
            throw new NotImplementedException();
        }
        public bool BlockRail(RailSection railsection)
        {
            throw new NotImplementedException();
        }
        public bool ApplyForAction(Action.Action action) //aanpassen
        {
            throw new NotImplementedException();
        }
        public bool ValidateNewInput(object sender)
        {
            GetTrains();
            RichTextBox currentbox = sender as RichTextBox;
            foreach(Train t in trains)
            {
                //need to add trainnumber property to train. wait until sure nobody else did.
               if(currentbox.Text == Convert.ToString(/*t.number*/""))
               {
                   return true;
               }

            }
            return false;
        }
    }
}
