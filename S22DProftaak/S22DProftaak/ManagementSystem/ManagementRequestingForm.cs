using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S22DProftaak.ManagementSystem
{
    public partial class ManagementRequestingForm : Form
    {
        private int trainnumber;
        ManagementSystem mg = new ManagementSystem();
        public ManagementRequestingForm(int trainnumber)
        {
            InitializeComponent();
            this.Trainnumbertbx.Text = Convert.ToString(trainnumber);
        }

        private void Placebtn_Click(object sender, EventArgs e)
        {
            if(this.RailNumbertbx.Text != null || this.RailPositiontbx.Text != null)
            {
                if (mg.CompleteRequest(Convert.ToInt32(this.Trainnumbertbx.Text), Convert.ToInt32(this.RailNumbertbx.Text), Convert.ToInt32(this.RailPositiontbx.Text)))
                {
                    MessageBox.Show("trein succesvol geplaatst");
                }
                this.Close();
                
                    
                
            }
            else
            {
                MessageBox.Show("vul aub de plaats waar de trein moet gaan staan in.");
            }
        }
        private void ManagementRequestingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mg.changeBusyWithRequest = false;
        }

    }
}
