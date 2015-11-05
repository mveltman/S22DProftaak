using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S22DProftaak
{
    public partial class CreateActionForm : Form
    {
        List<General.RailSection> RailList;
        RepairSystem.RepairSystem Repair;
        int status;
        public CreateActionForm(int check)
        {
            InitializeComponent();
            Repair = new RepairSystem.RepairSystem();
            status = check;
            // When you create the Form give 1 for repair and 2 for clean

        }
        

        private void CreateActionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
      

            switch (status)
            {
                case 1: 
                    Repair.CreateRepair(Convert.ToInt32(RailTb.Text),Convert.ToInt32(SectorTb.Text), Description.Text);
             this.Close();
                 break;
               
                
 
            
                    
                case 2: 
                        RailList = new List<General.RailSection>();
            foreach (General.RailSection rail in RailList)
            {
                if (rail.RailNumber == Convert.ToInt32(RailTb.Text) && rail.Position == Convert.ToInt16( SectorTb.Text)) 
                {  
                    General.Train train;
                    if (Repair.GetTramSpoor(out train, Convert.ToInt32(RailTb.Text), Convert.ToInt32(SectorTb.Text)))
                    {
                        Action.Repair action = new Action.Repair(Description.Text, rail, train); // Get tram on specified rail
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Not a valid Place");
                    }
                    // To Database
                }
               
                
 
            }
                    break;
                    
            }
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            
        

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
