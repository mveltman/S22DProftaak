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
        DateTime time;
        public bool GetIformation(out List<General.User> list,out DateTime Time)
        {
            list = List;
            Time = time;
           
            if (List.Count != 0)
            {
                return true;
            }else
               return false;
            
        }// If the list is empty the action will not go through
        public AddWorkerForm(string status)
        {
            InitializeComponent();
            RepairSystem.RepairSystem repair = new RepairSystem.RepairSystem();
            CleanSystem.CleanSystem clean = new CleanSystem.CleanSystem();
            List = null;
            if (status == "Repair")
            {
                if (repair.GetWorkers(out List))
                {
                    foreach (var item in List)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
            else if (status == "Clean")
            {
                if (clean.GetWorkers(out List))
                {
                    foreach (var item in List)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
            
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
           foreach (var item in listBox2.Items)
            {
                List.Add((General.User)item);

            }
           time = dateTimePicker1.Value;
           this.Close();
           
           

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
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
