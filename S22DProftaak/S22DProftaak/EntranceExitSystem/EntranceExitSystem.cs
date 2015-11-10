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

        public EntranceExitSystem()
        {
            //if (!sys.GetTrainLoggedUser(out _currentTram, out this._error))
            //{
            //    // error is written. Must be shown in the form.
            //}
            //else
            //{
            //    // we know the logged user and the tram used.
            //}
            //CurrentTram = //Sys.GetLoggedUser();
        }
        public bool EnterTrain(Train train, RailSection railsection)
        {

            //throw new NotImplementedException();
            return db.EnterTrain(train, railsection, out this._error);

        }

        public bool getRails()
        {  
           return db.GetRails(out _rails, out this._error);
            //throw new NotImplementedException();

        }

        public bool GetTrams()
        {
            //throw new NotImplementedException();
            // fill the Trains list with the database
            return db.GetTrains(out this._trains, out this._error);
            // return the trams in the out
        }

        public bool ApplyRepairSession(string note)
        {
            return cleansys.CreateClean(_currentTram.TramNumber, note, out _error);
        }

        public bool ApplyCleanSession(string note)
        {
            return repairsys.CreateRepair(_currentTram.TramNumber, note, out _error);
        }

        public bool MoveTram()
        {
            bool sht = db.MoveTrain(this._currentTram, sys.GetLoggedUser, out this._error);

            // use this.CurrentTram TODO: movetrain in database class!
            if (sht) 
            {
                return RemoveRequest();
            }
            else return false;
        }

        public bool UpdateAllTrams()
        {
            return db.GetTrains(out this._trains, out this._error);
        }
        public bool AddRequest()
        {
            return db.AddRequest(this._currentTram, out this._error);
        }
        public bool RemoveRequest()
        {
            return db.RemoveRequest(this._currentTram, out this._error);
        }
        public bool GetRequest()
        {
            return db.GetRequest(this._currentTram, out _targetTrack, out _error);
        }

        public bool ValidateTrainNumber(int p)
        {
           return db.GetOneTrainInfo(p, out this._currentTram, out _error);
        }

        public bool HasArrived()
        {
            return db.HasArrived(CurrenTrain, out _error);
        }
    }
}
