using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.General;

namespace S22DProftaak.EntranceExitSystem
{
    public partial class CentralScreenEnEx : Form
    {
        EntranceExit.EntranceExitSystem enexSys = new EntranceExit.EntranceExitSystem();
        GeneralSystem sys = new GeneralSystem();
        public CentralScreenEnEx()
        {
            InitializeComponent();
            if (enexSys.GetTrams())
            {
                foreach (Train t in enexSys.Trains)
                {
                    lbxTrams.Items.Add(t.TramNumber);
                }
            }
        }
    }
}
