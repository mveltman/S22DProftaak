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
        public bool GetIformation(out List<General.User> list)
        {
            list = List;
           
            if (List.Count != 0)
            {
                return true;
            }else
               return false;
            
        }
        public AddWorkerForm()
        {
            InitializeComponent();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
           foreach (var item in listBox2.Items)
            {
                List.Add((General.User)item);
            }
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
    }
}
