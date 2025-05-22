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
            dgvNhanVien.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvNhanVien_CellFormatting);
            dgvNhanVien.CellEndEdit += new DataGridViewCellEventHandler(dgvNhanVien_CellEndEdit);
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

        private void btnThemNhanVien_Click(object sender, EventArgs e)
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

        private void ClearForm()
        {
            txtMaNV.Enabled = true;
            btnThemNhanVien.Enabled = true;
            btnSuaNhanVien.Enabled = false;
            btnXoaNhanVien.Enabled = false;
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtMatKhau.Clear();
            txtEmail.Clear();
            rdoNhanVien.Checked = true;
        }

        private void btnLamMoiNhanVien_Click(object sender, EventArgs e)
        {
            ClearForm();
            loadDanhSachNhanVien();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();

                NhanVien nv = (NhanVien)row.DataBoundItem;
                if (nv.VaiTro)
                {
                    rdoNhanVien.Checked = true;
                }
                else
                {
                    rdoQuanLy.Checked = true;
                }

                if (nv.TrangThai)
                {
                    rdoDangHoatDong.Checked = true;
                }
                else
                {
                    rdoTamNgung.Checked = true;
                }

                txtMaNV.Enabled = false;
                btnThemNhanVien.Enabled = false;
                btnSuaNhanVien.Enabled = true;
                btnXoaNhanVien.Enabled = true;
            }
        }

        private void txtTimKemNhanVien_TextChanged(object sender, EventArgs e)
        {
        }

        private void TimKiemNhanVien()
        {
            string searchValue = txtTimKemNhanVien.Text.Trim();
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

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                bool vaiTro = rdoNhanVien.Checked;
                bool trangThai = rdoDangHoatDong.Checked;

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

        private void btnXoaNhanVien_Click_1(object sender, EventArgs e)
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

        private void btnThoatNhanVien_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgvNhanVien_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
    }
}