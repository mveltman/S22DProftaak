namespace S22DProftaak.ManagementSystem
{
    partial class TramKeuzeForm
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
            this.rtfTrainNumber = new System.Windows.Forms.RichTextBox();
            this.rtfRailNumber = new System.Windows.Forms.RichTextBox();
            this.rtfRailPosition = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPlaatsTram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtfTrainNumber
            // 
            this.rtfTrainNumber.Location = new System.Drawing.Point(47, 59);
            this.rtfTrainNumber.Name = "rtfTrainNumber";
            this.rtfTrainNumber.Size = new System.Drawing.Size(67, 59);
            this.rtfTrainNumber.TabIndex = 0;
            this.rtfTrainNumber.Text = "";
            // 
            // rtfRailNumber
            // 
            this.rtfRailNumber.Location = new System.Drawing.Point(120, 59);
            this.rtfRailNumber.Name = "rtfRailNumber";
            this.rtfRailNumber.Size = new System.Drawing.Size(67, 59);
            this.rtfRailNumber.TabIndex = 0;
            this.rtfRailNumber.Text = "";
            // 
            // rtfRailPosition
            // 
            this.rtfRailPosition.Location = new System.Drawing.Point(193, 59);
            this.rtfRailPosition.Name = "rtfRailPosition";
            this.rtfRailPosition.Size = new System.Drawing.Size(67, 59);
            this.rtfRailPosition.TabIndex = 0;
            this.rtfRailPosition.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tramnummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "railnummer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "railsectie";
            // 
            // btnPlaatsTram
            // 
            this.btnPlaatsTram.Location = new System.Drawing.Point(120, 170);
            this.btnPlaatsTram.Name = "btnPlaatsTram";
            this.btnPlaatsTram.Size = new System.Drawing.Size(91, 64);
            this.btnPlaatsTram.TabIndex = 4;
            this.btnPlaatsTram.Text = "Plaats Tram";
            this.btnPlaatsTram.UseVisualStyleBackColor = true;
            this.btnPlaatsTram.Click += new System.EventHandler(this.btnPlaatsTram_Click);
            // 
            // TramKeuzeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 297);
            this.Controls.Add(this.btnPlaatsTram);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtfRailPosition);
            this.Controls.Add(this.rtfRailNumber);
            this.Controls.Add(this.rtfTrainNumber);
            this.Name = "TramKeuzeForm";
            this.Text = "TramKeuzeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfTrainNumber;
        private System.Windows.Forms.RichTextBox rtfRailNumber;
        private System.Windows.Forms.RichTextBox rtfRailPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPlaatsTram;
    }
}