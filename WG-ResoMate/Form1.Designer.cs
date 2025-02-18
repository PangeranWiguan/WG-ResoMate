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
            this.btn1080p = new System.Windows.Forms.Button();
            this.btn4K = new System.Windows.Forms.Button();
            this.footer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn1080p
            // 
            this.btn1080p.Location = new System.Drawing.Point(114, 161);
            this.btn1080p.Name = "btn1080p";
            this.btn1080p.Size = new System.Drawing.Size(101, 23);
            this.btn1080p.TabIndex = 0;
            this.btn1080p.Text = "Set 1920x1080";
            this.btn1080p.UseVisualStyleBackColor = true;
            this.btn1080p.Click += new System.EventHandler(this.btn1080p_Click);
            // 
            // btn4K
            // 
            this.btn4K.Location = new System.Drawing.Point(493, 161);
            this.btn4K.Name = "btn4K";
            this.btn4K.Size = new System.Drawing.Size(75, 23);
            this.btn4K.TabIndex = 1;
            this.btn4K.Text = "Set 4K";
            this.btn4K.UseVisualStyleBackColor = true;
            this.btn4K.Click += new System.EventHandler(this.btn4K_Click);
            // 
            // footer
            // 
            this.footer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.footer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.footer.Cursor = System.Windows.Forms.Cursors.No;
            this.footer.Location = new System.Drawing.Point(596, 425);
            this.footer.Name = "footer";
            this.footer.ReadOnly = true;
            this.footer.Size = new System.Drawing.Size(192, 13);
            this.footer.TabIndex = 4;
            this.footer.Text = "Version 0.1 © 2025 Pangeran Wiguan";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.btn4K);
            this.Controls.Add(this.btn1080p);
            this.Name = "Form1";
            this.Text = "WG-ResoMate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1080p;
        private System.Windows.Forms.Button btn4K;
        private System.Windows.Forms.TextBox footer;
    }
}

