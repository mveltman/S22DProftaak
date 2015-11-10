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
                //backgroundWorker1 = new BackgroundWorker();
                //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                //backgroundWorker1.RunWorkerAsync();
                //backgroundWorker1_DoWork(backgroundWorker1, new DoWorkEventArgs(backgroundWorker1));
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
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            CentralScreenEnEx sc = new CentralScreenEnEx();
            sc.Show();
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enExSys.GetRequest())
            {
                txtRail.Text = "rail: " + enExSys.TargetTrack.RailNumber.ToString() + " positie:" + enExSys.TargetTrack.Position.ToString();
            }

        }



    }
}
