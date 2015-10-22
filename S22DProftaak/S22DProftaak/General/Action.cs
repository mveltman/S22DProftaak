using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;

namespace S22DProftaak.Action // the references don't work for action, but do for clean/repair. This is ultimately strange.
{
    /// <summary>
    /// This class holds the information about all Clean and Repair actions
    /// </summary>
    public abstract class Action
    {
        public string Note { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public RailSection Rail { get; private set; }


        public Action(string note, DateTime dateStart, DateTime dateEnd, RailSection rail)
        {
            Note = note;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Rail = rail;
        }

        /// <summary>
        /// This method sets the enddate from an action when the action has finished
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool AddEndDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The selected tram will be moved to another rail when the required action has been finished
        /// </summary>
        /// <param name="rail"></param>
        /// <returns></returns>
        public bool MoveTram(Rail rail)
        {
            throw new NotImplementedException();
        }


        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        } // Adds User to the action
    }
}
