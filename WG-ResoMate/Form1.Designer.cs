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
            this.labelFooter = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelNativeResolution = new System.Windows.Forms.Label();
            this.LabelDisplayResolution = new System.Windows.Forms.Label();
            this.ButtonChangeRes = new System.Windows.Forms.Button();
            this.ToggleAutoClose = new System.Windows.Forms.CheckBox();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout,
            this.ToggleTheme});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.ShowItemToolTips = true;
            this.MenuStrip.Size = new System.Drawing.Size(1067, 30);
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
            this.LabelNativeResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNativeResolution.Location = new System.Drawing.Point(19, 50);
            this.LabelNativeResolution.Name = "LabelNativeResolution";
            this.LabelNativeResolution.Size = new System.Drawing.Size(163, 25);
            this.LabelNativeResolution.TabIndex = 4;
            this.LabelNativeResolution.Text = "Native Resolution";
            // 
            // LabelDisplayResolution
            // 
            this.LabelDisplayResolution.AutoSize = true;
            this.LabelDisplayResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDisplayResolution.Location = new System.Drawing.Point(19, 90);
            this.LabelDisplayResolution.Name = "LabelDisplayResolution";
            this.LabelDisplayResolution.Size = new System.Drawing.Size(172, 25);
            this.LabelDisplayResolution.TabIndex = 5;
            this.LabelDisplayResolution.Text = "Display Resolution";
            // 
            // ButtonChangeRes
            // 
            this.ButtonChangeRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChangeRes.Location = new System.Drawing.Point(24, 216);
            this.ButtonChangeRes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonChangeRes.Name = "ButtonChangeRes";
            this.ButtonChangeRes.Size = new System.Drawing.Size(267, 150);
            this.ButtonChangeRes.TabIndex = 7;
            this.ButtonChangeRes.Text = "Change Resolution";
            this.ButtonChangeRes.UseVisualStyleBackColor = true;
            this.ButtonChangeRes.Click += new System.EventHandler(this.ButtonChangeRes_Click);
            // 
            // ToggleAutoClose
            // 
            this.ToggleAutoClose.AutoSize = true;
            this.ToggleAutoClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToggleAutoClose.Location = new System.Drawing.Point(19, 151);
            this.ToggleAutoClose.Name = "ToggleAutoClose";
            this.ToggleAutoClose.Size = new System.Drawing.Size(212, 29);
            this.ToggleAutoClose.TabIndex = 8;
            this.ToggleAutoClose.Text = "Auto Close Disabled";
            this.ToggleAutoClose.UseVisualStyleBackColor = true;
            this.ToggleAutoClose.CheckedChanged += new System.EventHandler(this.ToggleAutoClose_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ToggleAutoClose);
            this.Controls.Add(this.ButtonChangeRes);
            this.Controls.Add(this.LabelDisplayResolution);
            this.Controls.Add(this.LabelNativeResolution);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "WG-ResoMate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem ToggleTheme;
        private System.Windows.Forms.Label LabelNativeResolution;
        private System.Windows.Forms.Label LabelDisplayResolution;
        private System.Windows.Forms.Button ButtonChangeRes;
        private System.Windows.Forms.CheckBox ToggleAutoClose;
    }
}

