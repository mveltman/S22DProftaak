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
        public bool GetIformation(out List<General.User> list)
        {
            list = new List<General.User>();
            foreach (var item in listBox2.Items)
            {
                list.Add((General.User)item);
            }
            if (list.Count != 0)
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
            ChangeForm Change = new ChangeForm((Action.Action)listBox2.SelectedItem);
            Change.ShowDialog();

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
