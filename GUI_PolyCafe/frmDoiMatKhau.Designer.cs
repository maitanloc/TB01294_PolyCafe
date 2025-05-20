namespace GUI_PolyCafe
{
    partial class frmDoiMatKhau
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
            lblMaNV = new Label();
            lblTenNV = new Label();
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblXacNhanMatKhau = new Label();
            txtMaNV = new TextBox();
            txtTenNV = new TextBox();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            ckbHienThiMatKhauCu = new CheckBox();
            ckbHienThiMatKhauMoi = new CheckBox();
            ckbHienThiXacNhanMatKhau = new CheckBox();
            btnDoiMatKhau = new Button();
            btnThoatDoiMatKhau = new Button();
            SuspendLayout();
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(377, 142);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(54, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã NV";
            // 
            // lblTenNV
            // 
            lblTenNV.AutoSize = true;
            lblTenNV.Location = new Point(377, 180);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Size = new Size(104, 20);
            lblTenNV.TabIndex = 1;
            lblTenNV.Text = "Tên Nhân Viên";
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.BackColor = Color.Transparent;
            lblMatKhauCu.Font = new Font("Script MT Bold", 12F);
            lblMatKhauCu.ForeColor = SystemColors.ButtonHighlight;
            lblMatKhauCu.Location = new Point(458, 277);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(118, 24);
            lblMatKhauCu.TabIndex = 2;
            lblMatKhauCu.Text = "Mật Khẩu Cũ";
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.BackColor = Color.Transparent;
            lblMatKhauMoi.Font = new Font("Script MT Bold", 12F);
            lblMatKhauMoi.ForeColor = SystemColors.ControlLightLight;
            lblMatKhauMoi.Location = new Point(458, 340);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(133, 24);
            lblMatKhauMoi.TabIndex = 3;
            lblMatKhauMoi.Text = "Mật Khẩu Mới";
            // 
            // lblXacNhanMatKhau
            // 
            lblXacNhanMatKhau.AutoSize = true;
            lblXacNhanMatKhau.BackColor = Color.Transparent;
            lblXacNhanMatKhau.Font = new Font("Script MT Bold", 12F);
            lblXacNhanMatKhau.ForeColor = SystemColors.ButtonHighlight;
            lblXacNhanMatKhau.Location = new Point(416, 406);
            lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            lblXacNhanMatKhau.Size = new Size(181, 24);
            lblXacNhanMatKhau.TabIndex = 4;
            lblXacNhanMatKhau.Text = "Xác Nhận Mật Khẩu";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(533, 142);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(420, 27);
            txtMaNV.TabIndex = 5;
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(533, 180);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.ReadOnly = true;
            txtTenNV.Size = new Size(420, 27);
            txtTenNV.TabIndex = 6;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(603, 277);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(420, 27);
            txtMatKhauCu.TabIndex = 7;
            txtMatKhauCu.TextChanged += txtMatKhauCu_TextChanged;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(603, 340);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(420, 27);
            txtMatKhauMoi.TabIndex = 8;
            txtMatKhauMoi.TextChanged += txtMatKhauMoi_TextChanged;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(603, 403);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(420, 27);
            txtXacNhanMatKhau.TabIndex = 9;
            txtXacNhanMatKhau.TextChanged += txtXacNhanMatKhau_TextChanged;
            // 
            // ckbHienThiMatKhauCu
            // 
            ckbHienThiMatKhauCu.AutoSize = true;
            ckbHienThiMatKhauCu.BackColor = Color.Transparent;
            ckbHienThiMatKhauCu.ForeColor = SystemColors.ButtonFace;
            ckbHienThiMatKhauCu.Location = new Point(603, 310);
            ckbHienThiMatKhauCu.Name = "ckbHienThiMatKhauCu";
            ckbHienThiMatKhauCu.Size = new Size(86, 24);
            ckbHienThiMatKhauCu.TabIndex = 10;
            ckbHienThiMatKhauCu.Text = "Hiển Thị";
            ckbHienThiMatKhauCu.UseVisualStyleBackColor = false;
            ckbHienThiMatKhauCu.CheckedChanged += ckbHienThiMatKhauCu_CheckedChanged;
            // 
            // ckbHienThiMatKhauMoi
            // 
            ckbHienThiMatKhauMoi.AutoSize = true;
            ckbHienThiMatKhauMoi.BackColor = Color.Transparent;
            ckbHienThiMatKhauMoi.ForeColor = SystemColors.ButtonHighlight;
            ckbHienThiMatKhauMoi.Location = new Point(603, 373);
            ckbHienThiMatKhauMoi.Name = "ckbHienThiMatKhauMoi";
            ckbHienThiMatKhauMoi.Size = new Size(86, 24);
            ckbHienThiMatKhauMoi.TabIndex = 11;
            ckbHienThiMatKhauMoi.Text = "Hiển Thị";
            ckbHienThiMatKhauMoi.UseVisualStyleBackColor = false;
            ckbHienThiMatKhauMoi.CheckedChanged += ckbHienThiMatKhauMoi_CheckedChanged;
            // 
            // ckbHienThiXacNhanMatKhau
            // 
            ckbHienThiXacNhanMatKhau.AutoSize = true;
            ckbHienThiXacNhanMatKhau.BackColor = Color.Transparent;
            ckbHienThiXacNhanMatKhau.ForeColor = SystemColors.ButtonHighlight;
            ckbHienThiXacNhanMatKhau.Location = new Point(603, 436);
            ckbHienThiXacNhanMatKhau.Name = "ckbHienThiXacNhanMatKhau";
            ckbHienThiXacNhanMatKhau.Size = new Size(86, 24);
            ckbHienThiXacNhanMatKhau.TabIndex = 12;
            ckbHienThiXacNhanMatKhau.Text = "Hiển Thị";
            ckbHienThiXacNhanMatKhau.UseVisualStyleBackColor = false;
            ckbHienThiXacNhanMatKhau.CheckedChanged += ckbHienThiXacNhanMatKhau_CheckedChanged;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(437, 466);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(269, 52);
            btnDoiMatKhau.TabIndex = 13;
            btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // btnThoatDoiMatKhau
            // 
            btnThoatDoiMatKhau.Location = new Point(733, 466);
            btnThoatDoiMatKhau.Name = "btnThoatDoiMatKhau";
            btnThoatDoiMatKhau.Size = new Size(269, 52);
            btnThoatDoiMatKhau.TabIndex = 14;
            btnThoatDoiMatKhau.Text = "Thoát";
            btnThoatDoiMatKhau.UseVisualStyleBackColor = true;
            btnThoatDoiMatKhau.Click += btnThoatDoiMatKhau_Click;
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Strong_Password_Educational_Video;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1130, 650);
            Controls.Add(btnThoatDoiMatKhau);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(ckbHienThiXacNhanMatKhau);
            Controls.Add(ckbHienThiMatKhauMoi);
            Controls.Add(ckbHienThiMatKhauCu);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(txtTenNV);
            Controls.Add(txtMaNV);
            Controls.Add(lblXacNhanMatKhau);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblMatKhauCu);
            Controls.Add(lblTenNV);
            Controls.Add(lblMaNV);
            Name = "frmDoiMatKhau";
            Text = "frmDoiMatKhau";
            Load += frmDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaNV;
        private Label lblTenNV;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblXacNhanMatKhau;
        private TextBox txtMaNV;
        private TextBox txtTenNV;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhanMatKhau;
        private CheckBox ckbHienThiMatKhauCu;
        private CheckBox ckbHienThiMatKhauMoi;
        private CheckBox ckbHienThiXacNhanMatKhau;
        private Button btnDoiMatKhau;
        private Button btnThoatDoiMatKhau;
    }
}