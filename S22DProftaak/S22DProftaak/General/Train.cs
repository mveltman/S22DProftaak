using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    public class Train
    {
        /// <summary>
        /// This is the class of trains
        /// a train holds the necessary information for its identification
        /// A train can be on a railsection, but that is set on the section itself, not vice versa.
        /// </summary>
        public int BuildYear { get; private set; }
        public string Model { get; private set; }
        public Train(int buildYear, string model)
        {
            this.BuildYear = buildYear;
            this.Model = model;
        }//sets BuildYear and Model.
    }
}
