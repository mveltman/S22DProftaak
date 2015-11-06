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
            Loginbtn();
        }
        private void Loginbtn()
        {
            if (Login(tbLogin.Text, tbPassword.Text))
            {
                MessageBox.Show("U bent ingelogd als " + sys.GetLoggedUser.UserName + sys.GetLoggedUser.Type.ToString());
                //throw new NotImplementedException();
                //open new form, hide this form.
                UserTypeEnum enm = sys.GetLoggedUser.Type;
                if (enm == UserTypeEnum.Admin)
                {
                    using (ManagementSystem.ManagementForm opnForm = new ManagementSystem.ManagementForm())
                    {
                        opnForm.Show();
                    }

                }
                else if (enm == UserTypeEnum.Repairsman)
                {
                    using (ManagementSystem.ManagementForm opnForm = new ManagementSystem.ManagementForm())
                    {
                        opnForm.Show();
                    }
                }
                else if (enm == UserTypeEnum.Driver)
                {
                    using (ManagementSystem.ManagementForm opnForm = new ManagementSystem.ManagementForm())
                    {
                        opnForm.Show();
                    }
                }
                else if (enm == UserTypeEnum.Cleaner)
                {
                    using (ManagementSystem.ManagementForm opnForm = new ManagementSystem.ManagementForm())
                    {
                        opnForm.Show();
                    }
                }
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

        private void tbLogin_Enter(object sender, EventArgs e)
        {
            Loginbtn();
        }
    }
}
