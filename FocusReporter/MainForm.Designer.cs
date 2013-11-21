namespace FocusReporter
{
    partial class MainForm
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
            this.activeWindowLabel = new System.Windows.Forms.Label();
            this.threadIdLabel = new System.Windows.Forms.Label();
            this.processIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // activeWindowLabel
            // 
            this.activeWindowLabel.AutoSize = true;
            this.activeWindowLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeWindowLabel.Location = new System.Drawing.Point(12, 9);
            this.activeWindowLabel.Name = "activeWindowLabel";
            this.activeWindowLabel.Size = new System.Drawing.Size(116, 19);
            this.activeWindowLabel.TabIndex = 0;
            this.activeWindowLabel.Text = "activeWindow";
            // 
            // threadIdLabel
            // 
            this.threadIdLabel.AutoSize = true;
            this.threadIdLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threadIdLabel.Location = new System.Drawing.Point(12, 53);
            this.threadIdLabel.Name = "threadIdLabel";
            this.threadIdLabel.Size = new System.Drawing.Size(72, 19);
            this.threadIdLabel.TabIndex = 1;
            this.threadIdLabel.Text = "threadId";
            // 
            // processIdLabel
            // 
            this.processIdLabel.AutoSize = true;
            this.processIdLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processIdLabel.Location = new System.Drawing.Point(12, 31);
            this.processIdLabel.Name = "processIdLabel";
            this.processIdLabel.Size = new System.Drawing.Size(85, 19);
            this.processIdLabel.TabIndex = 2;
            this.processIdLabel.Text = "processId";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 82);
            this.Controls.Add(this.processIdLabel);
            this.Controls.Add(this.threadIdLabel);
            this.Controls.Add(this.activeWindowLabel);
            this.MaximumSize = new System.Drawing.Size(1920, 120);
            this.MinimumSize = new System.Drawing.Size(16, 120);
            this.Name = "MainForm";
            this.Text = "FocusReporter";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label activeWindowLabel;
        private System.Windows.Forms.Label threadIdLabel;
        private System.Windows.Forms.Label processIdLabel;
    }
}

