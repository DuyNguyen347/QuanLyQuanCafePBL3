namespace QuanLyQuanCafe
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation8 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BtLogin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.LB_Clear = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ReloadAccount = new System.Windows.Forms.Label();
            this.btShowPass = new Guna.UI2.WinForms.Guna2ImageButton();
            this.tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelChangepass = new Guna.UI2.WinForms.Guna2Panel();
            this.btDoiMatKhau = new Guna.UI2.WinForms.Guna2Button();
            this.tbXacNhanPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbGetCode = new Guna.UI2.WinForms.Guna2Button();
            this.panelLogin = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.panelChangepass.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(89, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng nhập";
            // 
            // BtLogin
            // 
            this.BtLogin.BorderRadius = 10;
            this.guna2Transition1.SetDecoration(this.BtLogin, Guna.UI2.AnimatorNS.DecorationType.None);
            this.BtLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtLogin.FillColor = System.Drawing.Color.DarkGreen;
            this.BtLogin.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtLogin.ForeColor = System.Drawing.Color.White;
            this.BtLogin.Location = new System.Drawing.Point(9, 306);
            this.BtLogin.Name = "BtLogin";
            this.BtLogin.Size = new System.Drawing.Size(271, 33);
            this.BtLogin.TabIndex = 8;
            this.BtLogin.Text = "Login";
            this.BtLogin.Click += new System.EventHandler(this.BtLogin_Click_1);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Transition1.SetDecoration(this.guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(722, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 21);
            this.guna2ControlBox1.TabIndex = 9;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2Transition1.SetDecoration(this.guna2ControlBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(679, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(37, 21);
            this.guna2ControlBox2.TabIndex = 10;
            // 
            // LB_Clear
            // 
            this.LB_Clear.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.LB_Clear, Guna.UI2.AnimatorNS.DecorationType.None);
            this.LB_Clear.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Clear.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LB_Clear.Location = new System.Drawing.Point(111, 357);
            this.LB_Clear.Name = "LB_Clear";
            this.LB_Clear.Size = new System.Drawing.Size(58, 24);
            this.LB_Clear.TabIndex = 11;
            this.LB_Clear.Text = "Clear";
            this.LB_Clear.Click += new System.EventHandler(this.LB_Clear_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "eye-slash.png");
            this.imageList1.Images.SetKeyName(1, "eye-slash.png");
            this.imageList1.Images.SetKeyName(2, "User.png");
            // 
            // ReloadAccount
            // 
            this.ReloadAccount.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.ReloadAccount, Guna.UI2.AnimatorNS.DecorationType.None);
            this.ReloadAccount.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadAccount.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ReloadAccount.Location = new System.Drawing.Point(172, 261);
            this.ReloadAccount.Name = "ReloadAccount";
            this.ReloadAccount.Size = new System.Drawing.Size(108, 19);
            this.ReloadAccount.TabIndex = 13;
            this.ReloadAccount.Text = "Quên mật khẩu";
            this.ReloadAccount.Click += new System.EventHandler(this.ReloadAccount_Click);
            // 
            // btShowPass
            // 
            this.btShowPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(29)))), ((int)(((byte)(7)))));
            this.btShowPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btShowPass.BackgroundImage")));
            this.btShowPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btShowPass.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2Transition1.SetDecoration(this.btShowPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btShowPass.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btShowPass.Image = ((System.Drawing.Image)(resources.GetObject("btShowPass.Image")));
            this.btShowPass.ImageOffset = new System.Drawing.Point(0, 0);
            this.btShowPass.ImageRotate = 0F;
            this.btShowPass.ImageSize = new System.Drawing.Size(20, 20);
            this.btShowPass.Location = new System.Drawing.Point(248, 231);
            this.btShowPass.Name = "btShowPass";
            this.btShowPass.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btShowPass.Size = new System.Drawing.Size(20, 20);
            this.btShowPass.TabIndex = 12;
            this.btShowPass.Click += new System.EventHandler(this.btShowPass_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BorderRadius = 10;
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbPassword, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbPassword.DefaultText = "";
            this.tbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbPassword.IconLeft")));
            this.tbPassword.Location = new System.Drawing.Point(9, 226);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.PlaceholderText = "Password";
            this.tbPassword.SelectedText = "";
            this.tbPassword.Size = new System.Drawing.Size(271, 32);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Enter_Keydown);
            // 
            // tbUserName
            // 
            this.tbUserName.BorderRadius = 10;
            this.tbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbUserName, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbUserName.DefaultText = "";
            this.tbUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUserName.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbUserName.IconLeft")));
            this.tbUserName.Location = new System.Drawing.Point(9, 175);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.PlaceholderText = "Username";
            this.tbUserName.SelectedText = "";
            this.tbUserName.Size = new System.Drawing.Size(271, 34);
            this.tbUserName.TabIndex = 5;
            this.tbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Enter_Keydown);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.BackgroundImage")));
            this.guna2Transition1.SetDecoration(this.guna2PictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(9, 3);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(271, 121);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2Transition1.SetDecoration(this.guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, -1);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(393, 452);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // panelChangepass
            // 
            this.panelChangepass.Controls.Add(this.btDoiMatKhau);
            this.panelChangepass.Controls.Add(this.tbXacNhanPass);
            this.panelChangepass.Controls.Add(this.tbNewPass);
            this.panelChangepass.Controls.Add(this.btXacNhan);
            this.panelChangepass.Controls.Add(this.label2);
            this.panelChangepass.Controls.Add(this.label5);
            this.panelChangepass.Controls.Add(this.lbLogin);
            this.panelChangepass.Controls.Add(this.tbEmail);
            this.panelChangepass.Controls.Add(this.tbCode);
            this.panelChangepass.Controls.Add(this.tbGetCode);
            this.guna2Transition1.SetDecoration(this.panelChangepass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelChangepass.Location = new System.Drawing.Point(447, 32);
            this.panelChangepass.Name = "panelChangepass";
            this.panelChangepass.Size = new System.Drawing.Size(290, 386);
            this.panelChangepass.TabIndex = 16;
            this.panelChangepass.Visible = false;
            // 
            // btDoiMatKhau
            // 
            this.btDoiMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.btDoiMatKhau.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btDoiMatKhau.BorderRadius = 10;
            this.btDoiMatKhau.BorderThickness = 1;
            this.guna2Transition1.SetDecoration(this.btDoiMatKhau, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btDoiMatKhau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btDoiMatKhau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btDoiMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btDoiMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btDoiMatKhau.FillColor = System.Drawing.Color.Transparent;
            this.btDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btDoiMatKhau.Location = new System.Drawing.Point(11, 299);
            this.btDoiMatKhau.Name = "btDoiMatKhau";
            this.btDoiMatKhau.Size = new System.Drawing.Size(271, 25);
            this.btDoiMatKhau.TabIndex = 19;
            this.btDoiMatKhau.Text = "Đổi mật khẩu";
            this.btDoiMatKhau.Visible = false;
            this.btDoiMatKhau.Click += new System.EventHandler(this.btDoiMatKhau_Click);
            // 
            // tbXacNhanPass
            // 
            this.tbXacNhanPass.BorderRadius = 10;
            this.tbXacNhanPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbXacNhanPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbXacNhanPass.DefaultText = "";
            this.tbXacNhanPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbXacNhanPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbXacNhanPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbXacNhanPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbXacNhanPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbXacNhanPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbXacNhanPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbXacNhanPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbXacNhanPass.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbXacNhanPass.IconLeft")));
            this.tbXacNhanPass.Location = new System.Drawing.Point(11, 261);
            this.tbXacNhanPass.Name = "tbXacNhanPass";
            this.tbXacNhanPass.PasswordChar = '*';
            this.tbXacNhanPass.PlaceholderText = "Xác nhận mật khẩu";
            this.tbXacNhanPass.SelectedText = "";
            this.tbXacNhanPass.Size = new System.Drawing.Size(271, 32);
            this.tbXacNhanPass.TabIndex = 18;
            this.tbXacNhanPass.Visible = false;
            // 
            // tbNewPass
            // 
            this.tbNewPass.BorderRadius = 10;
            this.tbNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbNewPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbNewPass.DefaultText = "";
            this.tbNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbNewPass.IconLeft")));
            this.tbNewPass.Location = new System.Drawing.Point(11, 223);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '*';
            this.tbNewPass.PlaceholderText = "Mật khẩu mới";
            this.tbNewPass.SelectedText = "";
            this.tbNewPass.Size = new System.Drawing.Size(271, 32);
            this.tbNewPass.TabIndex = 17;
            this.tbNewPass.Visible = false;
            // 
            // btXacNhan
            // 
            this.btXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.btXacNhan.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btXacNhan.BorderRadius = 10;
            this.btXacNhan.BorderThickness = 1;
            this.guna2Transition1.SetDecoration(this.btXacNhan, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXacNhan.FillColor = System.Drawing.Color.Transparent;
            this.btXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXacNhan.ForeColor = System.Drawing.Color.White;
            this.btXacNhan.Location = new System.Drawing.Point(11, 192);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(271, 25);
            this.btXacNhan.TabIndex = 16;
            this.btXacNhan.Text = "Xác nhận";
            this.btXacNhan.Visible = false;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // label2
            // 
            this.guna2Transition1.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(23, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 39);
            this.label2.TabIndex = 15;
            this.label2.Text = "Please enter your email address and we will email to a code to get your account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.label5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(33, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Forget password ?";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lbLogin, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbLogin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbLogin.Location = new System.Drawing.Point(229, 354);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(53, 21);
            this.lbLogin.TabIndex = 13;
            this.lbLogin.Text = "Login";
            this.lbLogin.Click += new System.EventHandler(this.lbLogin_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.BorderRadius = 10;
            this.tbEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbEmail, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbEmail.DefaultText = "";
            this.tbEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEmail.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbEmail.IconLeft")));
            this.tbEmail.Location = new System.Drawing.Point(11, 83);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PasswordChar = '\0';
            this.tbEmail.PlaceholderText = "Email";
            this.tbEmail.SelectedText = "";
            this.tbEmail.Size = new System.Drawing.Size(271, 34);
            this.tbEmail.TabIndex = 5;
            // 
            // tbCode
            // 
            this.tbCode.BorderRadius = 10;
            this.tbCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.tbCode, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbCode.DefaultText = "";
            this.tbCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(27)))), ((int)(((byte)(7)))));
            this.tbCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCode.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbCode.IconLeft")));
            this.tbCode.Location = new System.Drawing.Point(11, 154);
            this.tbCode.Name = "tbCode";
            this.tbCode.PasswordChar = '*';
            this.tbCode.PlaceholderText = "Code";
            this.tbCode.SelectedText = "";
            this.tbCode.Size = new System.Drawing.Size(271, 32);
            this.tbCode.TabIndex = 6;
            this.tbCode.Visible = false;
            // 
            // tbGetCode
            // 
            this.tbGetCode.BackColor = System.Drawing.Color.Transparent;
            this.tbGetCode.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.tbGetCode.BorderRadius = 10;
            this.tbGetCode.BorderThickness = 1;
            this.guna2Transition1.SetDecoration(this.tbGetCode, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tbGetCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tbGetCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tbGetCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tbGetCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tbGetCode.FillColor = System.Drawing.Color.Transparent;
            this.tbGetCode.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGetCode.ForeColor = System.Drawing.Color.White;
            this.tbGetCode.Location = new System.Drawing.Point(11, 123);
            this.tbGetCode.Name = "tbGetCode";
            this.tbGetCode.Size = new System.Drawing.Size(271, 25);
            this.tbGetCode.TabIndex = 8;
            this.tbGetCode.Text = "Lấy mã";
            this.tbGetCode.Click += new System.EventHandler(this.tbGetCode_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.ReloadAccount);
            this.panelLogin.Controls.Add(this.tbUserName);
            this.panelLogin.Controls.Add(this.btShowPass);
            this.panelLogin.Controls.Add(this.guna2PictureBox2);
            this.panelLogin.Controls.Add(this.tbPassword);
            this.panelLogin.Controls.Add(this.LB_Clear);
            this.panelLogin.Controls.Add(this.BtLogin);
            this.guna2Transition1.SetDecoration(this.panelLogin, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelLogin.Location = new System.Drawing.Point(447, 32);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(290, 386);
            this.panelLogin.TabIndex = 17;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.Cursor = null;
            animation8.AnimateOnlyDifferences = true;
            animation8.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.BlindCoeff")));
            animation8.LeafCoeff = 0F;
            animation8.MaxTime = 1F;
            animation8.MinTime = 0F;
            animation8.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicCoeff")));
            animation8.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicShift")));
            animation8.MosaicSize = 0;
            animation8.Padding = new System.Windows.Forms.Padding(0);
            animation8.RotateCoeff = 0F;
            animation8.RotateLimit = 0F;
            animation8.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.ScaleCoeff")));
            animation8.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.SlideCoeff")));
            animation8.TimeCoeff = 0F;
            animation8.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(29)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelChangepass);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2PictureBox1);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.panelChangepass.ResumeLayout(false);
            this.panelChangepass.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbUserName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button BtLogin;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private System.Windows.Forms.Label LB_Clear;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2ImageButton btShowPass;
        private System.Windows.Forms.Label ReloadAccount;
        private Guna.UI2.WinForms.Guna2Panel panelLogin;
        private Guna.UI2.WinForms.Guna2Panel panelChangepass;
        private Guna.UI2.WinForms.Guna2Button btDoiMatKhau;
        private Guna.UI2.WinForms.Guna2TextBox tbXacNhanPass;
        private Guna.UI2.WinForms.Guna2TextBox tbNewPass;
        private Guna.UI2.WinForms.Guna2Button btXacNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbLogin;
        private Guna.UI2.WinForms.Guna2TextBox tbEmail;
        private Guna.UI2.WinForms.Guna2TextBox tbCode;
        private Guna.UI2.WinForms.Guna2Button tbGetCode;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
    }
}

