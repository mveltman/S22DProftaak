using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.RepairSystem;
using S22DProftaak.Action;
using S22DProftaak.Database;

namespace S22DProftaak.ManagementSystem
{
    public partial class ReserveringForm : Form
    {
        private ManagementSystem ms = new ManagementSystem();
        private DatabaseConnection db = new DatabaseConnection();
        private General.Train t;
        private string error = "";
        
        public ReserveringForm()
        {
            InitializeComponent();
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            if(Repaircbx.Checked == true)
            {
               // ms.AddReservation((Convert.ToInt32(this.Railnumberrtf.Text), Convert.ToInt32(this.TrainNumberrtf.Text));
                db.GetOneTrainInfo(Convert.ToInt32(this.TrainNumberrtf.Text), out this.t, out this.error);
                //ms.ApplyForAction(new Action.Repair("no note", new General.RailSection(1, Convert.ToInt32(this.Railnumberrtf),false), t));
            }
           // ms.AddReservation((Convert.ToInt32(this.Railnumberrtf.Text), Convert.ToInt32(this.TrainNumberrtf.Text));
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
