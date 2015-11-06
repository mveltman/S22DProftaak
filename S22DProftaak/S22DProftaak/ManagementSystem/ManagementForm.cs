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
        private ManagementSystem mg = new ManagementSystem();
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
                ContextMenuStrip cms = new ContextMenuStrip();
                ToolStripMenuItem cmsBlock = new ToolStripMenuItem("Block");
                cmsBlock.Click += new EventHandler(cmsBlock_Click);

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
            if (mg.ValidateNewInput(sender))
            {

            }
            else
            {
                RichTextBox currentbox = sender as RichTextBox;
                
            }

        } 
  
        private void cmsBlock_Click(object sender, EventArgs e)
        {
            //Rail57Pos1rtf
            RichTextBox selectedbox = sender as RichTextBox;
            string fullrailname = selectedbox.Name;
            string railnumber = Convert.ToString(fullrailname[4]) + Convert.ToString(fullrailname[5]);
            string railPosition = Convert.ToString(fullrailname[9]);
            if(Convert.ToString(fullrailname[10]) != "r")
            {
                railPosition += Convert.ToString(fullrailname[10]);
            }
            RailSection deconstructedNameString = new RailSection(Convert.ToInt32(railPosition)/*, Convert.ToInt32(railnumber)*/);
            mg.BlockRail(deconstructedNameString);
        }
    }
}
