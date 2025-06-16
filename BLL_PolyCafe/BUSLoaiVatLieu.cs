using System;
using System.Collections.Generic;
using System.Linq;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSLoaiVatLieu
    {
        private DALLoaiVatLieu dalLoaiVatLieu = new DALLoaiVatLieu();

        public List<LoaiVatLieu> GetLoaiVatLieuList()
        {
            return dalLoaiVatLieu.selectAll();
        }

        public string InsertLoaiVatLieu(LoaiVatLieu loaiVL)
        {
            try
            {
                loaiVL.MaLoai = dalLoaiVatLieu.generateMaLoaiVatLieu();
                if (string.IsNullOrEmpty(loaiVL.MaLoai))
                {
                    return "Mã loại vật liệu không hợp lệ.";
                }

                if (string.IsNullOrEmpty(loaiVL.TenLoai))
                {
                    return "Tên loại vật liệu không được để trống.";
                }

                dalLoaiVatLieu.insertLoaiVatLieu(loaiVL);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateLoaiVatLieu(LoaiVatLieu loaiVL)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiVL.MaLoai))
                {
                    return "Mã loại vật liệu không hợp lệ.";
                }

                if (string.IsNullOrEmpty(loaiVL.TenLoai))
                {
                    return "Tên loại vật liệu không được để trống.";
                }

                dalLoaiVatLieu.updateLoaiVatLieu(loaiVL);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteLoaiVatLieu(string maLoai)
        {
            try
            {
                if (string.IsNullOrEmpty(maLoai))
                {
                    return "Mã loại vật liệu không hợp lệ.";
                }

                // Kiểm tra xem loại vật liệu có đang được sử dụng không
                using (var conn = new System.Data.SqlClient.SqlConnection("Server=.;Database=PolyCafe;Trusted_Connection=True;"))
                {
                    conn.Open();
                    var cmd = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM VatLieu WHERE MaLoai = @MaLoai", conn);
                    cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return "Không thể xóa loại vật liệu đang được sử dụng.";
                    }
                }

                dalLoaiVatLieu.deleteLoaiVatLieu(maLoai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}