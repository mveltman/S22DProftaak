using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;

namespace S22DProftaak.Action
{
    /// <summary>
    /// This class saves all information about a clean action
    /// </summary>
    public class Repair : Action
    {
            public Repair(string note, DateTime dateStart, DateTime dateEnd, RailSection rail, DateTime estimatedDateEnd, Train tram)
            : base(note, dateStart, rail, estimatedDateEnd, tram)
            {

            }
            public Repair(string note, Train tram)
                : base(note, tram)
            {
                
            }

            public Repair(string note, int id, Train tram, bool inprogress)
                : base(note, id,tram, inprogress)
            {

            }

            public Repair(string note, DateTime dateStart,int id, DateTime estimatedDateEnd, Train tram , bool inprogress)
                : base(note, dateStart, id, estimatedDateEnd,tram,inprogress)
            {

            }

            public override string ToString()
            {
                    return this.Tram.ToString();
            }

            /// <summary>
            /// This method adds a repairsman to this action
            /// </summary>
            /// <param name="repairsman"></param>
            /// <returns></returns>
           // public bool AddRepairsman(User repairsman)
            //{
           //     throw new NotImplementedException();
           // }
    }
}
