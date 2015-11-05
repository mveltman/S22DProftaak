using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22DProftaak.General;

namespace S22DProftaak
{
    public partial class Form1 : Form
    {
        private GeneralSystem sys;
        public Form1()
        {
            sys = new GeneralSystem();
            System.Diagnostics.Process.Start("osk.exe");
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(tbLogin.Text, tbPassword.Text))
            {
                throw new NotImplementedException();
                //open new form, hide this form.
                this.Hide();
            }
            // else has been handled in bool Login. Messagebox gets shown already. Should do nothing.
        }

        private bool Login(string name, string password)
        {
            if (sys.Login(name, password)) return true;
            MessageBox.Show(sys.Error);
            return false;
        }
    }
}
