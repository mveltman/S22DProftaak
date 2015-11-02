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
using S22DProftaak.ManagementSystem;


namespace S22DProftaak.ManagementSystem
{
    public partial class ManagementForm : Form
    {
        private string oldtext;
        public ManagementForm()
        {
            InitializeComponent();
            
        }
        

        private void ManagementForm_Load(object sender, EventArgs e)
        {

        }



        private void Textbox_MouseDown(object sender, MouseEventArgs e)
        {
            
            RichTextBox currentBox = sender as RichTextBox;
            oldtext = currentBox.Text;
            if(e.Button == MouseButtons.Right)
            {
                //create new prompt here.

            }
            else if(e.Button == MouseButtons.Left)
            {
                currentBox.SelectAll();
            }

            currentBox.SelectAll();
            currentBox.SelectionAlignment = HorizontalAlignment.Center;
            
        }

        private void TextChanged(object sender, EventArgs e)
        {
          
        }



        
       

    }
}
