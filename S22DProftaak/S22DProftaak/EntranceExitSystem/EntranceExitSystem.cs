using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.CleanSystem;
using S22DProftaak.RepairSystem;


namespace S22DProftaak.EntranceExit
{
    class EntranceExitSystem
    {

        // fields
        private Train _currentTram;// { get; private set; }
        private Database.DatabaseConnection db = new Database.DatabaseConnection();
        private GeneralSystem sys = new GeneralSystem();
        private CleanSystem.CleanSystem cleansys = new CleanSystem.CleanSystem();
        private RepairSystem.RepairSystem repairsys = new RepairSystem.RepairSystem();
        private string _error = "";
        public Train CurrenTrain { get { return _currentTram; } }
        private List<Train> _trains = new List<Train>();
        public List<Train> Trains { get { return _trains; } }
        public string Error { get { return _error; } }
        private List<Rail> _rails = new List<Rail>();
        public List<Rail> Rails { get { return _rails; } }
        private RailSection _targetTrack;
        public RailSection TargetTrack { get { return _targetTrack; } }

        // boa constructor
        public EntranceExitSystem()
        {
            
        }
        public bool EnterTrain(Train train, RailSection railsection)
        {
            return db.EnterTrain(train, railsection, out this._error);
        } // not used for now

        public bool getRails()
        {  
           return db.GetRails(out _rails, out this._error);
        } // get the rails from the database. not used for now

        public bool GetTrams()
        {
            return db.GetTrains(out this._trains, out this._error);
        } // get the trams from the database. Intended for the listbox

        public bool ApplyRepairSession(string note)
        {
            return cleansys.CreateClean(_currentTram.TramNumber, note, out _error);
        } // use the note given through rich textbox and make a request for an action

        public bool ApplyCleanSession(string note)
        {
            return repairsys.CreateRepair(_currentTram.TramNumber, note, out _error);
        } // use the note given through rich textbox and make a request for an action
        public bool MoveTram()
        {
            bool sht = db.MoveTrain(this._currentTram, sys.GetLoggedUser, out this._error);
            if (sht) return RemoveRequest();
            else return false;
        } // move the tram to intended location from requesting
        public bool AddRequest()
        {
            return db.AddRequest(this._currentTram, out this._error);
        }// add a request to requesting in the database
        public bool RemoveRequest()
        {
            return db.RemoveRequest(this._currentTram, out this._error);
        } // supposed to remove a request. Might have to be handled in management
        public bool GetRequest()
        {
            return db.GetRequest(this._currentTram, out _targetTrack, out _error);
        } // get a request from requesting in database. destination for the tram

        public bool ValidateTrainNumber(int tramNumber)
        {
           return db.GetOneTrainInfo(tramNumber, out this._currentTram, out _error);
        } // get the tram = _currenttram by asking with the number.

        public bool HasArrived()
        {
            return db.HasArrived(CurrenTrain, out _error);
        } // show the tram has arrived to intended location.
    }
}
