using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    /// <summary>
    /// This is the class for railsection which is a section of rails.
    /// This class holds information such as the position relative to other sections on a rail
    /// And which train is on it(only one at the time)
    /// </summary>
    public class RailSection
    {

        public int Position { get; private set; }
        public bool Blocked { get; private set; }
        public Train Train { get; private set; }
        public int RailNumber { get; private set; } 

        public RailSection(int position, int railNumber, bool blocked)
        {
            this.Position = position;
            this.RailNumber = railNumber;
            this.Blocked = blocked;
        }//Sets position on rail
        public bool RemoveTrain()
        {
            throw new NotImplementedException();
            //if(Train==null) return false;
            //else
            //{
            //    Train = null;
            //    return true;
            //}
        }
        public bool UpdateTrain(Train train)
        {
            throw new NotImplementedException();
            //if (Train == null) return false;
            //Train = train;
            //return true;
        }
    }
}
