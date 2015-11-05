namespace S22DProftaak.RepairSystem
{
    partial class WorkerInformation
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
            this.WorkDescription = new System.Windows.Forms.RichTextBox();
            this.Workers = new System.Windows.Forms.ListBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Assignments = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WorkDescription
            // 
            this.WorkDescription.Location = new System.Drawing.Point(187, 46);
            this.WorkDescription.Name = "WorkDescription";
            this.WorkDescription.Size = new System.Drawing.Size(290, 213);
            this.WorkDescription.TabIndex = 0;
            this.WorkDescription.Text = "";
            // 
            // Workers
            // 
            this.Workers.FormattingEnabled = true;
            this.Workers.Location = new System.Drawing.Point(12, 302);
            this.Workers.Name = "Workers";
            this.Workers.Size = new System.Drawing.Size(264, 160);
            this.Workers.TabIndex = 1;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.richTextBox2.Location = new System.Drawing.Point(303, 302);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(88, 78);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.richTextBox3.Location = new System.Drawing.Point(303, 386);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(88, 78);
            this.richTextBox3.TabIndex = 3;
            this.richTextBox3.Text = "";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Label1.Location = new System.Drawing.Point(408, 329);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 25);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Spoor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(408, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sector";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(182, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(12, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Co-Workers";
            // 
            // Assignments
            // 
            this.Assignments.FormattingEnabled = true;
            this.Assignments.Location = new System.Drawing.Point(12, 46);
            this.Assignments.Name = "Assignments";
            this.Assignments.Size = new System.Drawing.Size(169, 212);
            this.Assignments.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Assignments";
            // 
            // WorkerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 474);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Assignments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.Workers);
            this.Controls.Add(this.WorkDescription);
            this.Name = "WorkerInformation";
            this.Text = "WorkerInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox WorkDescription;
        private System.Windows.Forms.ListBox Workers;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Assignments;
        private System.Windows.Forms.Label label5;
    }
}