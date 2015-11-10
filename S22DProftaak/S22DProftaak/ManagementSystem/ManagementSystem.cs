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
        private List<Train> _Trains = new List<Train>();
        private DatabaseConnection db = new DatabaseConnection();
        private List<RailSection> RailSections = new List<RailSection>();
        private List<Reservering> Reserveringen = new List<Reservering>();
        
        private string _error = "";
        private bool _status;

        public List<Train> GetTrains 
        {
            get { return _Trains; }
            set { this._Trains = value; }
        }
        public ManagementSystem()
        {
            
        }
        public bool GetdbTrains()
        {

            return db.GetTrains(out _Trains, out _error);
        }
        public bool OpenRemise()
        {
            throw new NotImplementedException();
            //This is a filler method for the sake of expandibility.
        }
        public bool OpenRails()
        {
            return db.OpenRails(out RailSections, out _error);

        }
        public bool OpenAction(Action.Action action)// action action aanpassen
        {
           // db.GetAllActions();
            return true;
        }
        public bool BlockRail(RailSection railsection)
        {
            return db.BlockRail(railsection, out _status, out _error);
        }
        public bool ApplyForAction(Action.Action action) //aanpassen
        {
            throw new NotImplementedException();
        }
        public bool ValidateNewInput(object sender)
        {
            GetdbTrains();
            RichTextBox currentbox = sender as RichTextBox;
            foreach(Train t in _Trains)
            {

               if(currentbox.Text == Convert.ToString(t.TramNumber))

               {
                   return true;
               }

            }
            return false;
        }
        
    }
}
