﻿namespace S22DProftaak
{
    partial class CleanSystemForm
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
            this.CleanDescription = new System.Windows.Forms.RichTextBox();
            this.CleanAssignments = new System.Windows.Forms.ListBox();
            this.CleanInProgress = new System.Windows.Forms.ListBox();
            this.CleanButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CleanDescription
            // 
            this.CleanDescription.Location = new System.Drawing.Point(251, 30);
            this.CleanDescription.Name = "CleanDescription";
            this.CleanDescription.Size = new System.Drawing.Size(216, 174);
            this.CleanDescription.TabIndex = 0;
            this.CleanDescription.Text = "";
            // 
            // CleanAssignments
            // 
            this.CleanAssignments.FormattingEnabled = true;
            this.CleanAssignments.Location = new System.Drawing.Point(12, 30);
            this.CleanAssignments.Name = "CleanAssignments";
            this.CleanAssignments.Size = new System.Drawing.Size(204, 537);
            this.CleanAssignments.TabIndex = 1;
            // 
            // CleanInProgress
            // 
            this.CleanInProgress.FormattingEnabled = true;
            this.CleanInProgress.Location = new System.Drawing.Point(518, 30);
            this.CleanInProgress.Name = "CleanInProgress";
            this.CleanInProgress.Size = new System.Drawing.Size(204, 537);
            this.CleanInProgress.TabIndex = 2;
            // 
            // CleanButton
            // 
            this.CleanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.CleanButton.Location = new System.Drawing.Point(278, 249);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(122, 42);
            this.CleanButton.TabIndex = 3;
            this.CleanButton.Text = "Clean";
            this.CleanButton.UseVisualStyleBackColor = true;
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DoneButton.Location = new System.Drawing.Point(763, 46);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(122, 42);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // CleanSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 619);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.CleanInProgress);
            this.Controls.Add(this.CleanAssignments);
            this.Controls.Add(this.CleanDescription);
            this.Name = "CleanSystem";
            this.Text = "CleanSystem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CleanDescription;
        private System.Windows.Forms.ListBox CleanAssignments;
        private System.Windows.Forms.ListBox CleanInProgress;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button DoneButton;
    }
}