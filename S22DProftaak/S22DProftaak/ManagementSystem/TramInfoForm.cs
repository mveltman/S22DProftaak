using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.Database;
using S22DProftaak.General;

namespace S22DProftaak.ManagementSystem
{
    public partial class TramInfoForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private ManagementSystem ms = new ManagementSystem();
        private List<Train> trains = new List<Train>();
        public TramInfoForm()
        {
            InitializeComponent();
        }

        private void TrainNumbertsb_Click(object sender, EventArgs e)
        {
            //sort by trainnumber
        }

        private void Typetsb_Click(object sender, EventArgs e)
        {
            //sort by type
        }

        private void Railtsb_Click(object sender, EventArgs e)
        {
            //sort by rail
        }

        private void RailSectiontsb_Click(object sender, EventArgs e)
        {
            //sort by railsection
        }

        private void Refreshtsb_Click(object sender, EventArgs e)
        {
            TrainInfolbx.Items.Clear();
            ms.GetdbTrains();
            trains = ms.GetTrains;
            string infoboxstring;
            foreach(Train t in trains)
            {
                infoboxstring = t.TramNumber + "     " + t.Model + "   " + t.BuildYear + "   ";
                    TrainInfolbx.Items.Add(infoboxstring);
               // infoboxstring = t.TramNumber + "   "+ t.Model + "   "  
               // TrainInfolbx.Items.Add(infoboxstring)
            }
        }
    }
}
