using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL_POLYCAFE;
using DTO_PolyCafe;

namespace DAL_PolyCafe
{
    public class DALLoaiVatLieu
    {
        public List<LoaiVatLieu> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<LoaiVatLieu> list = new List<LoaiVatLieu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    LoaiVatLieu entity = new LoaiVatLieu();
                    entity.MaLoai = reader.GetString(0);
                    entity.TenLoai = reader.GetString(1);
                    entity.GhiChu = reader.IsDBNull(2) ? null : reader.GetString(2);
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<LoaiVatLieu> selectAll()
        {
            string sql = "SELECT * FROM LoaiVatLieu";
            return SelectBySql(sql, new List<object>());
        }

        public string generateMaLoaiVatLieu()
        {
            string prefix = "LVL";
            string sql = "SELECT MAX(MaLoai) FROM LoaiVatLieu";
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

        public void insertLoaiVatLieu(LoaiVatLieu loaiVL)
        {
            try
            {
                string sql = @"INSERT INTO LoaiVatLieu (MaLoai, TenLoai, GhiChu) 
                               VALUES (@0, @1, @2)";
                List<object> thamSo = new List<object>();
                thamSo.Add(loaiVL.MaLoai);
                thamSo.Add(loaiVL.TenLoai);
                thamSo.Add(loaiVL.GhiChu ?? (object)DBNull.Value);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateLoaiVatLieu(LoaiVatLieu loaiVL)
        {
            try
            {
                string sql = @"UPDATE LoaiVatLieu 
                               SET TenLoai = @1, GhiChu = @2
                               WHERE MaLoai = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(loaiVL.MaLoai);
                thamSo.Add(loaiVL.TenLoai);
                thamSo.Add(loaiVL.GhiChu ?? (object)DBNull.Value);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deleteLoaiVatLieu(string maLoai)
        {
            try
            {
                string sql = "DELETE FROM LoaiVatLieu WHERE MaLoai = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maLoai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}