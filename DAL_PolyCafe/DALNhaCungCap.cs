using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL_POLYCAFE;
using DTO_PolyCafe;

namespace DAL_PolyCafe
{
    public class DALNhaCungCap
    {
        public List<NhaCungCap> GetNhaCungCapList()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            string sql = "SELECT * FROM NhaCungCap";
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, new List<object>());
                while (reader.Read())
                {
                    list.Add(new NhaCungCap
                    {
                        MaNhaCungCap = reader.GetString(0),
                        TenNhaCungCap = reader.GetString(1),
                        DiaChi = reader.IsDBNull(2) ? null : reader.GetString(2),
                        SoDienThoai = reader.GetString(3),
                        Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                        GhiChu = reader.IsDBNull(5) ? null : reader.GetString(5)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public string GenerateMaNhaCungCap()
        {
            string prefix = "NCC";
            string sql = "SELECT MAX(MaNhaCungCap) FROM NhaCungCap";
            object result = DBUtil.ScalarQuery(sql, new List<object>());
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }
            return $"{prefix}001";
        }

        public void InsertNhaCungCap(NhaCungCap ncc)
        {
            string sql = @"INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, Email, GhiChu) 
                           VALUES (@0, @1, @2, @3, @4, @5)";
            List<object> thamSo = new List<object>
            {
                ncc.MaNhaCungCap,
                ncc.TenNhaCungCap,
                ncc.DiaChi ?? (object)DBNull.Value,
                ncc.SoDienThoai,
                ncc.Email ?? (object)DBNull.Value,
                ncc.GhiChu ?? (object)DBNull.Value
            };
            DBUtil.Update(sql, thamSo);
        }

        public void UpdateNhaCungCap(NhaCungCap ncc)
        {
            string sql = @"UPDATE NhaCungCap 
                           SET TenNhaCungCap = @1, DiaChi = @2, SoDienThoai = @3, Email = @4, GhiChu = @5 
                           WHERE MaNhaCungCap = @0";
            List<object> thamSo = new List<object>
            {
                ncc.MaNhaCungCap,
                ncc.TenNhaCungCap,
                ncc.DiaChi ?? (object)DBNull.Value,
                ncc.SoDienThoai,
                ncc.Email ?? (object)DBNull.Value,
                ncc.GhiChu ?? (object)DBNull.Value
            };
            DBUtil.Update(sql, thamSo);
        }

        public void DeleteNhaCungCap(string maNhaCungCap)
        {
            string sql = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @0";
            List<object> thamSo = new List<object> { maNhaCungCap };
            DBUtil.Update(sql, thamSo);
        }
    }
}