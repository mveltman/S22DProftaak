namespace S22DProftaak.RepairSystem
{
    partial class WorkerInformationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WorkDescriptionrtf = new System.Windows.Forms.RichTextBox();
            this.Spoorrtf = new System.Windows.Forms.RichTextBox();
            this.sectorrtf = new System.Windows.Forms.RichTextBox();
            this.spoorlbl = new System.Windows.Forms.Label();
            this.sectorlbl = new System.Windows.Forms.Label();
            this.descriptionlbl = new System.Windows.Forms.Label();
            this.Assignmentslbx = new System.Windows.Forms.ListBox();
            this.assignmentslbl = new System.Windows.Forms.Label();
            this.Updatetaskstimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WorkDescriptionrtf
            // 
            this.WorkDescriptionrtf.Location = new System.Drawing.Point(187, 46);
            this.WorkDescriptionrtf.Name = "WorkDescriptionrtf";
            this.WorkDescriptionrtf.Size = new System.Drawing.Size(290, 213);
            this.WorkDescriptionrtf.TabIndex = 0;
            this.WorkDescriptionrtf.Text = "";
            // 
            // Spoorrtf
            // 
            this.Spoorrtf.Enabled = false;
            this.Spoorrtf.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Spoorrtf.Location = new System.Drawing.Point(17, 292);
            this.Spoorrtf.Name = "Spoorrtf";
            this.Spoorrtf.Size = new System.Drawing.Size(88, 78);
            this.Spoorrtf.TabIndex = 2;
            this.Spoorrtf.Text = "";
            // 
            // sectorrtf
            // 
            this.sectorrtf.Enabled = false;
            this.sectorrtf.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.sectorrtf.Location = new System.Drawing.Point(17, 384);
            this.sectorrtf.Name = "sectorrtf";
            this.sectorrtf.Size = new System.Drawing.Size(88, 78);
            this.sectorrtf.TabIndex = 3;
            this.sectorrtf.Text = "";
            // 
            // spoorlbl
            // 
            this.spoorlbl.AutoSize = true;
            this.spoorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.spoorlbl.Location = new System.Drawing.Point(112, 318);
            this.spoorlbl.Name = "spoorlbl";
            this.spoorlbl.Size = new System.Drawing.Size(69, 25);
            this.spoorlbl.TabIndex = 4;
            this.spoorlbl.Text = "Spoor";
            // 
            // sectorlbl
            // 
            this.sectorlbl.AutoSize = true;
            this.sectorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.sectorlbl.Location = new System.Drawing.Point(112, 406);
            this.sectorlbl.Name = "sectorlbl";
            this.sectorlbl.Size = new System.Drawing.Size(74, 25);
            this.sectorlbl.TabIndex = 5;
            this.sectorlbl.Text = "Sector";
            // 
            // descriptionlbl
            // 
            this.descriptionlbl.AutoSize = true;
            this.descriptionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.descriptionlbl.Location = new System.Drawing.Point(182, 9);
            this.descriptionlbl.Name = "descriptionlbl";
            this.descriptionlbl.Size = new System.Drawing.Size(120, 25);
            this.descriptionlbl.TabIndex = 6;
            this.descriptionlbl.Text = "Description";
            // 
            // Assignmentslbx
            // 
            this.Assignmentslbx.FormattingEnabled = true;
            this.Assignmentslbx.Location = new System.Drawing.Point(12, 46);
            this.Assignmentslbx.Name = "Assignmentslbx";
            this.Assignmentslbx.Size = new System.Drawing.Size(169, 212);
            this.Assignmentslbx.TabIndex = 8;
            this.Assignmentslbx.SelectedIndexChanged += new System.EventHandler(this.Assignmentslbx_SelectedIndexChanged);
            // 
            // assignmentslbl
            // 
            this.assignmentslbl.AutoSize = true;
            this.assignmentslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.assignmentslbl.Location = new System.Drawing.Point(12, 9);
            this.assignmentslbl.Name = "assignmentslbl";
            this.assignmentslbl.Size = new System.Drawing.Size(135, 25);
            this.assignmentslbl.TabIndex = 9;
            this.assignmentslbl.Text = "Assignments";
            // 
            // Updatetaskstimer
            // 
            this.Updatetaskstimer.Enabled = true;
            this.Updatetaskstimer.Interval = 3000;
            this.Updatetaskstimer.Tick += new System.EventHandler(this.Updatetaskstimer_Tick);
            // 
            // WorkerInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 474);
            this.Controls.Add(this.assignmentslbl);
            this.Controls.Add(this.Assignmentslbx);
            this.Controls.Add(this.descriptionlbl);
            this.Controls.Add(this.sectorlbl);
            this.Controls.Add(this.spoorlbl);
            this.Controls.Add(this.sectorrtf);
            this.Controls.Add(this.Spoorrtf);
            this.Controls.Add(this.WorkDescriptionrtf);
            this.Name = "WorkerInformationForm";
            this.Text = "WorkerInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox WorkDescriptionrtf;
        private System.Windows.Forms.RichTextBox Spoorrtf;
        private System.Windows.Forms.RichTextBox sectorrtf;
        private System.Windows.Forms.Label spoorlbl;
        private System.Windows.Forms.Label sectorlbl;
        private System.Windows.Forms.Label descriptionlbl;
        private System.Windows.Forms.ListBox Assignmentslbx;
        private System.Windows.Forms.Label assignmentslbl;
        private System.Windows.Forms.Timer Updatetaskstimer;
    }
}