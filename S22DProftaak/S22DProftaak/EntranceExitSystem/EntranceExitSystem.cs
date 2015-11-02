using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;
using S22DProftaak.RepairSystem;

namespace S22DProftaak.EntranceExit
{
    class EntranceExitSystem
    {
        private Train currentTram;// { get; private set; }
        private Database.DatabaseConnection db = new Database.DatabaseConnection();
        private GeneralSystem Sys = new GeneralSystem();
        private string error = "";
        public Train CurrenTrain { get { return currentTram; } }
        public string Error { get { return error; } }

        public EntranceExitSystem()
        {
            if (!Sys.GetTrainLoggedUser(out currentTram, out this.error))
            {
                // error is written. Must be shown in the form.
            }
            else
            {
                // we know the logged user and the tram used.
            }
            //CurrentTram = //Sys.GetLoggedUser();
            throw new NotImplementedException();
        }
        public bool EnterTrain(Train train, RailSection railsection)
        {
            throw new NotImplementedException();
        }

        public bool getrails()
        {
            throw new NotImplementedException();
        }

        public bool GetTrams(out List<Train> trains)
        {
            // fill the Trains list with the database
            // return the trams in the out
            throw new NotImplementedException();
        }

        public bool ApplyRepairSession(string repairsystem)
        {//todo : this might not be necessary if repair form is used!
            throw new NotImplementedException();
        }

        public bool ApplyCleanSession(string repairsystem)
        {//todo : this might not be necessary if clean form is used!
            throw new NotImplementedException();
        }

        public bool MoveTram()
        {
            // use this.CurrentTram TODO: movetrain in database class!
            // -- return (db.MoveTrain(this.currentTram, out error));
            throw new NotImplementedException();
        }

        public bool UpdateAllTrams()
        {
            throw new NotImplementedException();
        }
    }
}
