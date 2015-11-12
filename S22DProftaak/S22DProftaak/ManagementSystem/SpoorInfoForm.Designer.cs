namespace S22DProftaak.ManagementSystem
{
    partial class SpoorInfoForm
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
            this.lbxRailInfo = new System.Windows.Forms.ListBox();
            this.rtfRailnumber = new System.Windows.Forms.RichTextBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxRailInfo
            // 
            this.lbxRailInfo.FormattingEnabled = true;
            this.lbxRailInfo.Location = new System.Drawing.Point(3, 114);
            this.lbxRailInfo.Name = "lbxRailInfo";
            this.lbxRailInfo.Size = new System.Drawing.Size(585, 394);
            this.lbxRailInfo.TabIndex = 0;
            // 
            // rtfRailnumber
            // 
            this.rtfRailnumber.Location = new System.Drawing.Point(198, 12);
            this.rtfRailnumber.Name = "rtfRailnumber";
            this.rtfRailnumber.Size = new System.Drawing.Size(100, 96);
            this.rtfRailnumber.TabIndex = 1;
            this.rtfRailnumber.Text = "";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(304, 32);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(84, 53);
            this.btnGetInfo.TabIndex = 2;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // SpoorInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 517);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.rtfRailnumber);
            this.Controls.Add(this.lbxRailInfo);
            this.Name = "SpoorInfoForm";
            this.Text = "SpoorInfoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRailInfo;
        private System.Windows.Forms.RichTextBox rtfRailnumber;
        private System.Windows.Forms.Button btnGetInfo;
    }
}