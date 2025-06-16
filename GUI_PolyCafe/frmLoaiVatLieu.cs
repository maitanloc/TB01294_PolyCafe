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
    public partial class frmLoaiVatLieu : Form
    {
        private BUSLoaiVatLieu busLoaiVatLieu = new BUSLoaiVatLieu();

        public frmLoaiVatLieu()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLoaiVatLieu.Clear();
            txtTenLoaiVatLieu.Clear();
            txtGhiChu.Clear();
            txtTimKiem.Clear();
            txtMaLoaiVatLieu.Enabled = true;
        }

        private void LoadDanhSachLoaiVL()
        {
            dgvLoaiVatLieu.DataSource = null;
            List<LoaiVatLieu> lstLoaiVL = busLoaiVatLieu.GetLoaiVatLieuList();
            dgvLoaiVatLieu.DataSource = lstLoaiVL;
            dgvLoaiVatLieu.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgvLoaiVatLieu.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgvLoaiVatLieu.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvLoaiVatLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmLoaiVatLieu_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachLoaiVL();
        }

        private void dgvLoaiVatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiVatLieu.Rows[e.RowIndex];
                txtMaLoaiVatLieu.Text = row.Cells["MaLoai"].Value.ToString();
                txtTenLoaiVatLieu.Text = row.Cells["TenLoai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaLoaiVatLieu.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenLoai = txtTenLoaiVatLieu.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                if (string.IsNullOrEmpty(tenLoai))
                {
                    MessageBox.Show("Vui lòng điền tên loại vật liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoaiVatLieu loaiVL = new LoaiVatLieu
                {
                    TenLoai = tenLoai,
                    GhiChu = ghiChu
                };

                string result = busLoaiVatLieu.InsertLoaiVatLieu(loaiVL);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Thêm loại vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachLoaiVL();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtMaLoaiVatLieu.Text.Trim();
                string tenLoai = txtTenLoaiVatLieu.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin (Mã và Tên loại vật liệu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoaiVatLieu loaiVL = new LoaiVatLieu
                {
                    MaLoai = maLoai,
                    TenLoai = tenLoai,
                    GhiChu = ghiChu
                };

                string result = busLoaiVatLieu.UpdateLoaiVatLieu(loaiVL);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật loại vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachLoaiVL();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtMaLoaiVatLieu.Text.Trim();
                string tenLoai = txtTenLoaiVatLieu.Text.Trim();

                if (string.IsNullOrEmpty(maLoai))
                {
                    if (dgvLoaiVatLieu.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvLoaiVatLieu.SelectedRows[0];
                        maLoai = selectedRow.Cells["MaLoai"].Value.ToString();
                        tenLoai = selectedRow.Cells["TenLoai"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn loại vật liệu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Mã loại vật liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại vật liệu {maLoai} - {tenLoai}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = busLoaiVatLieu.DeleteLoaiVatLieu(maLoai);
                    if (string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show($"Xóa loại vật liệu {maLoai} - {tenLoai} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadDanhSachLoaiVL();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachLoaiVL();
        }

        private void TimKiemLoaiVatLieu()
        {
            try
            {
                string searchValue = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchValue))
                {
                    LoadDanhSachLoaiVL();
                    return;
                }

                List<LoaiVatLieu> list = busLoaiVatLieu.GetLoaiVatLieuList();
                var result = list.Where(lvl => lvl.TenLoai.ToLower().Contains(searchValue.ToLower())).ToList();
                dgvLoaiVatLieu.DataSource = null;
                dgvLoaiVatLieu.DataSource = result;

                if (result.Count == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Không tìm thấy loại vật liệu nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TimKiemLoaiVatLieu();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemLoaiVatLieu();
        }
    }
}