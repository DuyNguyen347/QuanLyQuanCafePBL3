namespace QuanLyQuanCafe
{
    partial class Gop_Ban_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Gop1 = new System.Windows.Forms.Button();
            this.BT_Gop2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bạn muốn chọn hình thức gộp bàn nào?";
            // 
            // BT_Gop1
            // 
            this.BT_Gop1.BackColor = System.Drawing.Color.GhostWhite;
            this.BT_Gop1.Location = new System.Drawing.Point(24, 127);
            this.BT_Gop1.Name = "BT_Gop1";
            this.BT_Gop1.Size = new System.Drawing.Size(190, 31);
            this.BT_Gop1.TabIndex = 1;
            this.BT_Gop1.Text = "Gộp bàn như không gộp";
            this.BT_Gop1.UseVisualStyleBackColor = false;
            this.BT_Gop1.Click += new System.EventHandler(this.BT_Gop1_Click);
            // 
            // BT_Gop2
            // 
            this.BT_Gop2.BackColor = System.Drawing.Color.GhostWhite;
            this.BT_Gop2.Location = new System.Drawing.Point(244, 127);
            this.BT_Gop2.Name = "BT_Gop2";
            this.BT_Gop2.Size = new System.Drawing.Size(190, 31);
            this.BT_Gop2.TabIndex = 2;
            this.BT_Gop2.Text = "Gộp nhiều bàn thành một";
            this.BT_Gop2.UseVisualStyleBackColor = false;
            this.BT_Gop2.Click += new System.EventHandler(this.BT_Gop2_Click);
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(473, 214);
            this.Controls.Add(this.BT_Gop2);
            this.Controls.Add(this.BT_Gop1);
            this.Controls.Add(this.label1);
            this.Name = "MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Gop1;
        private System.Windows.Forms.Button BT_Gop2;
    }
}