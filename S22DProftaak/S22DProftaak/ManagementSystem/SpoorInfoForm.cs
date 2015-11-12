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
    public partial class SpoorInfoForm : Form
    {
        ManagementSystem mg = new ManagementSystem();
        public SpoorInfoForm()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            if (rtfRailnumber.Text != "")
                if (mg.ValidateRailNr(Convert.ToInt32(rtfRailnumber.Text)))
                    if (mg.GetRailInfo(Convert.ToInt32(rtfRailnumber.Text)))
                    {
                        lbxRailInfo.Items.Clear();
                        foreach (string s in mg.RailInfoStrings)
                        {
                            lbxRailInfo.Items.Add(s);
                        }
                    }
                    
        }
    }
}
