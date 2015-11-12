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
        public RepairSystem.RepairSystem repair = new RepairSystem.RepairSystem();
        public string error = "";
        public void UpdateTasks()
        {
            List<Action.Repair> repairlist = new List<Action.Repair>();

            if (repair.GetRepairTasks())
            {
                RepairInProgress.Items.Clear();
                RepairAssignments.Items.Clear();
                foreach (Action.Repair pair in repair.repairlist)
                {
                    if (pair.InProgress)
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
            UpdateTasks();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RepairInProgress.SelectedItem != null)
            {
                timer1.Stop();
                using (ChangeForm Change = new ChangeForm((Action.Repair)RepairInProgress.SelectedItem))
                {
                    Change.ShowDialog();
                    repair.UpdateRepaired(Change.Act, Change.desc, Change.Time, out error);
                    UpdateTasks();
                }
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }


        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            using (CreateActionForm Information = new CreateActionForm(1))
            {
                Information.ShowDialog();
            }
            UpdateTasks();
            timer1.Start();

        }

        private void RepairAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RepairAssignments.SelectedItem != null)
                {
                    Action.Repair act = (Action.Repair)RepairAssignments.SelectedItem;
                    RepairDescription.Text = act.Note;
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (RepairInProgress.SelectedItem != null)
            {
                repair.SetEndTime((Action.Repair)RepairInProgress.SelectedItem, out error);
                repair.Redo((Action.Repair)RepairInProgress.SelectedItem, out error);
                UpdateTasks();
                RepairDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }

        }

        private void RepairButton_Click(object sender, EventArgs e)
        {
            if (RepairAssignments.SelectedItem != null)
            {
                using (AddWorkerForm Work = new AddWorkerForm("Repair"))
                {
                    timer1.Stop();
                    Work.ShowDialog();
                    List<General.User> list = new List<General.User>();
                    DateTime Time = DateTime.Now;
                    if (Work.GetIformation(out list, out Time))
                    {
                        repair.ApplyRepairSession((Action.Repair)RepairAssignments.SelectedItem, list, Time, out error);
                    }// List of users who work on a particular action
                    else
                    {
                        MessageBox.Show("No Workers selected");
                    }// aplying the session with a estimated date and 

                }
                UpdateTasks();
                timer1.Start();
                RepairDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTasks();
        }

        private void RepairInProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepairInProgress.SelectedItem != null)
            {
                Action.Repair act = (Action.Repair)
                RepairInProgress.SelectedItem;
                RepairDescription.Text = act.Note;
            }

        }
    }
}
