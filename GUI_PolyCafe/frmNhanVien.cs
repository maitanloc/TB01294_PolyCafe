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
            loadDanhSachNhanVien();


        }
        private void loadDanhSachNhanVien()
        {
            BUSNhanVien busNhanVien = new BUSNhanVien();
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = busNhanVien.GetNhanVienlist();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Lấy dữ liệu từ form
                string maNV = txtMaNV.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();

                bool vaiTro = rdoNhanVien.Checked;

                if (rdoNhanVien.Checked)
                {
                    vaiTro = true; // Nhân viên
                }
                else
                {
                    vaiTro = false; // Quản lý
                }

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Bước 3: Tạo đối tượng
                NhanVien nv = new NhanVien();
                nv.MaNhanVien = maNV;
                nv.HoTen = hoten;
                nv.Email = email;
                nv.MatKhau = matkhau;
                nv.VaiTro = vaiTro;
                nv.TrangThai = true; // Mặc định là hoạt động

                // Gọi DAL để thêm nhân viên vào database
                BUSNhanVien bUSNhanVien = new BUSNhanVien();
                bUSNhanVien.InsertNhanVien(nv);


                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới form sau khi thêm thành công
                ClearForm();
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
            rdoNhanVien.Checked = true; // Mặc định chọn "Nhân viên"
        }
        private void btnLamMoiNhanVien_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

            // khóa textbox mã nhân viên
            txtMaNV.Enabled = false;



        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                // Hiển thị thông tin vào các textbox
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                // Kiểm tra vai trò
                bool vaiTro = (bool)row.Cells["VaiTro"].Value;
                if (vaiTro)
                {
                    rdoNhanVien.Checked = true; // Nhân viên
                }
                else
                {
                    rdoQuanLy.Checked = true; // Quản lý
                }
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
            // Tìm kiếm theo tên nhân viên
            var result = list.Where(nv => nv.HoTen.Contains(searchValue)).ToList();
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = result;


        }
        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien();





        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {

           

        }
    }
}

