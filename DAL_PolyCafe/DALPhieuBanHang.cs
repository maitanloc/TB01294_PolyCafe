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
    public class DALPhieuBanHang
    {
        public string generateMaPhieu()
        {
            string prefix = "PBH";
            string sql = "SELECT MAX(MaPhieu) FROM PhieuBanHang";
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

        public void insertPhieuBanHang(PhieuBanHang pbh)
        {
            try
            {
                string sql = @"INSERT INTO PhieuBanHang (MaPhieu, MaThe, MaNhanVien, NgayTao, TrangThai) 
                   VALUES (@0, @1, @2, @3, @4)";
                List<object> thamSo = new List<object>();
                thamSo.Add(pbh.MaPhieu);
                thamSo.Add(pbh.MaThe);
                thamSo.Add(pbh.MaNhanVien);
                thamSo.Add(pbh.NgayTao);
                thamSo.Add(pbh.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void updateNhanVien(PhieuBanHang pbh)
        {
            try
            {
                string sql = @"UPDATE PhieuBanHang 
                   SET MaThe = @1, MaNhanVien = @2, NgayTao = @3, TrangThai = @4 
                   WHERE MaPhieu = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(pbh.MaPhieu);
                thamSo.Add(pbh.MaThe);
                thamSo.Add(pbh.MaNhanVien);
                thamSo.Add(pbh.NgayTao);
                thamSo.Add(pbh.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public void deletePhieuBanHang(string maPhieu)
        {
            try
            {
                string sql = "DELETE FROM PhieuBanHang WHERE MaPhieu = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maPhieu);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<PhieuBanHang> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<PhieuBanHang> list = new List<PhieuBanHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    PhieuBanHang entity = new PhieuBanHang();
                    entity.MaPhieu = reader.GetString(0);
                    entity.MaThe = reader.GetString(1);
                    entity.ChuSoHuu = reader.GetString(2);
                    entity.MaNhanVien = reader.GetString(3);
                    entity.HoTen = reader.GetString(4);
                    entity.NgayTao = reader.GetDateTime(5);
                    entity.TrangThai = reader.GetBoolean(6);
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<PhieuBanHang> selectAll(string maThe)
        {
            //String sql = "SELECT * FROM PhieuBanHang";
            List<object> param = new List<object>();
            string sql = "SELECT phieu.MaPhieu, phieu.MaThe, the.ChuSoHuu, phieu.MaNhanVien, nv.HoTen, phieu.NgayTao, phieu.TrangThai " +
                "FROM PhieuBanHang phieu INNER JOIN NhanVien nv ON phieu.MaNhanVien = nv.MaNhanVien " +
                "INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe";
            if (!string.IsNullOrEmpty(maThe))
            {
                sql = "SELECT phieu.MaPhieu, phieu.MaThe, the.ChuSoHuu, phieu.MaNhanVien, nv.HoTen, phieu.NgayTao, phieu.TrangThai " +
               "FROM PhieuBanHang phieu INNER JOIN NhanVien nv ON phieu.MaNhanVien = nv.MaNhanVien " +
               "INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe " +
               "WHERE the.MaThe = @0";
                param.Add(maThe);
            }

            return SelectBySql(sql, param);
        }
        public List<PhieuBanHang> SearchPhieuBanHang(string keyword)
        {
            // Nếu không truyền keyword hoặc chỉ toàn khoảng trắng, trả về tất cả
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return selectAll(null);
            }

            // Chuẩn bị wildcard
            string pattern = $"%{keyword.Trim()}%";

            // SQL: nối bảng TheLuuDong và NhanVien để lấy đầy đủ thông tin
            string sql = @"
            SELECT phieu.MaPhieu,
                   phieu.MaThe,
                   the.ChuSoHuu,
                   phieu.MaNhanVien,
                   nv.HoTen,
                   phieu.NgayTao,
                   phieu.TrangThai
            FROM PhieuBanHang phieu
            INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe
            INNER JOIN NhanVien    nv  ON nv.MaNhanVien = phieu.MaNhanVien
            WHERE phieu.MaPhieu LIKE @0
               OR the.ChuSoHuu  LIKE @0
               OR nv.HoTen      LIKE @0";

            var param = new List<object> { pattern };
            return SelectBySql(sql, param);
        }
        public List<PhieuBanHang> SearchPhieuBanHangByDate(DateTime? fromDate, DateTime? toDate)
        {
            var sqlBuilder = new StringBuilder(@"
            SELECT phieu.MaPhieu,
                   phieu.MaThe,
                   the.ChuSoHuu,
                   phieu.MaNhanVien,
                   nv.HoTen,
                   phieu.NgayTao,
                   phieu.TrangThai
            FROM PhieuBanHang phieu
            INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe
            INNER JOIN NhanVien    nv  ON nv.MaNhanVien = phieu.MaNhanVien
            WHERE 1=1");
            var param = new List<object>();

            if (fromDate.HasValue)
            {
                sqlBuilder.Append(" AND phieu.NgayTao >= @").Append(param.Count);
                param.Add(fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                sqlBuilder.Append(" AND phieu.NgayTao <= @").Append(param.Count);
                param.Add(toDate.Value.Date);
            }

            return SelectBySql(sqlBuilder.ToString(), param);
        }


    }
}
