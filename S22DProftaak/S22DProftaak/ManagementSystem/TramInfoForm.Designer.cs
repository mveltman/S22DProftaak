namespace S22DProftaak.ManagementSystem
{
    partial class TramInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TramInfoForm));
            this.TrainInfolbx = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TrainNumbertsb = new System.Windows.Forms.ToolStripButton();
            this.Typetsb = new System.Windows.Forms.ToolStripButton();
            this.Railtsb = new System.Windows.Forms.ToolStripButton();
            this.RailSectiontsb = new System.Windows.Forms.ToolStripButton();
            this.Refreshtsb = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrainInfolbx
            // 
            this.TrainInfolbx.FormattingEnabled = true;
            this.TrainInfolbx.Location = new System.Drawing.Point(12, 28);
            this.TrainInfolbx.Name = "TrainInfolbx";
            this.TrainInfolbx.Size = new System.Drawing.Size(743, 459);
            this.TrainInfolbx.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refreshtsb,
            this.TrainNumbertsb,
            this.Typetsb,
            this.Railtsb,
            this.RailSectiontsb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TrainNumbertsb
            // 
            this.TrainNumbertsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TrainNumbertsb.Image = ((System.Drawing.Image)(resources.GetObject("TrainNumbertsb.Image")));
            this.TrainNumbertsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TrainNumbertsb.Name = "TrainNumbertsb";
            this.TrainNumbertsb.Size = new System.Drawing.Size(85, 22);
            this.TrainNumbertsb.Text = "Tramnummer";
            this.TrainNumbertsb.Click += new System.EventHandler(this.TrainNumbertsb_Click);
            // 
            // Typetsb
            // 
            this.Typetsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Typetsb.Image = ((System.Drawing.Image)(resources.GetObject("Typetsb.Image")));
            this.Typetsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Typetsb.Name = "Typetsb";
            this.Typetsb.Size = new System.Drawing.Size(39, 22);
            this.Typetsb.Text = "Soort";
            this.Typetsb.Click += new System.EventHandler(this.Typetsb_Click);
            // 
            // Railtsb
            // 
            this.Railtsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Railtsb.Image = ((System.Drawing.Image)(resources.GetObject("Railtsb.Image")));
            this.Railtsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Railtsb.Name = "Railtsb";
            this.Railtsb.Size = new System.Drawing.Size(42, 22);
            this.Railtsb.Text = "Spoor";
            this.Railtsb.Click += new System.EventHandler(this.Railtsb_Click);
            // 
            // RailSectiontsb
            // 
            this.RailSectiontsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RailSectiontsb.Image = ((System.Drawing.Image)(resources.GetObject("RailSectiontsb.Image")));
            this.RailSectiontsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RailSectiontsb.Name = "RailSectiontsb";
            this.RailSectiontsb.Size = new System.Drawing.Size(60, 22);
            this.RailSectiontsb.Text = "Railsectie";
            this.RailSectiontsb.Click += new System.EventHandler(this.RailSectiontsb_Click);
            // 
            // Refreshtsb
            // 
            this.Refreshtsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Refreshtsb.Image = ((System.Drawing.Image)(resources.GetObject("Refreshtsb.Image")));
            this.Refreshtsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refreshtsb.Name = "Refreshtsb";
            this.Refreshtsb.Size = new System.Drawing.Size(49, 22);
            this.Refreshtsb.Text = "Ververs";
            this.Refreshtsb.Click += new System.EventHandler(this.Refreshtsb_Click);
            // 
            // TramInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 587);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TrainInfolbx);
            this.Name = "TramInfoForm";
            this.Text = "TramInfoForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TrainInfolbx;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TrainNumbertsb;
        private System.Windows.Forms.ToolStripButton Typetsb;
        private System.Windows.Forms.ToolStripButton Railtsb;
        private System.Windows.Forms.ToolStripButton RailSectiontsb;
        private System.Windows.Forms.ToolStripButton Refreshtsb;
    }
}