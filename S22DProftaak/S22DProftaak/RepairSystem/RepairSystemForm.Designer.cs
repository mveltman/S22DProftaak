namespace S22DProftaak
{
    partial class RepairSystemForm
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.RepairButton = new System.Windows.Forms.Button();
            this.RepairInProgress = new System.Windows.Forms.ListBox();
            this.RepairAssignments = new System.Windows.Forms.ListBox();
            this.RepairDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DoneButton.Location = new System.Drawing.Point(654, 12);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(122, 42);
            this.DoneButton.TabIndex = 9;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // RepairButton
            // 
            this.RepairButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.RepairButton.Location = new System.Drawing.Point(268, 192);
            this.RepairButton.Name = "RepairButton";
            this.RepairButton.Size = new System.Drawing.Size(122, 42);
            this.RepairButton.TabIndex = 8;
            this.RepairButton.Text = "Repair";
            this.RepairButton.UseVisualStyleBackColor = true;
            // 
            // RepairInProgress
            // 
            this.RepairInProgress.FormattingEnabled = true;
            this.RepairInProgress.Location = new System.Drawing.Point(444, 12);
            this.RepairInProgress.Name = "RepairInProgress";
            this.RepairInProgress.Size = new System.Drawing.Size(204, 537);
            this.RepairInProgress.TabIndex = 7;
            // 
            // RepairAssignments
            // 
            this.RepairAssignments.FormattingEnabled = true;
            this.RepairAssignments.Location = new System.Drawing.Point(12, 12);
            this.RepairAssignments.Name = "RepairAssignments";
            this.RepairAssignments.Size = new System.Drawing.Size(204, 537);
            this.RepairAssignments.TabIndex = 6;
            // 
            // RepairDescription
            // 
            this.RepairDescription.Location = new System.Drawing.Point(222, 12);
            this.RepairDescription.Name = "RepairDescription";
            this.RepairDescription.Size = new System.Drawing.Size(216, 174);
            this.RepairDescription.TabIndex = 5;
            this.RepairDescription.Text = "";
            // 
            // RepairSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 562);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.RepairButton);
            this.Controls.Add(this.RepairInProgress);
            this.Controls.Add(this.RepairAssignments);
            this.Controls.Add(this.RepairDescription);
            this.Name = "RepairSystemForm";
            this.Text = "RepairSystem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button RepairButton;
        private System.Windows.Forms.ListBox RepairInProgress;
        private System.Windows.Forms.ListBox RepairAssignments;
        private System.Windows.Forms.RichTextBox RepairDescription;
    }
}