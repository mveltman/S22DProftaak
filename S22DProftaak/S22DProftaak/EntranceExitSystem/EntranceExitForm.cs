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
    public partial class EntranceExitForm : Form
    {
        EntranceExit.EntranceExitSystem enExSys = new EntranceExit.EntranceExitSystem();
        List<Train> trains = new List<Train>();
        public EntranceExitForm()
        {
            if (!enExSys.GetTrams(out trains)) UpdateCombobox();
            InitializeComponent();
        }
        private void btnArrived_Click(object sender, EventArgs e)
        {
            enExSys.MoveTram()

            // here the program checks what cb was checked and opens forms accordingly.
            if (cbClean.Checked)
            {

                // open clean form forced popup.
                enExSys.ApplyCleanSession("Todo: repair");
            }
            if (cbRepair.Checked)
            {
                
                // open Repair form forced popup.
                enExSys.ApplyRepairSession("Todo: repair");
            }
        }

        private void btbDescription_Click(object sender, EventArgs e)
        {

        }
        private void UpdateCombobox()
        {
            cbxTram.Items.Clear();
            foreach (Train tr in trains)
            {
                cbxTram.Items.Add(tr);
            }
        } // updates cbxtram 

        private void cbxTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTram.SelectedIndex < 0)
            {

            }
            else
            {
                if (cbxTram.SelectedItem is Train)
                {

                }
            }
        } 
    }
}
