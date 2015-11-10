using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22DProftaak.General;

namespace S22DProftaak.Action // the references don't work for action, but do for clean/repair.
{
    /// <summary>
    /// This class holds the information about all Clean and Repair actions
    /// </summary>
    public abstract class Action
    {
        public Train Tram;
        public int ID { get; private set; }
        public string Note { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public RailSection Rail { get; private set; }
        public DateTime EstimatedDateEnd { get; private set; }
        public Boolean InProgress { get; private set; }



        public Action(string note, DateTime dateStart, RailSection rail, DateTime estimatedDateEnd, Train tram)
        {
            Tram = tram;
            Note = note;
            DateStart = dateStart;
            estimatedDateEnd = EstimatedDateEnd;
            Rail = rail;
        }
        public Action(string note, Train tram)
        {
            Tram = tram;
            Note = note;

        }
        /// <summary>
        /// Database Constructor
        /// </summary>
        /// <param name="note"></param>
        /// <param name="rail"></param>
        /// <param name="id"> for database </param>
        public Action(string note, int id, Train tram)
        {
            Tram = tram;
            Note = note;
            ID = id;
        }
        /// <summary>
        /// To make the action from the database
        /// </summary>
        /// <param name="note"></param>
        /// <param name="dateStart"></param>
        /// <param name="rail"></param>
        /// <param name="estimatedDateEnd"></param>
        /// <param name="id"> Id for database</param>
        public Action(string note, DateTime dateStart, int id, DateTime estimatedDateEnd, Train tram)
        {
            Tram = tram;
            Note = note;
            DateStart = dateStart;
            estimatedDateEnd = EstimatedDateEnd;

            ID = id;
        }

        public void AddDateEnd(DateTime dateEnd)
        {

            DateEnd = dateEnd;
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

        public bool ChangeInfo(string desc, DateTime EstimatedEndTime)
        {
            Note = desc;
            EstimatedDateEnd = EstimatedEndTime;

            return true;
        }// Changing EndTime

        public bool ActivateAction(DateTime time)
        {
            EstimatedDateEnd = time;
            DateStart = DateTime.Now;
            InProgress = true;
            return true;
        }// TO get them acticated
    }
}
