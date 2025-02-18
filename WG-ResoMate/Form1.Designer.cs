namespace WG_ResoMate
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn1080p = new System.Windows.Forms.Button();
            this.btn4K = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1080p
            // 
            this.btn1080p.Location = new System.Drawing.Point(133, 199);
            this.btn1080p.Margin = new System.Windows.Forms.Padding(4);
            this.btn1080p.Name = "btn1080p";
            this.btn1080p.Size = new System.Drawing.Size(267, 150);
            this.btn1080p.TabIndex = 0;
            this.btn1080p.Text = "Set to 1080p Resolution\r\n(1920 x 1080 pixels)";
            this.btn1080p.UseVisualStyleBackColor = true;
            this.btn1080p.Click += new System.EventHandler(this.btn1080p_Click);
            // 
            // btn4K
            // 
            this.btn4K.Location = new System.Drawing.Point(480, 124);
            this.btn4K.Margin = new System.Windows.Forms.Padding(4);
            this.btn4K.Name = "btn4K";
            this.btn4K.Size = new System.Drawing.Size(533, 300);
            this.btn4K.TabIndex = 1;
            this.btn4K.Text = "Set to 4K Resolution.\r\n(3840 x 2160 pixels)";
            this.btn4K.UseVisualStyleBackColor = true;
            this.btn4K.Click += new System.EventHandler(this.btn4K_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.AutoSize = true;
            this.labelFooter.Location = new System.Drawing.Point(12, 529);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(349, 16);
            this.labelFooter.TabIndex = 2;
            this.labelFooter.Text = "Version 1.0 - © 2025 Pangeran Wiguan. All rights reserved.";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1067, 28);
            this.mainMenuStrip.TabIndex = 3;
            this.mainMenuStrip.Text = "Main Menu";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(64, 24);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btn4K);
            this.Controls.Add(this.btn1080p);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "WG-ResoMate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1080p;
        private System.Windows.Forms.Button btn4K;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
    }
}

