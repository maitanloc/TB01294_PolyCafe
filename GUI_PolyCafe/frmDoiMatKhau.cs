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
using UTIL_PolyCafe;

namespace GUI_PolyCafe
{

    public partial class frmDoiMatKhau : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void ckbHienThiMatKhauCu_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = ckbHienThiMatKhauCu.Checked ? '\0' : '*';
        }

        private void ckbHienThiMatKhauMoi_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = ckbHienThiMatKhauMoi.Checked ? '\0' : '*';
        }

        private void ckbHienThiXacNhanMatKhau_CheckedChanged(object sender, EventArgs e)
        {

            txtXacNhanMatKhau.PasswordChar = ckbHienThiXacNhanMatKhau.Checked ? '\0' : '*';
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (AuthUtil.user.MatKhau.Equals(txtMatKhauCu.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                AuthUtil.user.MatKhau = txtMatKhauMoi.Text;
                if (busNhanVien.updateMatKhau(AuthUtil.user.Email, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtMatKhauCu_TextChanged(object sender, EventArgs e)
        {

            txtMatKhauCu.PasswordChar = ckbHienThiMatKhauCu.Checked ? '\0' : '*';
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (AuthUtil.isLogin())
            {
                txtMaNV.Text = AuthUtil.user.MaNhanVien;
                txtTenNV.Text = AuthUtil.user.HoTen;
            }
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {

            txtMatKhauMoi.PasswordChar = ckbHienThiMatKhauMoi.Checked ? '\0' : '*';
        }

        private void txtXacNhanMatKhau_TextChanged(object sender, EventArgs e)
        {

            txtXacNhanMatKhau.PasswordChar = ckbHienThiXacNhanMatKhau.Checked ? '\0' : '*';
        }

        private void btnThoatDoiMatKhau_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
