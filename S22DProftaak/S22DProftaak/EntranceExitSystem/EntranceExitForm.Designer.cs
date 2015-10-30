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
            this.btbDescription = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClean = new System.Windows.Forms.CheckBox();
            this.cbRepair = new System.Windows.Forms.CheckBox();
            this.tbRail = new System.Windows.Forms.TextBox();
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
            this.btbDescription.Location = new System.Drawing.Point(198, 55);
            this.btbDescription.Name = "btbDescription";
            this.btbDescription.Size = new System.Drawing.Size(75, 27);
            this.btbDescription.TabIndex = 1;
            this.btbDescription.Text = "Description";
            this.btbDescription.UseVisualStyleBackColor = true;
            this.btbDescription.Click += new System.EventHandler(this.btbDescription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClean);
            this.groupBox1.Controls.Add(this.cbRepair);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // cbClean
            // 
            this.cbClean.AutoSize = true;
            this.cbClean.Location = new System.Drawing.Point(6, 42);
            this.cbClean.Name = "cbClean";
            this.cbClean.Size = new System.Drawing.Size(53, 17);
            this.cbClean.TabIndex = 0;
            this.cbClean.Text = "Clean";
            this.cbClean.UseVisualStyleBackColor = true;
            // 
            // cbRepair
            // 
            this.cbRepair.AutoSize = true;
            this.cbRepair.Location = new System.Drawing.Point(6, 19);
            this.cbRepair.Name = "cbRepair";
            this.cbRepair.Size = new System.Drawing.Size(57, 17);
            this.cbRepair.TabIndex = 0;
            this.cbRepair.Text = "Repair";
            this.cbRepair.UseVisualStyleBackColor = true;
            // 
            // tbRail
            // 
            this.tbRail.Location = new System.Drawing.Point(117, 29);
            this.tbRail.Name = "tbRail";
            this.tbRail.ReadOnly = true;
            this.tbRail.Size = new System.Drawing.Size(156, 20);
            this.tbRail.TabIndex = 3;
            // 
            // EntranceExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 91);
            this.Controls.Add(this.tbRail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btbDescription);
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
        private System.Windows.Forms.Button btbDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbClean;
        private System.Windows.Forms.CheckBox cbRepair;
        private System.Windows.Forms.TextBox tbRail;
    }
}