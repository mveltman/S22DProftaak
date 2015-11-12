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
        private List<Reservering> _reserveringen = new List<Reservering>();
        private List<string> _railinfostrings = new List<string>();
        private bool busywithrequest = false;
        private bool _railstatus;
        private string _error = "";
        private bool _status;

        public List<string> RailInfoStrings { get { return _railinfostrings; } }
        public List<Reservering> Reserveringen { get { return _reserveringen; } }
        public bool RailStatus { get { return _railstatus; } }
        public bool changeBusyWithRequest { get { return busywithrequest; } set { busywithrequest = value; } } 
        public string Error { get { return _error; } }
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
        public bool OpenRails()
        {
            return db.OpenRails(out RailSections, out _error);

        }

        public bool BlockRail(RailSection railsection)
        {
            return db.BlockRail(railsection, out _status, out _error);
        }
        public bool ValidateNewInput(object sender)
        {
            GetdbTrains();
            RichTextBox currentbox = sender as RichTextBox;
            foreach (Train t in _Trains)
            {

                if (currentbox.Text == Convert.ToString(t.TramNumber))
                {
                    return true;
                }

            }
            return false;
        }
        public bool ValidateNewInput(int trainnumber)
        {
            GetdbTrains();
            foreach(Train t in _Trains)
            {
                if(trainnumber == t.TramNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateRailposition(int railnumber, int railposition)
        {
            if (db.ValidateSector(railposition, railnumber, out _error))
            {
                return true;
            }
            else return false;

        }
        public bool ValidateRailNr(int railnumber)
        {
            return db.ValidateRailNr(railnumber, out _error);
        }
        public bool CheckRequests()
        {
            int trainnumber = -1;
            if (changeBusyWithRequest == false)
            {
                if (db.CheckForRequests(out trainnumber, out _error))
                {
                    ManagementRequestingForm fm = new ManagementRequestingForm(trainnumber);
                    fm.Show();
                    changeBusyWithRequest = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
        public bool AddReserveration(Reservering r)
        {
            Reserveringen.Add(r);
            return true;
        }
        public bool PlaceTrain(int tramnumber, int railnumber, int railposition)
        {
            return db.PlaceTrain(tramnumber, railnumber, railposition, out _error);
        }
        public bool CompleteRequest(int tramnumber, int railnumber, int railposition)
        {
            changeBusyWithRequest = false;
            return db.CompleteRequest(tramnumber, railnumber, railposition, out _error);
            
        }
        public bool GetRailInfo(int RailNumber)
        {
            return db.GetRailInfo(RailNumber, out _railinfostrings, out _error);
        }
        public bool CheckRailStatus(int Railnumber, int Railposition)
        {
            return db.CheckRailStatus(Railnumber, Railposition, out _railstatus ,out _error);
        }
    }
}
