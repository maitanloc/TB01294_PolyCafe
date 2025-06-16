using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViewColumns();
            loadDanhSachNhanVien();

            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting_1;
            dgvNhanVien.CellEndEdit += dgvNhanVien_CellEndEdit_1;
        }

        private void ConfigureDataGridViewColumns()
        {
            dgvNhanVien.AutoGenerateColumns = false;

            if (!dgvNhanVien.Columns.Contains("MaNhanVien"))
            {
                DataGridViewTextBoxColumn maNVColumn = new DataGridViewTextBoxColumn();
                maNVColumn.Name = "MaNhanVien";
                maNVColumn.HeaderText = "Mã Nhân Viên";
                maNVColumn.DataPropertyName = "MaNhanVien";
                maNVColumn.ReadOnly = true; // Không cho chỉnh sửa mã nhân viên
                dgvNhanVien.Columns.Add(maNVColumn);
            }

            if (!dgvNhanVien.Columns.Contains("HoTen"))
            {
                DataGridViewTextBoxColumn hoTenColumn = new DataGridViewTextBoxColumn();
                hoTenColumn.Name = "HoTen";
                hoTenColumn.HeaderText = "Họ Tên";
                hoTenColumn.DataPropertyName = "HoTen";
                dgvNhanVien.Columns.Add(hoTenColumn);
            }

            if (!dgvNhanVien.Columns.Contains("Email"))
            {
                DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn();
                emailColumn.Name = "Email";
                emailColumn.HeaderText = "Email";
                emailColumn.DataPropertyName = "Email";
                dgvNhanVien.Columns.Add(emailColumn);
            }

            if (!dgvNhanVien.Columns.Contains("MatKhau"))
            {
                DataGridViewTextBoxColumn matKhauColumn = new DataGridViewTextBoxColumn();
                matKhauColumn.Name = "MatKhau";
                matKhauColumn.HeaderText = "Mật Khẩu";
                matKhauColumn.DataPropertyName = "MatKhau";
                dgvNhanVien.Columns.Add(matKhauColumn);
            }

            if (!dgvNhanVien.Columns.Contains("VaiTroDisplay"))
            {
                DataGridViewComboBoxColumn vaiTroColumn = new DataGridViewComboBoxColumn();
                vaiTroColumn.Name = "VaiTroDisplay";
                vaiTroColumn.HeaderText = "Vai Trò";
                vaiTroColumn.Items.Add("Nhân Viên");
                vaiTroColumn.Items.Add("Quản Lý");
                dgvNhanVien.Columns.Add(vaiTroColumn);
            }

            if (!dgvNhanVien.Columns.Contains("TrangThaiDisplay"))
            {
                DataGridViewComboBoxColumn trangThaiColumn = new DataGridViewComboBoxColumn();
                trangThaiColumn.Name = "TrangThaiDisplay";
                trangThaiColumn.HeaderText = "Trạng Thái";
                trangThaiColumn.Items.Add("Đang Hoạt Động");
                trangThaiColumn.Items.Add("Tạm Ngưng");
                dgvNhanVien.Columns.Add(trangThaiColumn);
            }
        }

        private void loadDanhSachNhanVien()
        {
            BUSNhanVien busNhanVien = new BUSNhanVien();
            dgvNhanVien.DataSource = busNhanVien.GetNhanVienlist();
        }



        private void ClearForm()
        {
            txtMaNV.Enabled = true;
            btnNutThem.Enabled = true;
            btnNutSua.Enabled = false;
            btnNutXoa.Enabled = false;
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtMatKhau.Clear();
            txtEmail.Clear();
            rdoNhanVien.Checked = true;
            rdbDangHoatDong.Checked = true;
        }



        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
        }



        private void txtTimKemNhanVien_TextChanged(object sender, EventArgs e)
        {
        }

        private void TimKiemNhanVien()
        {
            string searchValue = txtTimKiemNhanVien.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                loadDanhSachNhanVien();
                return;
            }
            BUSNhanVien busNhanVien = new BUSNhanVien();
            List<NhanVien> list = busNhanVien.GetNhanVienlist();
            var result = list.Where(nv => nv.HoTen.Contains(searchValue)).ToList();
            dgvNhanVien.DataSource = result;
        }











        private void guna2vTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void btnNutThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();

                bool vaiTro = rdoNhanVien.Checked ? true : false;

                if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVien nv = new NhanVien();
                nv.MaNhanVien = maNV;
                nv.HoTen = hoten;
                nv.Email = email;
                nv.MatKhau = matkhau;
                nv.VaiTro = vaiTro;
                nv.TrangThai = true;

                BUSNhanVien bUSNhanVien = new BUSNhanVien();
                bUSNhanVien.InsertNhanVien(nv);

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                loadDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNutSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                bool vaiTro = rdoNhanVien.Checked;
                bool trangThai = rdbDangHoatDong.Checked;

                if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVien nv = new NhanVien();
                nv.MaNhanVien = maNV;
                nv.HoTen = hoten;
                nv.Email = email;
                nv.MatKhau = matkhau;
                nv.VaiTro = vaiTro;
                nv.TrangThai = trangThai;

                BUSNhanVien bUSNhanVien = new BUSNhanVien();
                bUSNhanVien.UpdateNhanVien(nv);
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                loadDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNutXoa_Click(object sender, EventArgs e)
        {

            try
            {
                string maNV = txtMaNV.Text.Trim();
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BUSNhanVien bUSNhanVien = new BUSNhanVien();
                bUSNhanVien.DeleteNhanVien(maNV);
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                loadDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNutLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            loadDanhSachNhanVien();

        }

        private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                NhanVien nv = (NhanVien)row.DataBoundItem;
                txtMaNV.Text = nv.MaNhanVien;
                txtHoTen.Text = nv.HoTen;
                txtEmail.Text = nv.Email;
                txtMatKhau.Text = nv.MatKhau;
                rdoNhanVien.Checked = nv.VaiTro; // true = Nhân Viên, false = Quản Lý
                rdoQuanLy.Checked = !nv.VaiTro; // false = Nhân Viên, true = Quản Lý
                rdbDangHoatDong.Checked = nv.TrangThai; // true = Đang Hoạt Động, false = Tạm Ngưng
                rdbTamNgung.Checked = !nv.TrangThai; // false = Đang Hoạt Động, true = Tạm Ngưng
                txtMaNV.Enabled = false;
                btnNutThem.Enabled = false;
                btnNutSua.Enabled = true;
                btnNutXoa.Enabled = true;
            }

        }

        private void dgvNhanVien_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                NhanVien nv = (NhanVien)row.DataBoundItem;
                string maNhanVien = nv.MaNhanVien;

                if (dgvNhanVien.Columns[e.ColumnIndex].Name == "VaiTroDisplay")
                {
                    string selectedValue = row.Cells["VaiTroDisplay"].Value?.ToString();
                    bool newVaiTro = selectedValue == "Quản Lý" ? false : true; // "Nhân Viên" = true, "Quản Lý" = false
                    if (nv.VaiTro != newVaiTro)
                    {
                        BUSNhanVien busNhanVien = new BUSNhanVien();
                        busNhanVien.UpdateVaiTro(maNhanVien, newVaiTro);
                        nv.VaiTro = newVaiTro; // Cập nhật lại đối tượng
                    }
                }

                if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TrangThaiDisplay")
                {
                    string selectedValue = row.Cells["TrangThaiDisplay"].Value?.ToString();
                    bool newTrangThai = selectedValue == "Đang Hoạt Động" ? true : false; // "Đang Hoạt Động" = true, "Tạm Ngưng" = false
                    if (nv.TrangThai != newTrangThai)
                    {
                        BUSNhanVien busNhanVien = new BUSNhanVien();
                        busNhanVien.UpdateTrangThai(maNhanVien, newTrangThai);
                        nv.TrangThai = newTrangThai; // Cập nhật lại đối tượng
                    }
                }

                // Làm mới hiển thị
                dgvNhanVien.Refresh();
            }
        }

        private void dgvNhanVien_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                NhanVien nv = (NhanVien)row.DataBoundItem;

                if (dgvNhanVien.Columns[e.ColumnIndex].Name == "VaiTroDisplay")
                {
                    e.Value = nv.VaiTro ? "Nhân Viên" : "Quản Lý";
                    e.FormattingApplied = true;
                }

                if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TrangThaiDisplay")
                {
                    e.Value = nv.TrangThai ? "Đang Hoạt Động" : "Tạm Ngưng";
                    e.FormattingApplied = true;
                }
            }
        }

        private void grpThongTinNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {

            TimKiemNhanVien();
        }
    }
}