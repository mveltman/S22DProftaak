namespace S22DProftaak.ManagementSystem
{
    partial class ReserveringForm
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
            this.TrainNumberlbl = new System.Windows.Forms.Label();
            this.RailNumberlbl = new System.Windows.Forms.Label();
            this.TrainNumberrtf = new System.Windows.Forms.RichTextBox();
            this.Railnumberrtf = new System.Windows.Forms.RichTextBox();
            this.Repaircbx = new System.Windows.Forms.CheckBox();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TrainNumberlbl
            // 
            this.TrainNumberlbl.AutoSize = true;
            this.TrainNumberlbl.Location = new System.Drawing.Point(70, 39);
            this.TrainNumberlbl.Name = "TrainNumberlbl";
            this.TrainNumberlbl.Size = new System.Drawing.Size(68, 13);
            this.TrainNumberlbl.TabIndex = 0;
            this.TrainNumberlbl.Text = "Tramnummer";
            // 
            // RailNumberlbl
            // 
            this.RailNumberlbl.AutoSize = true;
            this.RailNumberlbl.Location = new System.Drawing.Point(257, 39);
            this.RailNumberlbl.Name = "RailNumberlbl";
            this.RailNumberlbl.Size = new System.Drawing.Size(72, 13);
            this.RailNumberlbl.TabIndex = 1;
            this.RailNumberlbl.Text = "Spoornummer";
            // 
            // TrainNumberrtf
            // 
            this.TrainNumberrtf.Location = new System.Drawing.Point(73, 67);
            this.TrainNumberrtf.Name = "TrainNumberrtf";
            this.TrainNumberrtf.Size = new System.Drawing.Size(100, 96);
            this.TrainNumberrtf.TabIndex = 2;
            this.TrainNumberrtf.Text = "";
            // 
            // Railnumberrtf
            // 
            this.Railnumberrtf.Location = new System.Drawing.Point(260, 67);
            this.Railnumberrtf.Name = "Railnumberrtf";
            this.Railnumberrtf.Size = new System.Drawing.Size(100, 96);
            this.Railnumberrtf.TabIndex = 3;
            this.Railnumberrtf.Text = "";
            // 
            // Repaircbx
            // 
            this.Repaircbx.AutoSize = true;
            this.Repaircbx.Location = new System.Drawing.Point(73, 260);
            this.Repaircbx.Name = "Repaircbx";
            this.Repaircbx.Size = new System.Drawing.Size(72, 17);
            this.Repaircbx.TabIndex = 4;
            this.Repaircbx.Text = "Reparatie";
            this.Repaircbx.UseVisualStyleBackColor = true;
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(237, 233);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(80, 68);
            this.Confirmbtn.TabIndex = 5;
            this.Confirmbtn.Text = "Bevestig";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(323, 233);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(80, 68);
            this.Cancelbtn.TabIndex = 6;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // ReserveringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 339);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.Repaircbx);
            this.Controls.Add(this.Railnumberrtf);
            this.Controls.Add(this.TrainNumberrtf);
            this.Controls.Add(this.RailNumberlbl);
            this.Controls.Add(this.TrainNumberlbl);
            this.Name = "ReserveringForm";
            this.Text = "ReserveringForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TrainNumberlbl;
        private System.Windows.Forms.Label RailNumberlbl;
        private System.Windows.Forms.RichTextBox TrainNumberrtf;
        private System.Windows.Forms.RichTextBox Railnumberrtf;
        private System.Windows.Forms.CheckBox Repaircbx;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Button Cancelbtn;
    }
}