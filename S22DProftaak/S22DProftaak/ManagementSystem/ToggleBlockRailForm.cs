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
    public partial class ToggleBlockRailForm : Form
    {
        ManagementSystem ms = new ManagementSystem();
        public ToggleBlockRailForm()
        {
            InitializeComponent();
        }

        private void btnToggleBlock_Click(object sender, EventArgs e)
        {
            if(ms.ValidateRailNr(Convert.ToInt32(rtfRailNumber.Text)))
            {
                if(ms.ValidateRailposition(Convert.ToInt32(rtfRailNumber.Text),Convert.ToInt32(rtfRailPosition.Text)))
                {
                    ms.BlockRail(new General.RailSection(Convert.ToInt32(rtfRailNumber), Convert.ToInt32(rtfRailPosition.Text), false));
                }
            }
        }


    }
}
