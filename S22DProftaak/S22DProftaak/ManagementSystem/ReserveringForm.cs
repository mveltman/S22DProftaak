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
            if (ms.ValidateNewInput(Convert.ToInt32(TrainNumberrtf.Text)))
            {
                if (ms.ValidateRailNr(Convert.ToInt32(Railnumberrtf.Text)) && ms.ValidateRailposition(Convert.ToInt32(Railnumberrtf.Text), Convert.ToInt32(rtfRailPosition.Text)))
                {
                    if (Repaircbx.Checked == true)
                    {
                        if (ms.AddReserveration(new Reservering(Convert.ToInt32(this.Railnumberrtf.Text), Convert.ToInt32(this.rtfRailPosition.Text), Convert.ToInt32(this.TrainNumberrtf.Text)))) MessageBox.Show("reservering succesvol toegevoegd");
                        db.GetOneTrainInfo(Convert.ToInt32(this.TrainNumberrtf.Text), out this.t, out this.error);
                        db.CreateActionRepair(new Repair("Auto Generated Repair by manager", t), out error);
                    }
                    else
                    {
                        if (ms.AddReserveration(new Reservering(Convert.ToInt32(this.Railnumberrtf.Text), Convert.ToInt32(this.rtfRailPosition.Text), Convert.ToInt32(this.TrainNumberrtf.Text)))) MessageBox.Show("reservering succesvol toegevoegd");
                        
                    }
                }
            }

        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
