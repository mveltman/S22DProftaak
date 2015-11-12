namespace S22DProftaak.ManagementSystem
{
    partial class ManagementRequestingForm
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
            this.Placebtn = new System.Windows.Forms.Button();
            this.Trainnumbertbx = new System.Windows.Forms.TextBox();
            this.RailNumbertbx = new System.Windows.Forms.TextBox();
            this.RailPositiontbx = new System.Windows.Forms.TextBox();
            this.TrainNumberlbl = new System.Windows.Forms.Label();
            this.RailNumberlbl = new System.Windows.Forms.Label();
            this.PositionNumberlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Placebtn
            // 
            this.Placebtn.Location = new System.Drawing.Point(212, 181);
            this.Placebtn.Name = "Placebtn";
            this.Placebtn.Size = new System.Drawing.Size(148, 55);
            this.Placebtn.TabIndex = 0;
            this.Placebtn.Text = "Plaats Tram";
            this.Placebtn.UseVisualStyleBackColor = true;
            this.Placebtn.Click += new System.EventHandler(this.Placebtn_Click);
            // 
            // Trainnumbertbx
            // 
            this.Trainnumbertbx.Enabled = false;
            this.Trainnumbertbx.Location = new System.Drawing.Point(93, 42);
            this.Trainnumbertbx.Name = "Trainnumbertbx";
            this.Trainnumbertbx.Size = new System.Drawing.Size(100, 20);
            this.Trainnumbertbx.TabIndex = 1;
            // 
            // RailNumbertbx
            // 
            this.RailNumbertbx.Location = new System.Drawing.Point(93, 81);
            this.RailNumbertbx.Name = "RailNumbertbx";
            this.RailNumbertbx.Size = new System.Drawing.Size(100, 20);
            this.RailNumbertbx.TabIndex = 2;
            // 
            // RailPositiontbx
            // 
            this.RailPositiontbx.Location = new System.Drawing.Point(93, 122);
            this.RailPositiontbx.Name = "RailPositiontbx";
            this.RailPositiontbx.Size = new System.Drawing.Size(100, 20);
            this.RailPositiontbx.TabIndex = 3;
            // 
            // TrainNumberlbl
            // 
            this.TrainNumberlbl.AutoSize = true;
            this.TrainNumberlbl.Location = new System.Drawing.Point(4, 45);
            this.TrainNumberlbl.Name = "TrainNumberlbl";
            this.TrainNumberlbl.Size = new System.Drawing.Size(74, 13);
            this.TrainNumberlbl.TabIndex = 4;
            this.TrainNumberlbl.Text = "Tramnummer: ";
            // 
            // RailNumberlbl
            // 
            this.RailNumberlbl.AutoSize = true;
            this.RailNumberlbl.Location = new System.Drawing.Point(4, 84);
            this.RailNumberlbl.Name = "RailNumberlbl";
            this.RailNumberlbl.Size = new System.Drawing.Size(81, 13);
            this.RailNumberlbl.TabIndex = 5;
            this.RailNumberlbl.Text = "Spoor nummer: ";
            // 
            // PositionNumberlbl
            // 
            this.PositionNumberlbl.AutoSize = true;
            this.PositionNumberlbl.Location = new System.Drawing.Point(4, 125);
            this.PositionNumberlbl.Name = "PositionNumberlbl";
            this.PositionNumberlbl.Size = new System.Drawing.Size(83, 13);
            this.PositionNumberlbl.TabIndex = 6;
            this.PositionNumberlbl.Text = "Sectie nummer: ";
            // 
            // ManagementRequestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 275);
            this.Controls.Add(this.PositionNumberlbl);
            this.Controls.Add(this.RailNumberlbl);
            this.Controls.Add(this.TrainNumberlbl);
            this.Controls.Add(this.RailPositiontbx);
            this.Controls.Add(this.RailNumbertbx);
            this.Controls.Add(this.Trainnumbertbx);
            this.Controls.Add(this.Placebtn);
            this.Name = "ManagementRequestingForm";
            this.Text = "ManagementRequestingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagementRequestingForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Placebtn;
        private System.Windows.Forms.TextBox Trainnumbertbx;
        private System.Windows.Forms.TextBox RailNumbertbx;
        private System.Windows.Forms.TextBox RailPositiontbx;
        private System.Windows.Forms.Label TrainNumberlbl;
        private System.Windows.Forms.Label RailNumberlbl;
        private System.Windows.Forms.Label PositionNumberlbl;
    }
}