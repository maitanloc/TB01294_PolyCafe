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
    public class DALChiTietPhieu
    {
        public string generateChiTietID()
        {
            string prefix = "CTP";
            string sql = "SELECT MAX(MaChiTiet) FROM ChiTietPhieu";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public List<ChiTietPhieu> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<ChiTietPhieu> list = new List<ChiTietPhieu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    ChiTietPhieu entity = new ChiTietPhieu();
                    entity.MaChiTiet = reader.GetString(0);   // Cột 0: MaChiTiet (string)
                    entity.MaPhieu = reader.GetString(1);     // Cột 1: MaPhieu (string)
                    entity.MaSanPham = reader.GetString(2);   // Cột 2: MaSanPham (string)
                    entity.SoLuong = reader.GetInt32(3);      // Cột 3: SoLuong (int)
                    entity.DonGia = reader.GetDecimal(4);     // Cột 4: DonGia (decimal)
                    entity.TenSanPham = reader.GetString(5);  // Cột 5: TenSanPham (string)
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<ChiTietPhieu> selectChiTietByMaPhieu(string maPhieu)
        {
            string sql = "SELECT ct.MaChiTiet, ct.MaPhieu, ct.MaSanPham, ct.SoLuong, ct.DonGia, sp.TenSanPham " +
                        "FROM ChiTietPhieu ct " +
                        "INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham " +
                        "WHERE ct.MaPhieu = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(maPhieu); // Đảm bảo maPhieu là string
            return SelectBySql(sql, thamSo);
        }

        public void insertChiTiet(ChiTietPhieu ct)
        {
            try
            {
                string sql = @"INSERT INTO ChiTietPhieu (MaChiTiet, MaPhieu, MaSanPham, SoLuong, DonGia) VALUES (@0, @1, @2, @3, @4)";
                List<object> thamSo = new List<object>();
                thamSo.Add(ct.MaChiTiet);
                thamSo.Add(ct.MaPhieu);
                thamSo.Add(ct.MaSanPham);
                thamSo.Add(ct.SoLuong);
                thamSo.Add(ct.DonGia);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void insertListChiTiet(List<ChiTietPhieu> lstChiTiet)
        {
            try
            {
                foreach (ChiTietPhieu item in lstChiTiet)
                {
                    insertChiTiet(item);
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void updateSoluong(ChiTietPhieu ct)
        {
            try
            {
                string sql = @"UPDATE ChiTietPhieu 
                   SET SoLuong = @1 
                   WHERE MaChiTiet = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(ct.MaChiTiet);
                thamSo.Add(ct.SoLuong);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void deleteChiTietPhieu(string Id)
        {
            try
            {
                string sql = "DELETE FROM ChiTietPhieu WHERE MaChiTiet = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(Id);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public decimal CalculateTongTien(string maPhieu)
        {
            decimal tongTien = 0;
            try
            {
                string sql = "SELECT SUM(SoLuong * DonGia) FROM ChiTietPhieu WHERE MaPhieu = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maPhieu);
                object result = DBUtil.ScalarQuery(sql, thamSo);
                if (result != null && result != DBNull.Value)
                {
                    tongTien = Convert.ToDecimal(result);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return tongTien;
        }
        public List<ChiTietPhieu> SearchChiTietBySanPham(string maPhieu, string keyword)
        {
            string pattern = $"%{keyword.Trim()}%";
            string sql = @"
                SELECT ct.MaChiTiet, ct.MaPhieu, ct.MaSanPham, ct.SoLuong, ct.DonGia, sp.TenSanPham
                FROM ChiTietPhieu ct
                INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                WHERE ct.MaPhieu = @0
                  AND (sp.TenSanPham LIKE @1 OR ct.MaSanPham LIKE @1)";

            var thamSo = new List<object> { maPhieu, pattern };
            return SelectBySql(sql, thamSo);
        }
        public List<SanPham> SearchSanPham(string keyword)
        {
            string pattern = $"%{keyword.Trim()}%";
            string sql = @"
                SELECT MaSanPham, TenSanPham, DonGia, MaLoai, HinhAnh
                FROM SanPham
                WHERE MaSanPham LIKE @0
                   OR TenSanPham LIKE @0";

            var thamSo = new List<object> { pattern };

            var list = new List<SanPham>();
            using (SqlDataReader reader = DBUtil.Query(sql, thamSo))
            {
                while (reader.Read())
                {
                    var sp = new SanPham
                    {
                        MaSanPham = reader.GetString(0),
                        TenSanPham = reader.GetString(1),
                        DonGia = reader.GetDecimal(2),
                        MaLoai = reader.GetString(3),
                        HinhAnh = reader.IsDBNull(4) ? null : reader.GetString(4)
                    };
                    list.Add(sp);
                }
            }
            return list;
        }

    }
}
