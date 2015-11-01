namespace S22DProftaak.EntranceExitSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntranceExitForm));
            this.btnArrived = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkClean = new System.Windows.Forms.CheckBox();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.txtRail = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArrived
            // 
            this.btnArrived.Location = new System.Drawing.Point(117, 55);
            this.btnArrived.Name = "btnArrived";
            this.btnArrived.Size = new System.Drawing.Size(75, 27);
            this.btnArrived.TabIndex = 1;
            this.btnArrived.Text = "Arrived";
            this.btnArrived.UseVisualStyleBackColor = true;
            this.btnArrived.Click += new System.EventHandler(this.btnArrived_Click);
            // 
            // btbDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(198, 55);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(75, 27);
            this.btnDescription.TabIndex = 1;
            this.btnDescription.Text = "Description";
            this.btnDescription.UseVisualStyleBackColor = true;
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkClean);
            this.groupBox1.Controls.Add(this.chkRepair);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // cbClean
            // 
            this.chkClean.AutoSize = true;
            this.chkClean.Location = new System.Drawing.Point(6, 42);
            this.chkClean.Name = "cbClean";
            this.chkClean.Size = new System.Drawing.Size(53, 17);
            this.chkClean.TabIndex = 0;
            this.chkClean.Text = "Clean";
            this.chkClean.UseVisualStyleBackColor = true;
            // 
            // cbRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Location = new System.Drawing.Point(6, 19);
            this.chkRepair.Name = "cbRepair";
            this.chkRepair.Size = new System.Drawing.Size(57, 17);
            this.chkRepair.TabIndex = 0;
            this.chkRepair.Text = "Repair";
            this.chkRepair.UseVisualStyleBackColor = true;
            // 
            // tbRail
            // 
            this.txtRail.Location = new System.Drawing.Point(117, 29);
            this.txtRail.Name = "tbRail";
            this.txtRail.ReadOnly = true;
            this.txtRail.Size = new System.Drawing.Size(156, 20);
            this.txtRail.TabIndex = 3;
            // 
            // EntranceExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 91);
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

        private void btnDescription_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button btnArrived;
        private System.Windows.Forms.Button btnDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkClean;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.TextBox txtRail;
    }
}