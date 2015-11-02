using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using System.Windows.Forms;

namespace S22DProftaak.BeheerSysteem
{
    /// <summary>
    /// management class
    /// </summary>
    class ManagementSystem
    {
        private List<Train> trains;
        public ManagementSystem()
        {
            throw new NotImplementedException();
        }
        public bool GetTrains()
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
        public bool OpenAction(Action action)// action action aanpassen
        {
            throw new NotImplementedException();
        }
        public bool BlockRail(RailSection railsection)
        {
            throw new NotImplementedException();
        }
        public bool ApplyForAction(Action action) //aanpassen
        {
            throw new NotImplementedException();
        }
        public bool ValidateNewInput(object sender, EventArgs e)
        {
            GetTrains();
            RichTextBox currentbox = sender as RichTextBox;
            foreach(Train t in trains)
            {
                //need to add trainnumber property to train. wait until sure nobody else did.
               if(currentbox.Text == Convert.ToString(/*t.number*/))
               {
                   return true;
               }

            }
            return false;
        }
    }
}
