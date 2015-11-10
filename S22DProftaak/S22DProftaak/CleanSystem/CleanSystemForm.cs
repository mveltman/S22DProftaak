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
        CleanSystem.CleanSystem Clean = new CleanSystem.CleanSystem();
        public void UpdateTasks()
        {
            List<Action.Action> repairlist = new List<Action.Action>();

            if (Clean.GetCleanTasks(out repairlist))
            {

                foreach(Action.Action pair in repairlist)
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
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {

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
        }

        private void CleanAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (CreateActionForm Information = new CreateActionForm(2))
            {
                Information.ShowDialog();
            }
            UpdateTasks();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Clean.SetEndTime((Action.Action)CleanInProgress.SelectedItem);
            UpdateTasks();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            using (ChangeForm Change = new ChangeForm((Action.Action)CleanInProgress.SelectedItem))
            {
                Change.ShowDialog();
                Clean.UpdateCleaned(Change.Act, Change.desc, Change.Time);
                UpdateTasks();
            }
        }
    }
}
