namespace S22DProftaak.ManagementSystem
{
    partial class ToggleBlockRailForm
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
            this.lblRailNumber = new System.Windows.Forms.Label();
            this.btnToggleBlock = new System.Windows.Forms.Button();
            this.rtfRailNumber = new System.Windows.Forms.RichTextBox();
            this.rtfRailPosition = new System.Windows.Forms.RichTextBox();
            this.lblRailPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRailNumber
            // 
            this.lblRailNumber.AutoSize = true;
            this.lblRailNumber.Location = new System.Drawing.Point(38, 30);
            this.lblRailNumber.Name = "lblRailNumber";
            this.lblRailNumber.Size = new System.Drawing.Size(65, 13);
            this.lblRailNumber.TabIndex = 0;
            this.lblRailNumber.Text = "Rail nummer";
            // 
            // btnToggleBlock
            // 
            this.btnToggleBlock.Location = new System.Drawing.Point(41, 179);
            this.btnToggleBlock.Name = "btnToggleBlock";
            this.btnToggleBlock.Size = new System.Drawing.Size(100, 49);
            this.btnToggleBlock.TabIndex = 1;
            this.btnToggleBlock.Text = "Toggle Block";
            this.btnToggleBlock.UseVisualStyleBackColor = true;
            this.btnToggleBlock.Click += new System.EventHandler(this.btnToggleBlock_Click);
            // 
            // rtfRailNumber
            // 
            this.rtfRailNumber.Location = new System.Drawing.Point(41, 46);
            this.rtfRailNumber.Name = "rtfRailNumber";
            this.rtfRailNumber.Size = new System.Drawing.Size(100, 96);
            this.rtfRailNumber.TabIndex = 2;
            this.rtfRailNumber.Text = "";
            // 
            // rtfRailPosition
            // 
            this.rtfRailPosition.Location = new System.Drawing.Point(171, 46);
            this.rtfRailPosition.Name = "rtfRailPosition";
            this.rtfRailPosition.Size = new System.Drawing.Size(100, 96);
            this.rtfRailPosition.TabIndex = 3;
            this.rtfRailPosition.Text = "";
            // 
            // lblRailPosition
            // 
            this.lblRailPosition.AutoSize = true;
            this.lblRailPosition.Location = new System.Drawing.Point(168, 30);
            this.lblRailPosition.Name = "lblRailPosition";
            this.lblRailPosition.Size = new System.Drawing.Size(56, 13);
            this.lblRailPosition.TabIndex = 4;
            this.lblRailPosition.Text = "RailPositie";
            // 
            // ToggleBlockRailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 289);
            this.Controls.Add(this.lblRailPosition);
            this.Controls.Add(this.rtfRailPosition);
            this.Controls.Add(this.rtfRailNumber);
            this.Controls.Add(this.btnToggleBlock);
            this.Controls.Add(this.lblRailNumber);
            this.Name = "ToggleBlockRailForm";
            this.Text = "ToggleBlockRailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRailNumber;
        private System.Windows.Forms.Button btnToggleBlock;
        private System.Windows.Forms.RichTextBox rtfRailNumber;
        private System.Windows.Forms.RichTextBox rtfRailPosition;
        private System.Windows.Forms.Label lblRailPosition;
    }
}