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
            public Repair(string note, DateTime dateStart, DateTime dateEnd, RailSection rail)
                : base(note, dateStart, dateEnd, rail)
            {

            }

            ///// <summary>
            ///// This method adds a repairsman to this action
            ///// </summary>
            ///// <param name="repairsman"></param>
            ///// <returns></returns>
            //public bool AddRepairsman(User repairsman)
            //{
            //    throw new NotImplementedException();
            //}
    }
}
