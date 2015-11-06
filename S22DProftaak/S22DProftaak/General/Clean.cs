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
        public Clean(string note, DateTime dateStart, DateTime dateEnd, 
            RailSection rail, DateTime estimatedDateEnd, Train train)
            : base(note, rail, train)
        {
            throw new NotImplementedException();
        }
        public Clean(string note, DateTime dateStart, DateTime dateEnd, RailSection rail, DateTime estimatedDateEnd, Train tram)
            : base(note, dateStart, rail, estimatedDateEnd, tram)
            {

            }
            public Clean(string note, Train tram)
                : base(note, tram)
            {
                
            }

            public Clean(string note, int id, Train tram)
                : base(note, id,tram)
            {

            }

            public Clean(string note, DateTime dateStart,int id, DateTime estimatedDateEnd, Train tram )
                : base(note, dateStart, id, estimatedDateEnd,tram)
            {

            }

            public override string ToString()
            {
                return this.Tram.ToString();
            }

        /// <summary>
        /// This method adds a cleaner to this action
        /// </summary>
        /// <param name="cleaner"></param>
        /// <returns></returns>
       // public bool AddCleaner(User cleaner)
       // {
        //    throw new NotImplementedException();
        //}
    }
}
