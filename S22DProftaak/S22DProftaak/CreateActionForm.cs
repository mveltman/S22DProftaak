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
    public partial class CreateActionForm : Form
    {

        RepairSystem.RepairSystem Repair;
        CleanSystem.CleanSystem Clean = new CleanSystem.CleanSystem();
        int status;
        string error = "";
        public CreateActionForm(int check)
        {
            InitializeComponent();
            Repair = new RepairSystem.RepairSystem();

            status = check;
            // When you create the Form give 1 for repair and 2 for clean

        }


        private void CreateActionForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "")
            {
                switch (status)
                {
                    case 1:

                        Repair.CreateRepair(Convert.ToInt32(textBox1.Text), Description.Text, out error);
                        this.Close();
                        break;





                    case 2:

                        Clean.CreateClean(Convert.ToInt32(textBox1.Text), Description.Text);
                        this.Close();



                        break;

                }
            }
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
