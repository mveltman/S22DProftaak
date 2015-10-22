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
    public class Clean : Action
    {
        public Clean(string note, DateTime dateStart, DateTime dateEnd, RailSection rail)
            : base(note, dateStart, dateEnd, rail)
        {

        }

        ///// <summary>
        ///// This method adds a cleaner to this action
        ///// </summary>
        ///// <param name="cleaner"></param>
        ///// <returns></returns>
        //public bool AddCleaner(User cleaner)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
