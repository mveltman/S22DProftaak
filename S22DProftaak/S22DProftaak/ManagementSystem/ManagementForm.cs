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
using System.Threading;



namespace S22DProftaak.ManagementSystem
{
    public partial class ManagementForm : Form
    {
        private string oldtext;
        private ManagementSystem mg = new ManagementSystem();
        private RichTextBox selectedbox;
        public ManagementForm()
        {
            InitializeComponent();  
        }
        

        private void ManagementForm_Load(object sender, EventArgs e)
        {

        }



        private void Textbox_MouseDown(object sender, MouseEventArgs e)
        {
            
             selectedbox = sender as RichTextBox;
            oldtext = selectedbox.Text;
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                ToolStripMenuItem cmsBlock = new ToolStripMenuItem("Block");
                cms.Items.Add(cmsBlock);
                cmsBlock.Click += new EventHandler(cmsBlock_Click);
                cms.Show(System.Windows.Forms.Control.MousePosition);    
            }
            else if(e.Button == MouseButtons.Left)
            {
                selectedbox.SelectAll();
            }

            selectedbox.SelectAll();
            selectedbox.SelectionAlignment = HorizontalAlignment.Center;
            
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (mg.ValidateNewInput(sender))
            {
                selectedbox = sender as RichTextBox;
                int railnumber;
                int railposition;
                DeconstructObjectName(selectedbox.Name, out railnumber, out railposition);
                mg.CheckRailStatus(railnumber, railposition);
                if(!mg.RailStatus)
                {
                    if (!mg.PlaceTrain(Convert.ToInt32(selectedbox.Text), Convert.ToInt32(railnumber), Convert.ToInt32(railposition))) MessageBox.Show(mg.Error);
                    Checkrtfnames(Convert.ToInt32(selectedbox.Text));
                }
                
            }
           

        } 
  
        private void cmsBlock_Click(object sender, EventArgs e)
        {

            
            string fullrailname = selectedbox.Name;
            string railnumber = Convert.ToString(fullrailname[4]) + Convert.ToString(fullrailname[5]);
            string railPosition = Convert.ToString(fullrailname[9]);
            if(Convert.ToString(fullrailname[10]) != "r")
            {
                railPosition += Convert.ToString(fullrailname[10]);
            }
            
             RailSection deconstructedNameString = new RailSection(Convert.ToInt32(railPosition), Convert.ToInt32(railnumber), true);
             mg.BlockRail(deconstructedNameString);
             mg.CheckRailStatus(Convert.ToInt32(railnumber), Convert.ToInt32(railPosition));
            if(mg.RailStatus)
            {
                selectedbox.BackColor = Color.LightGray;
                selectedbox.ReadOnly = true;
            }
            else
            {
                selectedbox.BackColor = Color.White;
                selectedbox.ReadOnly = false;
            }
        }

        private void traminfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TramInfoForm tif = new TramInfoForm();
            tif.Show();
        }

        private void statusKiezenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("will be implemented at a later date");
        }

        private void reserveringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReserveringForm rsf = new ReserveringForm();
            rsf.Show();
        }

        private void kiesTramnummerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           TramKeuzeForm tkf = new TramKeuzeForm();
           tkf.Show();
        }

        private void blokkerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleBlockRailForm tbrf = new ToggleBlockRailForm();
            tbrf.Show();
        }

        private void spoorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpoorInfoForm sif = new SpoorInfoForm();
            sif.Show();
        }

        private void schoonmaakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanSystemForm csf = new CleanSystemForm();
            csf.Show();
        }

        private void Repairtsdd_Click(object sender, EventArgs e)
        {
            RepairSystemForm rsf = new RepairSystemForm();
            rsf.Show();
        }

        private void Exittsdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckForRequestsTmr_Tick(object sender, EventArgs e)
        {
            if(mg.Reserveringen.Count > -1)
            {
                Reserveringenlbx.Items.Clear();
                foreach (Reservering r in mg.Reserveringen)
                {
                    Reserveringenlbx.Items.Add(Convert.ToString(r.TrainNumber));
                }
            }

            mg.CheckRequests();
            //if(mg.CheckArrived())
        }

        private void DeconstructObjectName(string objectname, out int railnumber, out int railposition)
        {
            railnumber = -1;
            railposition = -1;
            try
            {
               railnumber = Convert.ToInt32(objectname.Substring(4, 2));
                if(objectname.Substring(10,1) != "r")
                {
                    railposition = Convert.ToInt32(objectname.Substring(10, 2));
                }
                else
                {
                    railposition = Convert.ToInt32(objectname.Substring(9,1));
                }
                
            }
            catch(Exception e)
            {

            }
        }

        private void Checkrtfnames(int checkablenumber)
        {
            foreach(Control c in this.Controls)
            {
                if (c is RichTextBox)
                {
                    if(c.Name.Length > 9)
                    if(c.Text != "")

                    if (Convert.ToInt32(c.Text) == checkablenumber)
                    {
                        if(c != selectedbox)
                        c.Text = "";
                    }
                    else c.Text = "";
                }
                
            }
        }

        private void SpoorInsertrtf_TextChanged(object sender, EventArgs e)
        {
            if(TramInsertrtf.Text != null)
            {
                if(mg.ValidateRailNr(Convert.ToInt32(SpoorInsertrtf.Text)))
                {
                    if(mg.ValidateNewInput(Convert.ToInt32(TramInsertrtf.Text)))
                    {
                        Checkrtfnames(Convert.ToInt32(TramInsertrtf.Text));
                        mg.PlaceTrain(Convert.ToInt32(TramInsertrtf.Text), Convert.ToInt32(SpoorInsertrtf.Text), 1);
                        string test = "Rail" + SpoorInsertrtf.Text + "Pos1rtf";
                        foreach(Control c in this.Controls)
                        {
                            if(c.Name == test)
                            {
                                c.Text = TramInsertrtf.Text;
                                SpoorInsertrtf.Text = "";
                                TramInsertrtf.Text = "";
                            }
                        }
                    }
                }
            }
        }

    }
}
