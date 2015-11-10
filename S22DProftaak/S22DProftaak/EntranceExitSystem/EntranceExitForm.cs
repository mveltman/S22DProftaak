using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using S22DProftaak.General;
using System.Timers;
using S22DProftaak.EntranceExitSystem;

namespace S22DProftaak.General
{
    public partial class EntranceExitForm : Form
    {
        EntranceExit.EntranceExitSystem enExSys;
        GeneralSystem sys = new GeneralSystem();
        List<Train> trains = new List<Train>();

        public EntranceExitForm()
        {
            try
            {


                string promptresult = "";
                promptresult = Prompt.ShowDialog("Train: ", "Kies tram");
                enExSys = new EntranceExit.EntranceExitSystem();
                enExSys.ValidateTrainNumber(Convert.ToInt32(promptresult));
                enExSys.AddRequest();
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
            catch(Exception e)
            {
                MessageBox.Show("hello, i am an error.");
            }
        }

        private void btnArrived_Click(object sender, EventArgs e)
        {
            enExSys.HasArrived();
            
            if(chkRepair.Checked)
            {
                if(Actionrtf.Text != null)
                enExSys.ApplyRepairSession(Convert.ToString(Actionrtf.Text));
            }
            else if(chkClean.Checked)
            {
                if(Actionrtf.Text != null)
                enExSys.ApplyCleanSession(Convert.ToString(Actionrtf.Text));
            }
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            CentralScreenEnEx sc = new CentralScreenEnEx();
            sc.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enExSys.GetRequest())
            {
                txtRail.Text = "rail: " + enExSys.TargetTrack.RailNumber.ToString() + " positie:" + enExSys.TargetTrack.Position.ToString();
            }

        }



    }
}
