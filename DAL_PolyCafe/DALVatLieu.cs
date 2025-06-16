using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL_POLYCAFE;
using DTO_PolyCafe;

namespace DAL_PolyCafe
{
    public class DALVatLieu
    {
        public List<VatLieu> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<VatLieu> list = new List<VatLieu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    VatLieu entity = new VatLieu();
                    entity.MaVatLieu = reader.GetString(0);
                    entity.TenVatLieu = reader.GetString(1);
                    entity.SoLuong = reader.GetInt32(2);
                    entity.TrangThai = reader.GetString(3);
                    entity.GhiChu = reader.IsDBNull(4) ? null : reader.GetString(4);
                    entity.MaLoai = reader.IsDBNull(5) ? null : reader.GetString(5);
                    entity.NgayCapNhat = reader.GetDateTime(6);
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<VatLieu> selectAll(string trangThai = null)
        {
            string sql = @"SELECT vl.MaVatLieu, vl.TenVatLieu, vl.SoLuong, vl.TrangThai, vl.GhiChu, vl.MaLoai, vl.NgayCapNhat, lvl.TenLoai 
                          FROM VatLieu vl 
                          LEFT JOIN LoaiVatLieu lvl ON vl.MaLoai = lvl.MaLoai";
            List<object> p = new List<object>();
            if (!string.IsNullOrEmpty(trangThai))
            {
                sql += " WHERE vl.TrangThai = @0";
                p.Add(trangThai);
            }

            return SelectBySql(sql, p);
        }

        public VatLieu selectById(string id)
        {
            string sql = "SELECT MaVatLieu, TenVatLieu, SoLuong, TrangThai, GhiChu, MaLoai, NgayCapNhat FROM VatLieu WHERE MaVatLieu = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<VatLieu> list = SelectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public void insertVatLieu(VatLieu vl)
        {
            try
            {
                string sql = @"INSERT INTO VatLieu (MaVatLieu, TenVatLieu, SoLuong, TrangThai, GhiChu, MaLoai) 
                               VALUES (@0, @1, @2, @3, @4, @5)";
                List<object> thamSo = new List<object>();
                thamSo.Add(vl.MaVatLieu);
                thamSo.Add(vl.TenVatLieu);
                thamSo.Add(vl.SoLuong);
                thamSo.Add(vl.TrangThai);
                thamSo.Add(vl.GhiChu ?? (object)DBNull.Value);
                thamSo.Add(vl.MaLoai ?? (object)DBNull.Value);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateVatLieu(VatLieu vl)
        {
            try
            {
                string sql = @"UPDATE VatLieu 
                               SET TenVatLieu = @1, SoLuong = @2, TrangThai = @3, GhiChu = @4, MaLoai = @5, NgayCapNhat = GETDATE()
                               WHERE MaVatLieu = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(vl.MaVatLieu);
                thamSo.Add(vl.TenVatLieu);
                thamSo.Add(vl.SoLuong);
                thamSo.Add(vl.TrangThai);
                thamSo.Add(vl.GhiChu ?? (object)DBNull.Value);
                thamSo.Add(vl.MaLoai ?? (object)DBNull.Value);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deleteVatLieu(string maVL)
        {
            try
            {
                string sql = "DELETE FROM VatLieu WHERE MaVatLieu = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maVL);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string generateMaVatLieu()
        {
            string prefix = "VL";
            string sql = "SELECT MAX(MaVatLieu) FROM VatLieu";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}