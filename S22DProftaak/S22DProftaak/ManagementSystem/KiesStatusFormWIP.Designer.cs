namespace S22DProftaak.ManagementSystem
{
    partial class KiesStatusFormWIP
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
            this.Statuscbx = new System.Windows.Forms.ComboBox();
            this.Trainnumberlbl = new System.Windows.Forms.Label();
            this.TrainNumberrtf = new System.Windows.Forms.RichTextBox();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Statuscbx
            // 
            this.Statuscbx.FormattingEnabled = true;
            this.Statuscbx.Items.AddRange(new object[] {
            "Defect",
            "Schoonmaak",
            "Beschikbaar"});
            this.Statuscbx.Location = new System.Drawing.Point(59, 47);
            this.Statuscbx.Name = "Statuscbx";
            this.Statuscbx.Size = new System.Drawing.Size(306, 21);
            this.Statuscbx.TabIndex = 0;
            this.Statuscbx.Text = "Voer status hier in";
            // 
            // Trainnumberlbl
            // 
            this.Trainnumberlbl.AutoSize = true;
            this.Trainnumberlbl.Location = new System.Drawing.Point(56, 136);
            this.Trainnumberlbl.Name = "Trainnumberlbl";
            this.Trainnumberlbl.Size = new System.Drawing.Size(68, 13);
            this.Trainnumberlbl.TabIndex = 1;
            this.Trainnumberlbl.Text = "Tramnummer";
            // 
            // TrainNumberrtf
            // 
            this.TrainNumberrtf.Location = new System.Drawing.Point(59, 171);
            this.TrainNumberrtf.Name = "TrainNumberrtf";
            this.TrainNumberrtf.Size = new System.Drawing.Size(100, 96);
            this.TrainNumberrtf.TabIndex = 2;
            this.TrainNumberrtf.Text = "";
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(309, 300);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(95, 83);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(197, 300);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(95, 83);
            this.Confirmbtn.TabIndex = 4;
            this.Confirmbtn.Text = "Bevestig";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // KiesStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 452);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.TrainNumberrtf);
            this.Controls.Add(this.Trainnumberlbl);
            this.Controls.Add(this.Statuscbx);
            this.Name = "KiesStatusForm";
            this.Text = "KiesStatusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Statuscbx;
        private System.Windows.Forms.Label Trainnumberlbl;
        private System.Windows.Forms.RichTextBox TrainNumberrtf;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button Confirmbtn;

    }
}