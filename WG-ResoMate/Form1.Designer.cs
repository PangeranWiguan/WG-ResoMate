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
            this.Button1080p = new System.Windows.Forms.Button();
            this.Button4K = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelNativeResolution = new System.Windows.Forms.Label();
            this.LabelDisplayResolution = new System.Windows.Forms.Label();
            this.ButtonChangeRes = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1080p
            // 
            this.Button1080p.Location = new System.Drawing.Point(114, 284);
            this.Button1080p.Name = "Button1080p";
            this.Button1080p.Size = new System.Drawing.Size(200, 122);
            this.Button1080p.TabIndex = 0;
            this.Button1080p.Text = "Set to 1080p Resolution\r\n(1920 x 1080 pixels)";
            this.Button1080p.UseVisualStyleBackColor = true;
            // 
            // Button4K
            // 
            this.Button4K.Location = new System.Drawing.Point(365, 172);
            this.Button4K.Name = "Button4K";
            this.Button4K.Size = new System.Drawing.Size(400, 244);
            this.Button4K.TabIndex = 1;
            this.Button4K.Text = "Set to 4K Resolution.\r\n(3840 x 2160 pixels)";
            this.Button4K.UseVisualStyleBackColor = true;
            // 
            // labelFooter
            // 
            this.labelFooter.AutoSize = true;
            this.labelFooter.Location = new System.Drawing.Point(9, 430);
            this.labelFooter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(325, 15);
            this.labelFooter.TabIndex = 2;
            this.labelFooter.Text = "Version 1.0 - © 2025 Pangeran Wiguan. All rights reserved.";
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout,
            this.ToggleTheme});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(800, 30);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "Main Menu";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(64, 26);
            this.ToolStripMenuItemAbout.Text = "About";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // ToggleTheme
            // 
            this.ToggleTheme.Name = "ToggleTheme";
            this.ToggleTheme.Size = new System.Drawing.Size(118, 26);
            this.ToggleTheme.Text = "Toggle Theme";
            this.ToggleTheme.Click += new System.EventHandler(this.ToggleTheme_Click);
            // 
            // LabelNativeResolution
            // 
            this.LabelNativeResolution.AutoSize = true;
            this.LabelNativeResolution.Location = new System.Drawing.Point(9, 39);
            this.LabelNativeResolution.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelNativeResolution.Name = "LabelNativeResolution";
            this.LabelNativeResolution.Size = new System.Drawing.Size(103, 15);
            this.LabelNativeResolution.TabIndex = 4;
            this.LabelNativeResolution.Text = "Native Resolution";
            // 
            // LabelDisplayResolution
            // 
            this.LabelDisplayResolution.AutoSize = true;
            this.LabelDisplayResolution.Location = new System.Drawing.Point(14, 69);
            this.LabelDisplayResolution.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDisplayResolution.Name = "LabelDisplayResolution";
            this.LabelDisplayResolution.Size = new System.Drawing.Size(109, 15);
            this.LabelDisplayResolution.TabIndex = 5;
            this.LabelDisplayResolution.Text = "Display Resolution";
            // 
            // ButtonChangeRes
            // 
            this.ButtonChangeRes.Location = new System.Drawing.Point(114, 145);
            this.ButtonChangeRes.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonChangeRes.Name = "ButtonChangeRes";
            this.ButtonChangeRes.Size = new System.Drawing.Size(200, 122);
            this.ButtonChangeRes.TabIndex = 7;
            this.ButtonChangeRes.Text = "Change Resolution";
            this.ButtonChangeRes.UseVisualStyleBackColor = true;
            this.ButtonChangeRes.Click += new System.EventHandler(this.ButtonChangeRes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonChangeRes);
            this.Controls.Add(this.LabelDisplayResolution);
            this.Controls.Add(this.LabelNativeResolution);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.Button4K);
            this.Controls.Add(this.Button1080p);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "WG-ResoMate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1080p;
        private System.Windows.Forms.Button Button4K;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem ToggleTheme;
        private System.Windows.Forms.Label LabelNativeResolution;
        private System.Windows.Forms.Label LabelDisplayResolution;
        private System.Windows.Forms.Button ButtonChangeRes;
    }
}

