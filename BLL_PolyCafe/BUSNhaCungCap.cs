using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSNhaCungCap
    {
        private DALNhaCungCap dalNhaCungCap = new DALNhaCungCap();

        public List<NhaCungCap> GetNhaCungCapList()
        {
            return dalNhaCungCap.GetNhaCungCapList();
        }

        public string InsertNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                if (string.IsNullOrEmpty(ncc.TenNhaCungCap) || string.IsNullOrEmpty(ncc.SoDienThoai))
                {
                    return "Tên nhà cung cấp và số điện thoại không được để trống.";
                }

                if (!Regex.IsMatch(ncc.SoDienThoai, @"^0\d{9}$"))
                {
                    return "Số điện thoại phải là 10 chữ số, bắt đầu bằng 0.";
                }

                if (!string.IsNullOrEmpty(ncc.Email) && !Regex.IsMatch(ncc.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return "Email không hợp lệ.";
                }

                ncc.MaNhaCungCap = dalNhaCungCap.GenerateMaNhaCungCap();
                dalNhaCungCap.InsertNhaCungCap(ncc);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                if (string.IsNullOrEmpty(ncc.MaNhaCungCap) || string.IsNullOrEmpty(ncc.TenNhaCungCap) || string.IsNullOrEmpty(ncc.SoDienThoai))
                {
                    return "Mã, tên nhà cung cấp và số điện thoại không được để trống.";
                }

                if (!Regex.IsMatch(ncc.SoDienThoai, @"^0\d{9}$"))
                {
                    return "Số điện thoại phải là 10 chữ số, bắt đầu bằng 0.";
                }

                if (!string.IsNullOrEmpty(ncc.Email) && !Regex.IsMatch(ncc.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return "Email không hợp lệ.";
                }

                dalNhaCungCap.UpdateNhaCungCap(ncc);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteNhaCungCap(string maNhaCungCap)
        {
            try
            {
                // Kiểm tra liên kết với giao dịch nhập hàng (nếu có)
                // Giả định chưa có bảng LichSuNhapHang, nên xóa trực tiếp
                dalNhaCungCap.DeleteNhaCungCap(maNhaCungCap);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}