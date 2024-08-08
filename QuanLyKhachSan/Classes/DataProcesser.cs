using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Classes
{
    internal class DataProcesser
    {
        //B1: Khai báo chuỗi kết nối
        //string connectStr = "Data Source=DESKTOP-7II3PPA\\MSSQLSERVER01;Initial Catalog=BTL_QuanLyKhachSan;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True";
        string connectStr = "Data Source=DESKTOP-7II3PPA\\MSSQLSERVER01;Initial Catalog=BTL_QuanLyKhachSan;User ID=sa;Password=123;Encrypt=False";
        SqlConnection sqlConn = null;
        //PT mở kết nối
        void OpenConnect()
        {
            sqlConn = new SqlConnection(connectStr);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
        //PT đóng kết nối
        void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        //PT đọc dữ liệu
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlSelect, sqlConn);
            dtAdapter.Fill(dt);
            CloseConnect();
            dtAdapter.Dispose();
            return dt;
        }
        //PT cập nhật (thêm, sửa xóa dữ liệu)
        public void ChangeData(string sql)
        {
            OpenConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            CloseConnect();
            sqlCommand.Dispose();
        }


    }
}
