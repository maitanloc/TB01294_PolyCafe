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
    public partial class frmThongKeLoaiSP : Form
    {
        public frmThongKeLoaiSP()
        {
            InitializeComponent();
        }

        private void frmThongKeLoaiSP_Load(object sender, EventArgs e)
        {
            // Lấy ngày đầu tháng hiện tại
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Gán giá trị cho DateTimePicker
            dtpTuNgay.Value = firstDayOfMonth;
            LoadLoaiSanPham();
            btnThongKe_Click(sender, e);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiSP.SelectedValue.ToString();
            DateTime bd = dtpTuNgay.Value.Date;
            DateTime kt = dtpDenNgay.Value.Date;

            BUSThongKe busThongKe = new BUSThongKe();
            List<TKDoanhThuLoaiSP> result = busThongKe.getThongKeLoaiSP(loai, bd, kt);
            dgvThongKeSanPham.DataSource = result;

        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();

                dsLoai.Insert(0, new LoaiSanPham() { MaLoai = string.Empty, TenLoai = string.Format("--Tất Cả--") });
                cboLoaiSP.DataSource = dsLoai;
                cboLoaiSP.ValueMember = "MaLoai";
                cboLoaiSP.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
