using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.User_Controls
{

    public partial class UC_KhachHang : UserControl
    {
        private DataProcesser dtbase = new DataProcesser();
        private FormQuanLyKhachHang that = new FormQuanLyKhachHang();
		private string maKH;
		private string TenKH;
		private string NgaySinh;
		private string GioiTinh;
		private string DiaChi;
		private string DienThoai;
		private string cccd;
		private string index;
		//private Functions functions = new Functions();
		public UC_KhachHang(FormQuanLyKhachHang that, string maKH, string TenKH, string NgaySinh, string GioiTinh, string DiaChi, string DienThoai, string cccd, string index)
		{
			this.that = that;
			this.maKH = maKH;
			this.TenKH = TenKH;
			this.NgaySinh = NgaySinh;
			this.GioiTinh = GioiTinh;
			this.DiaChi = DiaChi;
			this.DienThoai = DienThoai;
			this.cccd = cccd;
			this.index = index;
			InitializeComponent();
		}
		public UC_KhachHang(FormQuanLyKhachHang that, string index)
		{
			this.that = that;
			this.index = index;
			InitializeComponent();
		}
		public UC_KhachHang(FormQuanLyKhachHang that)
		{
			this.that = that;
			InitializeComponent();
		}

		public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
		private void UC_KhachHang_Load(object sender, EventArgs e)
		{
			if (index == "Sửa")
			{
				txtHoTenKH.Text = TenKH;
				txtNgaySinh.Text = NgaySinh;
				txtCCCD.Text = cccd;
				txtSDT.Text = DienThoai;
				txtDiaChi.Text = DiaChi;
				cboGioiTinh.Text = GioiTinh;
			}
		}
		private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTenKH.Text.Trim() == "")
            {
                errorProvider1.SetError(txtHoTenKH, "Bạn không được để trống tên khách hàng !");
                return;
            }
            if(txtNgaySinh.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNgaySinh, "Bạn không được để trống ngày sinh khách hàng !");
                return;
            }
			if (txtSDT.Text.Trim() == "")
			{
				errorProvider1.SetError(txtSDT, "Bạn không được để trống số điện thoại khách hàng !");
                return;
			}
            else
            {
                if(txtSDT.Text.Length > 10 && txtSDT.Text.Length < 9)
                {
                    errorProvider1.SetError(txtSDT, "Số điện thoại phải có 9 hoặc 10 kí tự !");
                    return;
                }
                else
                {
                    errorProvider1.Clear();
                }
                errorProvider1.Clear();
            }
			if(index == "Thêm")
			{
				string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);
				String maKHNew = "KH" + Functions.SinhMaTuDong(txtCCCD.Text);
				string sqlInsertKH = String.Format("Insert into tKhachHang " +
												   "Values('{0}',N'{1}','{2}','{3}',N'{4}','{5}','{6}')", maKHNew, txtHoTenKH.Text, ngaySinhChuan, cboGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtCCCD.Text);
				dtbase.ChangeData(sqlInsertKH);
				MessageBox.Show("Thêm thông tin khách hàng thành công");

				this.Visible = false;
				that.loadSauKhiThoatUC_KhachHang();
			}
			if (index == "Sửa")
			{
                string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);
                MessageBox.Show(TenKH);
				//string sqlUpdate = "Update tKhachHang set TenKhachHang = N'" + TenKH +"', NgaySinh = N'" + NgaySinh + "', GioiTinh = N'" + DiaChi + "', DienThoai = " + DienThoai + ", CCCD = N'" + cccd + "' where MaKhachHang = N'" + maKH +"'";
				string sqlUpdate = "Update tKhachHang set MaKhachHang = N'" + maKH + "', TenKhachHang = N'" + txtHoTenKH.Text + "', NgaySinh = N'" + ngaySinhChuan + "', GioiTinh = N'" + cboGioiTinh.Text + "', DiaChi = N'" + txtDiaChi.Text + "', DienThoai = N'" + txtSDT.Text + "', CCCD = N'" + txtCCCD.Text + "' where MaKhachHang = N'" + maKH + "'";
				//dtbase.ChangeData(sqlUpdate);
				dtbase.ChangeData(sqlUpdate);
				MessageBox.Show("Sửa thành công!");
				this.Visible = false;
				that.loadSauKhiThoatUC_KhachHang();
			}
		}
        private string chuyenNgay(string ngayVao)
        {
            if (ngayVao.Contains("/"))
            {
                DateTime date = DateTime.ParseExact(ngayVao, "dd/MM/yyyy", null);
                return date.ToString("yyyy-MM-dd");
            }
            else if (ngayVao.Contains("-"))
            {
                DateTime date = DateTime.ParseExact(ngayVao, "dd-MM-yyyy", null);
                return date.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime date = DateTime.ParseExact(ngayVao, "yyyy-MM-dd", null);
                return date.ToString("yyyy-MM-dd"); ;
            }
        }
    }
}
