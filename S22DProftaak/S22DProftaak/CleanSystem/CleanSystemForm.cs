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
    public partial class CleanSystemForm : Form
    {
        public string error = "";
        CleanSystem.CleanSystem Clean = new CleanSystem.CleanSystem();
        public void UpdateTasks()
        {
            List<Action.Clean> repairlist = new List<Action.Clean>();

            if (Clean.GetCleanTasks())
            {

                CleanInProgress.Items.Clear();
                CleanAssignments.Items.Clear();
                foreach (Action.Clean pair in Clean.cleanlist)
                {
                    if (pair.InProgress)
                    {
                        CleanInProgress.Items.Add(pair);
                    }
                    else
                    {
                        CleanAssignments.Items.Add(pair);
                    }

                }
            }// Om na alle veranderingen dingen aan te passen in de lists

        }
        public CleanSystemForm()
        {
            InitializeComponent();
            UpdateTasks();
            RefreshCleanTasks.Start();
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            if (CleanAssignments.SelectedItem != null)
            {
                RefreshCleanTasks.Stop();
                using (AddWorkerForm Work = new AddWorkerForm("Clean"))
                {

                    Work.ShowDialog();
                    List<General.User> list = new List<General.User>();
                    DateTime Time = DateTime.Now;
                    if (Work.GetIformation(out list, out Time))
                    {
                        Clean.ApplyCleanSession((Action.Clean)CleanAssignments.SelectedItem, list, Time);
                    }// List of users who work on a particular action
                    else
                    {
                        MessageBox.Show("No Workers selected");
                    }// aplying the session with a estimated date and 

                }
                RefreshCleanTasks.Start();
                UpdateTasks();
                CleanDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }
        }

        private void CleanAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CleanAssignments.SelectedItem != null)
            {
                Action.Clean act = (Action.Clean)CleanAssignments.SelectedItem;
                CleanDescription.Text = act.Note;

            }

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            RefreshCleanTasks.Stop();
            using (CreateActionForm Information = new CreateActionForm(2))
            {
                Information.ShowDialog();
            }
            UpdateTasks();
            RefreshCleanTasks.Start();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (CleanInProgress.SelectedItem != null)
            {
                Clean.SetEndTime((Action.Clean)CleanInProgress.SelectedItem, out error);
                Clean.Redo((Action.Clean)CleanInProgress.SelectedItem, out error);
                UpdateTasks();
                CleanDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (CleanInProgress.SelectedItem != null)
            {
                RefreshCleanTasks.Stop();
                ChangeForm Change = new ChangeForm((Action.Clean)CleanInProgress.SelectedItem);
                Change.ShowDialog();
                Clean.UpdateCleaned(Change.CAct, Change.desc, Change.Time, out error);
                UpdateTasks();

                RefreshCleanTasks.Start();
            }
            else
            {
                MessageBox.Show("Choose Your Selection");
            }
        }

        private void RefreshCleanTasks_Tick(object sender, EventArgs e)
        {
            UpdateTasks();
        }

        private void CleanInProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CleanInProgress.SelectedItem != null)
                {


                    Action.Clean act = (Action.Clean)
                      CleanInProgress.SelectedItem;
                    CleanDescription.Text = act.Note;
                }


            }
            catch
            {
                CleanDescription.Text = "Error!!";
            }

        }
    }
}
