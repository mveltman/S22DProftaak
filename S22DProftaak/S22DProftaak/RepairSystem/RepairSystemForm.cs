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
            List<Action.Action> repairlist = new List<Action.Action>();
           
            if (repair.GetRepairTasks(out repairlist))
            {

                foreach (Action.Action pair in repairlist)
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
            using (ChangeForm Change = new ChangeForm((Action.Action)RepairInProgress.SelectedItem)) 
            {
                Change.ShowDialog();
                repair.UpdateRepaired(Change.Act,Change.desc, Change.Time);
                UpdateTasks(); 
            }
            
            
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (CreateActionForm Information = new CreateActionForm(1))
            {
                Information.ShowDialog();
            }
            UpdateTasks();

        }

        private void RepairAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action.Action act =  (Action.Action)RepairAssignments.SelectedItem;
            RepairDescription.Text = act.Note; 
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            repair.SetEndTime((Action.Action)RepairInProgress.SelectedItem);
            UpdateTasks();

        }

        private void RepairButton_Click(object sender, EventArgs e)
        {

            using (AddWorkerForm Work = new AddWorkerForm("Repair"))
            {

                Work.ShowDialog();
                List<General.User> list = new List<General.User>();
                DateTime Time = DateTime.Now;
                if (Work.GetIformation(out list,out Time))
                {
                    repair.ApplyRepairSession((Action.Repair)RepairAssignments.SelectedItem, list, Time);
                }// List of users who work on a particular action
                else
                {
                    MessageBox.Show("No Workers selected");
                }// aplying the session with a estimated date and 

            }
           

        }
    }
}
