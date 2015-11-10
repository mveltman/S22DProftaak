namespace S22DProftaak.General
{
    partial class EntranceExitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntranceExitForm));
            this.btnArrived = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkClean = new System.Windows.Forms.CheckBox();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.txtRail = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CheckRequestTimer = new System.Windows.Forms.Timer(this.components);
            this.Actionrtf = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArrived
            // 
            this.btnArrived.Location = new System.Drawing.Point(117, 107);
            this.btnArrived.Name = "btnArrived";
            this.btnArrived.Size = new System.Drawing.Size(75, 50);
            this.btnArrived.TabIndex = 1;
            this.btnArrived.Text = "Arrived";
            this.btnArrived.UseVisualStyleBackColor = true;
            this.btnArrived.Click += new System.EventHandler(this.btnArrived_Click);
            // 
            // btnDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(198, 107);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(75, 50);
            this.btnDescription.TabIndex = 1;
            this.btnDescription.Text = "Description";
            this.btnDescription.UseVisualStyleBackColor = true;
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkClean);
            this.groupBox1.Controls.Add(this.chkRepair);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // chkClean
            // 
            this.chkClean.AutoSize = true;
            this.chkClean.Location = new System.Drawing.Point(6, 42);
            this.chkClean.Name = "chkClean";
            this.chkClean.Size = new System.Drawing.Size(53, 17);
            this.chkClean.TabIndex = 0;
            this.chkClean.Text = "Clean";
            this.chkClean.UseVisualStyleBackColor = true;
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Location = new System.Drawing.Point(6, 19);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(57, 17);
            this.chkRepair.TabIndex = 0;
            this.chkRepair.Text = "Repair";
            this.chkRepair.UseVisualStyleBackColor = true;
            // 
            // txtRail
            // 
            this.txtRail.Location = new System.Drawing.Point(12, 29);
            this.txtRail.Name = "txtRail";
            this.txtRail.ReadOnly = true;
            this.txtRail.Size = new System.Drawing.Size(261, 20);
            this.txtRail.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // CheckRequestTimer
            // 
            this.CheckRequestTimer.Enabled = true;
            this.CheckRequestTimer.Interval = 2000;
            this.CheckRequestTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Actionrtf
            // 
            this.Actionrtf.Location = new System.Drawing.Point(18, 164);
            this.Actionrtf.Name = "Actionrtf";
            this.Actionrtf.Size = new System.Drawing.Size(251, 37);
            this.Actionrtf.TabIndex = 4;
            this.Actionrtf.Text = "";
            // 
            // EntranceExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 213);
            this.Controls.Add(this.Actionrtf);
            this.Controls.Add(this.txtRail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDescription);
            this.Controls.Add(this.btnArrived);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntranceExitForm";
            this.Text = "EntranceExitForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnArrived;
        private System.Windows.Forms.Button btnDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkClean;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.TextBox txtRail;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer CheckRequestTimer;
        private System.Windows.Forms.RichTextBox Actionrtf;
    }
}