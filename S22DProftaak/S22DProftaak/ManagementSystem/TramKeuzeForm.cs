using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S22DProftaak.ManagementSystem
{
    public partial class TramKeuzeForm : Form
    {
        ManagementSystem mg = new ManagementSystem();
        public TramKeuzeForm()
        {
            InitializeComponent();
        }

        private void btnPlaatsTram_Click(object sender, EventArgs e)
        {
            if (mg.ValidateRailNr(Convert.ToInt32(rtfRailNumber.Text)))
            {
                if (mg.ValidateRailposition(Convert.ToInt32(rtfRailNumber), Convert.ToInt32(rtfRailPosition)))
                {
                    if (mg.ValidateNewInput(Convert.ToInt32(rtfTrainNumber.Text)))
                    { 
                        mg.PlaceTrain(Convert.ToInt32(rtfTrainNumber.Text), Convert.ToInt32(rtfRailNumber.Text), Convert.ToInt32(rtfRailPosition)); 
                    }
                }
            }
        }
    }
}
