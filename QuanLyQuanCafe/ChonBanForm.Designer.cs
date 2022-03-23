namespace QuanLyQuanCafe
{
    partial class ChonBanForm
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
            this.BT_OK = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BT_Cancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.FLP_Ban = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BT_OK
            // 
            this.BT_OK.BorderRadius = 5;
            this.BT_OK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BT_OK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BT_OK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BT_OK.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BT_OK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BT_OK.FillColor = System.Drawing.Color.Cyan;
            this.BT_OK.FillColor2 = System.Drawing.Color.Aqua;
            this.BT_OK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_OK.ForeColor = System.Drawing.Color.White;
            this.BT_OK.Location = new System.Drawing.Point(246, 408);
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.Size = new System.Drawing.Size(50, 30);
            this.BT_OK.TabIndex = 1014;
            this.BT_OK.Text = "OK";
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.BorderRadius = 5;
            this.BT_Cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BT_Cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BT_Cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BT_Cancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BT_Cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BT_Cancel.FillColor = System.Drawing.Color.Cyan;
            this.BT_Cancel.FillColor2 = System.Drawing.Color.Aqua;
            this.BT_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Cancel.ForeColor = System.Drawing.Color.White;
            this.BT_Cancel.Location = new System.Drawing.Point(479, 408);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(50, 30);
            this.BT_Cancel.TabIndex = 1015;
            this.BT_Cancel.Text = "Hủy";
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // FLP_Ban
            // 
            this.FLP_Ban.AutoScroll = true;
            this.FLP_Ban.BackColor = System.Drawing.Color.LavenderBlush;
            this.FLP_Ban.Location = new System.Drawing.Point(30, 25);
            this.FLP_Ban.Name = "FLP_Ban";
            this.FLP_Ban.Size = new System.Drawing.Size(450, 375);
            this.FLP_Ban.TabIndex = 1016;
            // 
            // ChonBanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FLP_Ban);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChonBanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChonBanForm";
            this.Load += new System.EventHandler(this.ChonBanForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton BT_OK;
        private Guna.UI2.WinForms.Guna2GradientButton BT_Cancel;
        private System.Windows.Forms.FlowLayoutPanel FLP_Ban;
    }
}