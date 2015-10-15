using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    class Rail
    {
        /// <summary>
        /// This is the class for rail
        /// This class holds information such as the railsections, length, number and type
        /// </summary>
        public RailType RailType {get; private set; }
        public int Length {get; private set; }
        public int RailNumber { get; private set; }
        public List<RailSection> RailSections = new List<RailSection>();
        public Rail(RailType railType, int length, int railNumber)
        {
            this.RailType = railType;
            this.RailNumber = railNumber;
            this.Length = length;
            for (int i = 0; 1 < length; i++)
            {
                RailSections.Add(new RailSection(i));
            }
        } // sets railtype,number,lenght,section
    }
}
