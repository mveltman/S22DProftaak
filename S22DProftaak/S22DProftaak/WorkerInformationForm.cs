using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.CleanSystem;
using S22DProftaak.RepairSystem;


namespace S22DProftaak.RepairSystem
{
    public partial class WorkerInformationForm : Form
    {
        private string _action;
        private string _username;
        private RepairSystem repsys = new RepairSystem();
        private CleanSystem.CleanSystem cleansys = new CleanSystem.CleanSystem();
        private Action.Action selectedaction;
        private Database.DatabaseConnection db = new Database.DatabaseConnection();
        public int _railnumber;
        public int _railposition;
        public string _error = "";
        public WorkerInformationForm(string action, string username)
        {
            InitializeComponent();
            this._action = action;
            this._username = username;
        }

        private void Updatetaskstimer_Tick(object sender, EventArgs e)
        {
            Assignmentslbx.Items.Clear();
            if(_action == "Repair")
            {
                repsys.GetRepairTasks(_username);
                if(repsys.repairlist != null)
                {
                    foreach(Action.Action a in repsys.repairlist)
                    {
                        Assignmentslbx.Items.Add(("Notitie: " + a.Note.ToString() + " Status: " + a.InProgress.ToString() + " Tramnummer: " + a.Tram.TramNumber.ToString()));
                    }
                }
                else
                {
                    Assignmentslbx.Items.Add("no tasks available");
                }
            }
            if(_action == "Clean")
            {
                cleansys.GetCleanTasks(_username);
                if(cleansys.cleanlist != null)
                {
                    foreach(Action.Action a in cleansys.cleanlist)
                    {
                        Assignmentslbx.Items.Add(a.Note.ToString());
                    }
                }
                else
                {
                    Assignmentslbx.Items.Add("no tasks available");
                }
            }
        }

        private void Assignmentslbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_action == "Repair")
            {
                if (Assignmentslbx.SelectedItem != null)
                {
                    if (Assignmentslbx.SelectedItem.ToString() != "no tasks available")
                    {
                        selectedaction = repsys.repairlist[Assignmentslbx.SelectedIndex];
                        WorkDescriptionrtf.Text = ("Notitie: " + selectedaction.Note.ToString() + " Status: " + selectedaction.InProgress.ToString() + " Tramnummer: " + selectedaction.Tram.TramNumber.ToString());
                    }
                }

                
            }
            if(_action == "Clean")
            {
                if (Assignmentslbx.SelectedItem != null)
                {
                    if (Assignmentslbx.SelectedItem.ToString() != "no tasks available")
                    {
                        selectedaction = cleansys.cleanlist[Assignmentslbx.SelectedIndex];
                        WorkDescriptionrtf.Text = ("Notitie: " + selectedaction.Note.ToString() + " Status: " + selectedaction.InProgress.ToString() + " Tramnummer: " + selectedaction.Tram.TramNumber.ToString());
                    }
                }
             }
            if(Assignmentslbx.SelectedItem != null)
            {
                if(Assignmentslbx.SelectedItem.ToString() != "no tasks available")
                {
                    db.GetTrainLocation(selectedaction.Tram.TramNumber, out _railnumber, out _railposition, out this._error);
                        
                        Spoorrtf.Text = Convert.ToString(_railnumber);
                        sectorrtf.Text = Convert.ToString(_railposition);
                        Spoorrtf.SelectAll();
                        Spoorrtf.SelectionAlignment = HorizontalAlignment.Center;
                        sectorrtf.SelectAll();
                        sectorrtf.SelectionAlignment = HorizontalAlignment.Center;
                    
                }
            }
        }

    }
}
