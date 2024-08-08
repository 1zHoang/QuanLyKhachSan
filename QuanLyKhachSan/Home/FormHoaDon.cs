using QuanLyKhachSan.Classes;
using QuanLyKhachSan.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Home
{
    public partial class FormHoaDon : Form
    {
        private DataProcesser dtbase = new DataProcesser();
        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void btnLeftMenu_Click(object sender, EventArgs e)
        {
            LeftMenu leftMenu1 = new LeftMenu();
            this.Controls.Add(leftMenu1);
            leftMenu1.Visible = false;
            leftMenu1.BringToFront();
            leftMenu1.Width = 260;
            transactionLeftMenu.ShowSync(leftMenu1);
        }

		private void grvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            string maphieudat = grvHoaDon.CurrentRow.Cells["MaPhieuDat"].Value.ToString();
			UC_HoaDon ucHoaDon = new UC_HoaDon(maphieudat, "");
			ucHoaDon.Location = new Point(250, 5);
			this.Controls.Add(ucHoaDon);
			ucHoaDon.BringToFront();
		}

		private void FormHoaDon_Load(object sender, EventArgs e)
		{
            dtThoiGianHoaDon.Value = DateTime.Today;
            string sql = string.Format("select MaHoaDon, TenNhanVien, tHoaDon.MaPhieuDat, TenKhachHang, NgayLapHoaDon " +
                                        "from tHoaDon inner join tPhieuDat on tHoaDon.MaPhieuDat = tPhieuDat.MaPhieuDat inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang inner join tNhanVien on tHoaDon.MaNhanVien = tNhanVien.MaNhanVien order by NgayLapHoaDon DESC");
            DataTable dt = dtbase.ReadData(sql);
            grvHoaDon.RowTemplate.Height += 15;
            grvHoaDon.DataSource = dt;
            grvHoaDon.AllowUserToAddRows = false;
		}

		private void txtSearchHD_TextChanged(object sender, EventArgs e)
		{
            string sql = string.Format("select MaHoaDon, TenNhanVien, tHoaDon.MaPhieuDat, TenKhachHang, NgayLapHoaDon " +
                "from tHoaDon inner join tPhieuDat on tHoaDon.MaPhieuDat = tPhieuDat.MaPhieuDat inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang inner join tNhanVien on tHoaDon.MaNhanVien = tNhanVien.MaNhanVien " +
                "where MaHoaDon like '%{0}%' or TenKhachHang like N'%{0}%' or tHoaDon.MaPhieuDat like '%{0}%' or NgayLapHoaDon like '%{0}%'", txtSearchHD.Text);
            DataTable dt = dtbase.ReadData(sql);
            grvHoaDon.DataSource = dt;
            if(txtSearchHD.Text.Trim() == "")
            {
                FormHoaDon_Load(sender,e);
            }
		}

		private void ThoiGianHoaDon_ValueChanged(object sender, EventArgs e)
		{
			string ngayHoaDon = dtThoiGianHoaDon.Value.ToString("yyyy-MM-dd");
			LoadHoaDon(ngayHoaDon);
		}
		public void LoadHoaDon(string date)
        {
			string sql = string.Format("select MaHoaDon, TenNhanVien, tHoaDon.MaPhieuDat, TenKhachHang, NgayLapHoaDon " +
                                        "from tHoaDon inner join tPhieuDat on tHoaDon.MaPhieuDat = tPhieuDat.MaPhieuDat inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang inner join tNhanVien on tHoaDon.MaNhanVien = tNhanVien.MaNhanVien where NgayLapHoaDon = '{0}'", date);
			DataTable dt = dtbase.ReadData(sql);
			grvHoaDon.DataSource = dt;
		}
	}
}
