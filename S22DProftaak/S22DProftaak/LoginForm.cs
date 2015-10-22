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
    public partial class LoginForm : Form
    {
        private GeneralSystem sys = new GeneralSystem();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckPassword(tbLogin.Text, tbPassword.Text))
            {
                throw new NotImplementedException();
                this.Hide();
            }
        }
        private bool CheckPassword(string userName, string password)
        {
            string error="";
            if (!sys.Login(userName, password, out error)) MessageBox.Show(error);
            else return true; 
            return false;
        } // if either login or password is false, retursn false and shows an error. Otherwise it updates the logged user and returns true.
    }
}
