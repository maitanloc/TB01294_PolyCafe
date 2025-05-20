using BLL_PolyCafe;
using DTO_PolyCafe;
using UTIL_PolyCafe;



namespace GUI_PolyCafe
{
    public partial class frmLogin : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();

        public frmLogin()
        {
            InitializeComponent();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lklblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            NhanVien nv = busNhanVien.DangNhap(username, password);


            if (nv == null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (nv.TrangThai == false)
                {
                    MessageBox.Show("Tài khoản đã bị khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AuthUtil.user = nv;

                frmMainForm main = new frmMainForm();
                main.Show();
                this.Hide();

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            // ẩn mật khẩu
            txtMatKhau.PasswordChar = '*';

        }

        private void ckbHienThi_CheckedChanged(object sender, EventArgs e)
        {

            txtMatKhau.PasswordChar = ckbHienThi.Checked ? '\0' : '*';
        }
    }
}
