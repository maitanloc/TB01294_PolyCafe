using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_POLYCAFE;
using DTO_PolyCafe;

namespace DAL_PolyCafe
{
    public class DALThongKe
    {
        public List<TKDoanhThuLoaiSP> GetDoanhThuTheoLoaiSP(string maLoaiSP, DateTime tuNgay, DateTime denNgay)
        {
            string sql = "TKDoanhThuTheoLoaiSP";
            List<object> thamSo = new List<object>();
            thamSo.Add(maLoaiSP);
            thamSo.Add(tuNgay);
            thamSo.Add(denNgay);
            List<TKDoanhThuLoaiSP> result = new List<TKDoanhThuLoaiSP>();
            SqlDataReader reader = DBUtil.Query(sql, thamSo, CommandType.StoredProcedure);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TKDoanhThuLoaiSP tk = new TKDoanhThuLoaiSP();
                    tk.MaSanPham = reader["MaSanPham"].ToString();
                    tk.TenSanPham = reader["TenSanPham"].ToString();
                    tk.SoLy = int.Parse(reader["SoLy"].ToString());
                    tk.SoLuongPhieu = int.Parse(reader["SoLuongPhieu"].ToString());
                    tk.NgayBan = DateTime.Parse(reader["NgayBan"].ToString()).ToString("dd/MM/yyyy");
                    tk.TongTien = decimal.Parse(reader["TongTien"].ToString()).ToString("#,0"); ;
                    tk.DaThanhToan = bool.Parse(reader["TrangThai"].ToString()) ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    result.Add(tk);
                }
            }
            return result;
        }
        public List<TKDoanhThuTheoNhanVien> GetDoanhThuTheoNhanVien(string maNV, DateTime tuNgay, DateTime denNgay)
        {
            string sql = "TKDoanhThuTheoNhanVien";
            List<object> thamSo = new List<object>();
            thamSo.Add(maNV);
            thamSo.Add(tuNgay);
            thamSo.Add(denNgay);
            List<TKDoanhThuTheoNhanVien> result = new List<TKDoanhThuTheoNhanVien>();
            SqlDataReader reader = DBUtil.Query(sql, thamSo, CommandType.StoredProcedure);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TKDoanhThuTheoNhanVien tk = new TKDoanhThuTheoNhanVien();
                    tk.MaNhanVien = reader["MaNhanVien"].ToString();
                    tk.HoTen = reader["HoTen"].ToString();
                    tk.SoLy = int.Parse(reader["SoLy"].ToString());
                    tk.SoLuongPhieu = int.Parse(reader["SoLuongPhieu"].ToString());
                    tk.NgayBan = DateTime.Parse(reader["NgayBan"].ToString()).ToString("dd/MM/yyyy");
                    tk.TongTien = decimal.Parse(reader["TongTien"].ToString()).ToString("#,0"); ;
                    tk.DaThanhToan = bool.Parse(reader["TrangThai"].ToString()) ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    result.Add(tk);
                }
            }
            return result;
        }
    }
}
