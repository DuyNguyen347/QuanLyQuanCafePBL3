namespace QuanLyQuanCafe
{
    partial class ReloadAccount
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
            this.tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbInfor = new System.Windows.Forms.Label();
            this.btXacnhan = new Guna.UI2.WinForms.Guna2Button();
            this.tbCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btOk = new Guna.UI2.WinForms.Guna2Button();
            this.btCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbEmail
            // 
            this.tbEmail.BorderRadius = 3;
            this.tbEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEmail.DefaultText = "";
            this.tbEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.Location = new System.Drawing.Point(54, 26);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PasswordChar = '\0';
            this.tbEmail.PlaceholderText = "Nhập email";
            this.tbEmail.SelectedText = "";
            this.tbEmail.Size = new System.Drawing.Size(238, 42);
            this.tbEmail.TabIndex = 1;
            // 
            // lbInfor
            // 
            this.lbInfor.AutoSize = true;
            this.lbInfor.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor.Location = new System.Drawing.Point(65, 71);
            this.lbInfor.Name = "lbInfor";
            this.lbInfor.Size = new System.Drawing.Size(202, 15);
            this.lbInfor.TabIndex = 3;
            this.lbInfor.Text = "Email Không tồn tại trong hệ thống";
            this.lbInfor.Visible = false;
            // 
            // btXacnhan
            // 
            this.btXacnhan.BorderRadius = 4;
            this.btXacnhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXacnhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXacnhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXacnhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXacnhan.FillColor = System.Drawing.Color.Olive;
            this.btXacnhan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btXacnhan.ForeColor = System.Drawing.Color.White;
            this.btXacnhan.Location = new System.Drawing.Point(87, 117);
            this.btXacnhan.Name = "btXacnhan";
            this.btXacnhan.Size = new System.Drawing.Size(180, 52);
            this.btXacnhan.TabIndex = 4;
            this.btXacnhan.Text = "Gửi mã CODE";
            this.btXacnhan.Click += new System.EventHandler(this.btXacnhan_Click);
            // 
            // tbCode
            // 
            this.tbCode.BorderRadius = 3;
            this.tbCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCode.DefaultText = "";
            this.tbCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCode.Location = new System.Drawing.Point(87, 194);
            this.tbCode.Name = "tbCode";
            this.tbCode.PasswordChar = '\0';
            this.tbCode.PlaceholderText = "Nhập mã code";
            this.tbCode.SelectedText = "";
            this.tbCode.Size = new System.Drawing.Size(180, 36);
            this.tbCode.TabIndex = 5;
            this.tbCode.Visible = false;
            // 
            // btOk
            // 
            this.btOk.BorderRadius = 4;
            this.btOk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btOk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btOk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btOk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btOk.FillColor = System.Drawing.Color.Olive;
            this.btOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btOk.ForeColor = System.Drawing.Color.White;
            this.btOk.Location = new System.Drawing.Point(54, 249);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(117, 52);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "Lấy Tài Khoản";
            this.btOk.Visible = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.BorderRadius = 4;
            this.btCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCancel.FillColor = System.Drawing.Color.Olive;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.Location = new System.Drawing.Point(193, 249);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(117, 52);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.Visible = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ReloadAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 450);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.btXacnhan);
            this.Controls.Add(this.lbInfor);
            this.Controls.Add(this.tbEmail);
            this.Name = "ReloadAccount";
            this.Text = "ReloadAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbEmail;
        private System.Windows.Forms.Label lbInfor;
        private Guna.UI2.WinForms.Guna2Button btXacnhan;
        private Guna.UI2.WinForms.Guna2TextBox tbCode;
        private Guna.UI2.WinForms.Guna2Button btOk;
        private Guna.UI2.WinForms.Guna2Button btCancel;
    }
}