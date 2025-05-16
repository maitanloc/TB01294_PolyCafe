namespace GUI_PolyCafe
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblEmail = new Label();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            txtTaiKhoan = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            ckbGhiNho = new CheckBox();
            lklblQuenMatKhau = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Arial Narrow", 25.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(655, 181);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.White;
            lblEmail.Font = new Font("Segoe UI", 13F);
            lblEmail.Location = new Point(397, 251);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(64, 30);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.BackColor = Color.White;
            lblMatKhau.Font = new Font("Segoe UI", 13F);
            lblMatKhau.Location = new Point(397, 317);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(105, 30);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 13F);
            txtMatKhau.Location = new Point(508, 317);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(546, 36);
            txtMatKhau.TabIndex = 3;
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new Font("Showcard Gothic", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTaiKhoan.Location = new Point(509, 251);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(546, 34);
            txtTaiKhoan.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.Transparent;
            btnDangNhap.BackgroundImage = Properties.Resources.Blue_Modern_Game_Button_Twitch_Panel;
            btnDangNhap.BackgroundImageLayout = ImageLayout.Stretch;
            btnDangNhap.Font = new Font("Segoe UI", 15F);
            btnDangNhap.ForeColor = SystemColors.ActiveCaptionText;
            btnDangNhap.Location = new Point(478, 426);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(177, 64);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.ActiveCaption;
            btnThoat.BackgroundImage = Properties.Resources.Blue_Modern_Game_Button_Twitch_Panel__1_;
            btnThoat.BackgroundImageLayout = ImageLayout.Stretch;
            btnThoat.Font = new Font("Segoe UI", 15F);
            btnThoat.Location = new Point(866, 426);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(189, 64);
            btnThoat.TabIndex = 6;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // ckbGhiNho
            // 
            ckbGhiNho.AutoSize = true;
            ckbGhiNho.BackColor = Color.Transparent;
            ckbGhiNho.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ckbGhiNho.Location = new Point(524, 366);
            ckbGhiNho.Name = "ckbGhiNho";
            ckbGhiNho.Size = new Size(256, 39);
            ckbGhiNho.TabIndex = 7;
            ckbGhiNho.Text = "Ghi Nhớ Tài Khoản";
            ckbGhiNho.UseVisualStyleBackColor = false;
            // 
            // lklblQuenMatKhau
            // 
            lklblQuenMatKhau.AutoSize = true;
            lklblQuenMatKhau.BackColor = Color.Transparent;
            lklblQuenMatKhau.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            lklblQuenMatKhau.LinkColor = Color.Cyan;
            lklblQuenMatKhau.Location = new Point(872, 366);
            lklblQuenMatKhau.Name = "lklblQuenMatKhau";
            lklblQuenMatKhau.Size = new Size(198, 35);
            lklblQuenMatKhau.TabIndex = 8;
            lklblQuenMatKhau.TabStop = true;
            lklblQuenMatKhau.Text = "Quên Mật Khẩu";
            lklblQuenMatKhau.LinkClicked += lklblQuenMatKhau_LinkClicked;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Brown_and_Beige_Illustrated_Coffee_Shop_Presentation__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1082, 608);
            Controls.Add(lklblQuenMatKhau);
            Controls.Add(ckbGhiNho);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtTaiKhoan);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(lblEmail);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblEmail;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private TextBox txtTaiKhoan;
        private Button btnDangNhap;
        private Button btnThoat;
        private CheckBox ckbGhiNho;
        private LinkLabel lklblQuenMatKhau;
    }
}
