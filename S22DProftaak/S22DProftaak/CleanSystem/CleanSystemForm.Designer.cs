namespace S22DProftaak
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CleanDescription
            // 
            this.CleanDescription.Location = new System.Drawing.Point(222, 12);
            this.CleanDescription.Name = "CleanDescription";
            this.CleanDescription.Size = new System.Drawing.Size(216, 174);
            this.CleanDescription.TabIndex = 0;
            this.CleanDescription.Text = "";
            // 
            // CleanAssignments
            // 
            this.CleanAssignments.FormattingEnabled = true;
            this.CleanAssignments.Location = new System.Drawing.Point(12, 12);
            this.CleanAssignments.Name = "CleanAssignments";
            this.CleanAssignments.Size = new System.Drawing.Size(204, 537);
            this.CleanAssignments.TabIndex = 1;
            this.CleanAssignments.SelectedIndexChanged += new System.EventHandler(this.CleanAssignments_SelectedIndexChanged);
            // 
            // CleanInProgress
            // 
            this.CleanInProgress.FormattingEnabled = true;
            this.CleanInProgress.Location = new System.Drawing.Point(444, 12);
            this.CleanInProgress.Name = "CleanInProgress";
            this.CleanInProgress.Size = new System.Drawing.Size(204, 537);
            this.CleanInProgress.TabIndex = 2;
            // 
            // CleanButton
            // 
            this.CleanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.CleanButton.Location = new System.Drawing.Point(267, 192);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(122, 42);
            this.CleanButton.TabIndex = 3;
            this.CleanButton.Text = "Clean";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DoneButton.Location = new System.Drawing.Point(654, 12);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(122, 42);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.CreateButton.Location = new System.Drawing.Point(267, 251);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(122, 42);
            this.CreateButton.TabIndex = 12;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.ChangeButton.Location = new System.Drawing.Point(654, 70);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(122, 42);
            this.ChangeButton.TabIndex = 13;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // CleanSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 561);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.CleanInProgress);
            this.Controls.Add(this.CleanAssignments);
            this.Controls.Add(this.CleanDescription);
            this.Name = "CleanSystemForm";
            this.Text = "CleanSystem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CleanDescription;
        private System.Windows.Forms.ListBox CleanAssignments;
        private System.Windows.Forms.ListBox CleanInProgress;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button ChangeButton;
    }
}