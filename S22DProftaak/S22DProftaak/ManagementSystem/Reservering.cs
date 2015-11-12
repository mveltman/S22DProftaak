using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.ManagementSystem
{
    public class Reservering
    {
        private int RailNumber { get; set; }
        private int RailPosition { get; set; }
        public int TrainNumber { get; set; }

        public Reservering(int railnumber, int railposition, int trainnumber)
        {
            this.RailNumber = railnumber;
            this.RailPosition = railposition;
            this.TrainNumber = trainnumber;
        }


    }
}
