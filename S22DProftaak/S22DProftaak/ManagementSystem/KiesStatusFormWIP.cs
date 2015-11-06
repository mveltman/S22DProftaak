using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.ManagementSystem;
using S22DProftaak.Database;

namespace S22DProftaak.ManagementSystem
{
    public partial class KiesStatusFormWIP : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private ManagementSystem ms = new ManagementSystem();
        public KiesStatusFormWIP()
        {
            InitializeComponent();
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            if(this.Statuscbx.SelectedValue != null)
            {

            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
