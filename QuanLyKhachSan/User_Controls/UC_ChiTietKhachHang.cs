using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.User_Controls
{
	public partial class UC_ChiTietKhachHang : UserControl
	{
		DataProcesser dtbase = new DataProcesser();
		FormQuanLyKhachHang that = new FormQuanLyKhachHang();
		private string makh;
		public UC_ChiTietKhachHang(string makh)
		{
			this.makh = makh;
			InitializeComponent();
		}
		public UC_ChiTietKhachHang()
		{
			InitializeComponent();
		}

		private void guna2Panel2_Paint(object sender, PaintEventArgs e)
		{
			//this.Visible = false;
		}

		private void guna2Panel2_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		private void guna2Panel3_Click(object sender, EventArgs e)
		{
			panelLichSuDat.Visible = false;
			panelLichSuThue.Visible = false;	
			panelThongTin.Visible = true;
			string sql = String.Format("Select * from tKhachHang where MaKhachHang = N'{0}'",makh);
			DataTable dt = dtbase.ReadData(sql);
			List<DataRow> list = dt.Select().ToList();
			foreach (var item in list)
			{
				lbMaKH.Text = item.Field<string>("MaKhachHang").ToString();
				lbTenKH.Text = item.Field<string>("TenKhachHang").ToString();
				lbNgaySinh.Text = item.Field<DateTime>("NgaySinh").ToString("dd-MM-yyyy");
				lbGioiTinh.Text = item.Field<string>("GioiTinh").ToString();
				lbDiaChi.Text = item.Field<string>("DiaChi").ToString();
				lbDienThoai.Text = item.Field<string>("DienThoai").ToString();
				lbCCCD.Text = item.Field<string>("CCCD").ToString();
			}
		}

		private void UC_ChiTietKhachHang_Load(object sender, EventArgs e)
		{
			panelLichSuDat.Visible=false;
			panelThongTin.Visible = false;
			panelLichSuThue.Visible = false;
		}


		private void panelLSThue0_Click(object sender, EventArgs e)
		{
			//panelThongTin.Visible = false;
			panelLichSuThue.Visible = true;
			grvLichSuThue.RowTemplate.Height = 35;
			string sql = string.Format("SELECT tPhieuThue.MaPhieuThue,tPhieuThue.MaPhong,tPhieuThue.ThoiGianLapPT,tPhieuThue.ThoiGianCheckIn FROM tPhieuThue " +
				"inner join tPhieuDat on tPhieuThue.MaPHieuDat = tPhieuDat.MaPhieuDat " +
				"inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang where tKhachHang.MaKhachHang = N'{0}'", makh);
			DataTable dt = dtbase.ReadData(sql);
			grvLichSuThue.DataSource = dt;
		}

		private void panelLSDat0_Click(object sender, EventArgs e)
		{
			panelLichSuDat.Visible = true;
			grvLichSuDat.RowTemplate.Height = 35;
			string sql = string.Format("SELECT tChiTietPhongDat.MaPhong,tPhieuDat.MaKhachHang,tPhieuDat.MaPhieuDat,tPhieuDat.NgayDenDuKien,tPhieuDat.NgayDiDuKien from tPhieuDat " +
				"inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
				"inner join tChiTietPhongDat on tPhieuDat.MaPhieuDat = tChiTietPhongDat.MaPhieuDat where tKhachHang.MaKhachHang = N'{0}'", makh);
			DataTable dt = dtbase.ReadData(sql);
			grvLichSuDat.DataSource = dt;
		}
	}
}
