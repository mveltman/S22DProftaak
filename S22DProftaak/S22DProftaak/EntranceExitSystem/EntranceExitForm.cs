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
                else this.Text = "EntranceExitForm Tram:" + enExSys.CurrenTrain.TramNumber;
            }
            catch { MessageBox.Show("Creation of this form has failed."); }
        }
        private void btnArrived_Click(object sender, EventArgs e)
        {
            enExSys.HasArrived();

            if (chkRepair.Checked)
            {
                if (Actionrtf.Text != null)
                    if (!enExSys.ApplyRepairSession(Convert.ToString(Actionrtf.Text)))
                        MessageBox.Show(enExSys.Error);
            }
            else if (chkClean.Checked)
            {
                if (Actionrtf.Text != null)
                    if (!enExSys.ApplyCleanSession(Convert.ToString(Actionrtf.Text)))
                        MessageBox.Show(enExSys.Error);
            }
        }// this button shows the driver has arrived with the tram.

        private void btnDescription_Click(object sender, EventArgs e)
        {
            CentralScreenEnEx sc = new CentralScreenEnEx();
            sc.Show();
        } // this button shows the description and map of the remise in question.
        #region backgroundworker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(2000);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (enExSys.GetRequest())
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //hello im useless
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enExSys.GetRequest())
            {
                txtRail.Text = "rail: " + enExSys.TargetTrack.RailNumber.ToString() + " positie:" + enExSys.TargetTrack.Position.ToString();
            }
        }// this void times events to update the textbox viewing the destination.



    }
}
