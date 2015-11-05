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

namespace S22DProftaak
{
    public partial class RepairSystemForm : Form
    {
        public RepairSystem.RepairSystem repair;

        public void UpdateTasks() 
        { 
            List<Action.Repair> repairlist = new List<Action.Repair>();
            if (repair.GetRepairTasks(out repairlist, true))
            {

                foreach (Action.Repair pair in repairlist)
                { 
                    if(pair.InProgress)
                    {
                        RepairInProgress.Items.Add(pair);
                    }
                    else
                    {
                        RepairAssignments.Items.Add(pair);
                    }
                    
                }
            }// Om na alle veranderingen dingen aan te passen in de lists

        }

       
        public RepairSystemForm()
        {
            InitializeComponent();
            repair = new RepairSystem.RepairSystem();
            UpdateTasks(); 
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (CreateActionForm Information = new CreateActionForm(1))
            {
                Information.ShowDialog();
            }

        }

        private void RepairAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepairDescription.Text = RepairAssignments.SelectedItem.ToString(); 
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {

        }

        private void RepairButton_Click(object sender, EventArgs e)
        {

            using (AddWorkerForm Work = new AddWorkerForm())
            {

                Work.ShowDialog();
                List<General.User> list = new List<General.User>();
                if (Work.GetIformation(out list))
                {
                    repair.ApplyRepairSession((Action.Repair)RepairAssignments.SelectedItem, list, DateTime.Now);
                }
                else
                {
                    MessageBox.Show("No Workers selected");
                }

            }
           

        }
    }
}
