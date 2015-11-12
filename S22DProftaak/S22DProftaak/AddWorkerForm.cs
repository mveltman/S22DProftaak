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
    public partial class AddWorkerForm : Form
    {
        List<General.User> List;
        List<General.User> List2 = new List<General.User>();
        public string error = "";
        DateTime time;

        public AddWorkerForm(string status)
        {
            InitializeComponent();
            RepairSystem.RepairSystem repair = new RepairSystem.RepairSystem();
            CleanSystem.CleanSystem clean = new CleanSystem.CleanSystem();
            List = null;
            if (status == "Repair")
            {
                if (repair.GetWorkers(out List, out error))
                {
                    foreach (General.User item in List)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
            else if (status == "Clean")
            {
                if (clean.GetWorkers(out List, out error))
                {
                    foreach (General.User item in List)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        public bool GetIformation(out List<General.User> list, out DateTime Time)
        {
            list = List2;
            Time = time;

            if (List.Count != 0)
            {
                return true;
            }
            else
                return false;

        }// If the list is empty the action will not go through


        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (listBox2.Items != null)
            {
                foreach (var item in listBox2.Items)
                {

                    List2.Add((General.User)item);

                }
                time = dateTimePicker1.Value;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select workers");
            }



        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Contain()
        {
            General.User usr = (General.User)listBox1.SelectedItem;
            foreach (var item in listBox2.Items)
            {
                General.User usr2 = (General.User)item;
                if (usr2.UserName == usr.UserName)
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {


                if (Contain())
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                }




            }
            else
            {
                MessageBox.Show("Select worker please");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
