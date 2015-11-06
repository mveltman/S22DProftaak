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

namespace S22DProftaak.General
{
    public partial class EntranceExitForm : Form
    {
        EntranceExit.EntranceExitSystem enExSys;
        GeneralSystem sys = new GeneralSystem();
        List<Train> trains = new List<Train>();
        public EntranceExitForm()
        {
            enExSys = new EntranceExit.EntranceExitSystem();
            InitializeComponent();
            txtRail.Text = "";
            if (enExSys.Error != "")
            {
                MessageBox.Show(enExSys.Error);
                this.Close();
            }
            else
            {
                this.Text = "EntranceExitForm Tram:" + enExSys.CurrenTrain.TramNumber;
            }
        }
        private void btnArrived_Click(object sender, EventArgs e)
        {
            if (!enExSys.MoveTram()) MessageBox.Show(enExSys.Error);
            else
            {
                // here the program checks what cb was checked and opens forms accordingly.
                if (chkClean.Checked)
                {
                    // open clean form forced popup.
                    enExSys.ApplyCleanSession("Todo: repair");
                }
                if (chkRepair.Checked)
                {
                    // open Repair form forced popup.
                    enExSys.ApplyRepairSession("Todo: repair");
                }
            }
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            string pv1,pv2,pv3,pv4;
            if (chkClean.Checked)
            {
                pv1 = Prompt.ShowDialog("Reason:", "Clean Description");
                // open clean form forced popup. todo implement this in actions
                // -- Action.Clean cln = new Action.Clean(promptValue, DateTime.Now, null, "");
                //Action.Clean cln = new Action.Clean(pv1, enExSys.CurrenTrain);
                if (!enExSys.ApplyCleanSession("Todo: repair")) MessageBox.Show(enExSys.Error);
                // TODO: description
            }
            if (chkRepair.Checked)
            {
                pv1 = Prompt.ShowDialog("Reason:", "Repair Description");
                // open Repair form forced popup.

                if (!enExSys.ApplyRepairSession("Todo: repair")) MessageBox.Show(enExSys.Error);
            }
        }
        
    }
}
