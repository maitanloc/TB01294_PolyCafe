namespace GUI_PolyCafe
{
    partial class frmNhanVien
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
            lblNhanVien = new Label();
            dgvNhanVien = new DataGridView();
            txtTimKemNhanVien = new TextBox();
            btnTimKiemNhanVien = new Button();
            grpNhanVien = new GroupBox();
            panel1 = new Panel();
            rdoNhanVien = new RadioButton();
            rdoQuanLy = new RadioButton();
            rdoTamNgung = new RadioButton();
            rdoDangHoatDong = new RadioButton();
            txtMatKhau = new TextBox();
            txtEmail = new TextBox();
            txtHoTen = new TextBox();
            txtMaNV = new TextBox();
            lblTinhTrang = new Label();
            lblVaiTro = new Label();
            lblMatKhau = new Label();
            lblEmail = new Label();
            lblHoTen = new Label();
            lblMaNV = new Label();
            lblThongTinNhanVien = new Label();
            btnThemNhanVien = new Button();
            btnSuaNhanVien = new Button();
            btnDanhSachNhanVien = new Button();
            btnXoaNhanVien = new Button();
            btnLamMoiNhanVien = new Button();
            btnThoatNhanVien = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            grpNhanVien.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Script MT Bold", 20F);
            lblNhanVien.Location = new Point(12, 9);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(166, 41);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "Nhân Viên";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(15, 58);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(1108, 253);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // txtTimKemNhanVien
            // 
            txtTimKemNhanVien.Location = new Point(769, 25);
            txtTimKemNhanVien.Name = "txtTimKemNhanVien";
            txtTimKemNhanVien.Size = new Size(256, 27);
            txtTimKemNhanVien.TabIndex = 2;
            txtTimKemNhanVien.TextChanged += txtTimKemNhanVien_TextChanged;
            // 
            // btnTimKiemNhanVien
            // 
            btnTimKiemNhanVien.Location = new Point(1031, 23);
            btnTimKiemNhanVien.Name = "btnTimKiemNhanVien";
            btnTimKiemNhanVien.Size = new Size(92, 27);
            btnTimKiemNhanVien.TabIndex = 3;
            btnTimKiemNhanVien.Text = "Tìm Kiếm";
            btnTimKiemNhanVien.UseVisualStyleBackColor = true;
            btnTimKiemNhanVien.Click += btnTimKiemNhanVien_Click;
            // 
            // grpNhanVien
            // 
            grpNhanVien.Controls.Add(panel1);
            grpNhanVien.Controls.Add(rdoTamNgung);
            grpNhanVien.Controls.Add(rdoDangHoatDong);
            grpNhanVien.Controls.Add(txtMatKhau);
            grpNhanVien.Controls.Add(txtEmail);
            grpNhanVien.Controls.Add(txtHoTen);
            grpNhanVien.Controls.Add(txtMaNV);
            grpNhanVien.Controls.Add(lblTinhTrang);
            grpNhanVien.Controls.Add(lblVaiTro);
            grpNhanVien.Controls.Add(lblMatKhau);
            grpNhanVien.Controls.Add(lblEmail);
            grpNhanVien.Controls.Add(lblHoTen);
            grpNhanVien.Controls.Add(lblMaNV);
            grpNhanVien.Location = new Point(21, 369);
            grpNhanVien.Name = "grpNhanVien";
            grpNhanVien.Size = new Size(1102, 202);
            grpNhanVien.TabIndex = 4;
            grpNhanVien.TabStop = false;
            grpNhanVien.Text = "Nhân Viên";
            // 
            // panel1
            // 
            panel1.Controls.Add(rdoNhanVien);
            panel1.Controls.Add(rdoQuanLy);
            panel1.Location = new Point(667, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 45);
            panel1.TabIndex = 20;
            // 
            // rdoNhanVien
            // 
            rdoNhanVien.AutoSize = true;
            rdoNhanVien.Location = new Point(15, 17);
            rdoNhanVien.Name = "rdoNhanVien";
            rdoNhanVien.Size = new Size(98, 24);
            rdoNhanVien.TabIndex = 16;
            rdoNhanVien.TabStop = true;
            rdoNhanVien.Text = "Nhân Viên";
            rdoNhanVien.UseVisualStyleBackColor = true;
            // 
            // rdoQuanLy
            // 
            rdoQuanLy.AutoSize = true;
            rdoQuanLy.Location = new Point(296, 17);
            rdoQuanLy.Name = "rdoQuanLy";
            rdoQuanLy.Size = new Size(82, 24);
            rdoQuanLy.TabIndex = 17;
            rdoQuanLy.TabStop = true;
            rdoQuanLy.Text = "Quản Lý";
            rdoQuanLy.UseVisualStyleBackColor = true;
            // 
            // rdoTamNgung
            // 
            rdoTamNgung.AutoSize = true;
            rdoTamNgung.Location = new Point(963, 141);
            rdoTamNgung.Name = "rdoTamNgung";
            rdoTamNgung.Size = new Size(109, 24);
            rdoTamNgung.TabIndex = 19;
            rdoTamNgung.TabStop = true;
            rdoTamNgung.Text = "Tạm Ngưng";
            rdoTamNgung.UseVisualStyleBackColor = true;
            // 
            // rdoDangHoatDong
            // 
            rdoDangHoatDong.AutoSize = true;
            rdoDangHoatDong.Location = new Point(682, 143);
            rdoDangHoatDong.Name = "rdoDangHoatDong";
            rdoDangHoatDong.Size = new Size(144, 24);
            rdoDangHoatDong.TabIndex = 18;
            rdoDangHoatDong.TabStop = true;
            rdoDangHoatDong.Text = "Đang Hoạt Động";
            rdoDangHoatDong.UseVisualStyleBackColor = true;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(98, 157);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(413, 27);
            txtMatKhau.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(98, 114);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(413, 27);
            txtEmail.TabIndex = 9;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(98, 70);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(413, 27);
            txtHoTen.TabIndex = 8;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(98, 28);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(413, 27);
            txtMaNV.TabIndex = 7;
            txtMaNV.TextChanged += txtMaNV_TextChanged;
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(583, 143);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new Size(78, 20);
            lblTinhTrang.TabIndex = 6;
            lblTinhTrang.Text = "Tình Trạng";
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(583, 91);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(54, 20);
            lblVaiTro.TabIndex = 5;
            lblVaiTro.Text = "Vai Trò";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(28, 160);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(72, 20);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật Khẩu";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(28, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(28, 70);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(56, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ Tên";
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(28, 31);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(54, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã NV";
            // 
            // lblThongTinNhanVien
            // 
            lblThongTinNhanVien.AutoSize = true;
            lblThongTinNhanVien.Font = new Font("Script MT Bold", 20F);
            lblThongTinNhanVien.Location = new Point(21, 325);
            lblThongTinNhanVien.Name = "lblThongTinNhanVien";
            lblThongTinNhanVien.Size = new Size(253, 41);
            lblThongTinNhanVien.TabIndex = 5;
            lblThongTinNhanVien.Text = "Nhập Thông Tin";
            // 
            // btnThemNhanVien
            // 
            btnThemNhanVien.Location = new Point(21, 577);
            btnThemNhanVien.Name = "btnThemNhanVien";
            btnThemNhanVien.Size = new Size(157, 72);
            btnThemNhanVien.TabIndex = 6;
            btnThemNhanVien.Text = "Thêm";
            btnThemNhanVien.UseVisualStyleBackColor = true;
            btnThemNhanVien.Click += btnThemNhanVien_Click;
            // 
            // btnSuaNhanVien
            // 
            btnSuaNhanVien.Location = new Point(207, 577);
            btnSuaNhanVien.Name = "btnSuaNhanVien";
            btnSuaNhanVien.Size = new Size(142, 72);
            btnSuaNhanVien.TabIndex = 7;
            btnSuaNhanVien.Text = "Sửa";
            btnSuaNhanVien.UseVisualStyleBackColor = true;
            btnSuaNhanVien.Click += btnSuaNhanVien_Click;
            // 
            // btnDanhSachNhanVien
            // 
            btnDanhSachNhanVien.Location = new Point(388, 577);
            btnDanhSachNhanVien.Name = "btnDanhSachNhanVien";
            btnDanhSachNhanVien.Size = new Size(144, 72);
            btnDanhSachNhanVien.TabIndex = 8;
            btnDanhSachNhanVien.Text = "Danh Sách";
            btnDanhSachNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnXoaNhanVien
            // 
            btnXoaNhanVien.Location = new Point(594, 577);
            btnXoaNhanVien.Name = "btnXoaNhanVien";
            btnXoaNhanVien.Size = new Size(150, 72);
            btnXoaNhanVien.TabIndex = 9;
            btnXoaNhanVien.Text = "Xóa";
            btnXoaNhanVien.UseVisualStyleBackColor = true;
            btnXoaNhanVien.Click += btnXoaNhanVien_Click_1;
            // 
            // btnLamMoiNhanVien
            // 
            btnLamMoiNhanVien.Location = new Point(785, 577);
            btnLamMoiNhanVien.Name = "btnLamMoiNhanVien";
            btnLamMoiNhanVien.Size = new Size(144, 72);
            btnLamMoiNhanVien.TabIndex = 10;
            btnLamMoiNhanVien.Text = "Làm Mới";
            btnLamMoiNhanVien.UseVisualStyleBackColor = true;
            btnLamMoiNhanVien.Click += btnLamMoiNhanVien_Click;
            // 
            // btnThoatNhanVien
            // 
            btnThoatNhanVien.Location = new Point(975, 577);
            btnThoatNhanVien.Name = "btnThoatNhanVien";
            btnThoatNhanVien.Size = new Size(148, 72);
            btnThoatNhanVien.TabIndex = 11;
            btnThoatNhanVien.Text = "Thoát";
            btnThoatNhanVien.UseVisualStyleBackColor = true;
            btnThoatNhanVien.Click += btnThoatNhanVien_Click;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1145, 654);
            Controls.Add(btnThoatNhanVien);
            Controls.Add(btnLamMoiNhanVien);
            Controls.Add(btnXoaNhanVien);
            Controls.Add(btnDanhSachNhanVien);
            Controls.Add(btnSuaNhanVien);
            Controls.Add(btnThemNhanVien);
            Controls.Add(lblThongTinNhanVien);
            Controls.Add(grpNhanVien);
            Controls.Add(btnTimKiemNhanVien);
            Controls.Add(txtTimKemNhanVien);
            Controls.Add(dgvNhanVien);
            Controls.Add(lblNhanVien);
            DoubleBuffered = true;
            Name = "frmNhanVien";
            Text = "frmNhanVien";
            Load += frmNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            grpNhanVien.ResumeLayout(false);
            grpNhanVien.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNhanVien;
        private DataGridView dgvNhanVien;
        private TextBox txtTimKemNhanVien;
        private Button btnTimKiemNhanVien;
        private GroupBox grpNhanVien;
        private Label lblThongTinNhanVien;
        private TextBox txtMatKhau;
        private TextBox txtEmail;
        private TextBox txtHoTen;
        private TextBox txtMaNV;
        private Label lblTinhTrang;
        private Label lblVaiTro;
        private Label lblMatKhau;
        private Label lblEmail;
        private Label lblHoTen;
        private Label lblMaNV;
        private Button btnThemNhanVien;
        private Button btnSuaNhanVien;
        private Button btnDanhSachNhanVien;
        private Button btnXoaNhanVien;
        private Button btnLamMoiNhanVien;
        private Button btnThoatNhanVien;
        private Panel panel1;
        private RadioButton rdoNhanVien;
        private RadioButton rdoQuanLy;
        private RadioButton rdoTamNgung;
        private RadioButton rdoDangHoatDong;
    }
}