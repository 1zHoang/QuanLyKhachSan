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
    public partial class FormQuanLyKhachHang : Form
    {
        private DataProcesser dtbase = new DataProcesser();
		public FormQuanLyKhachHang()
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            UC_KhachHang  ucKhachHang = new UC_KhachHang(this,"Thêm");
            ucKhachHang.Location = new Point(365, 55);
            this.Controls.Add(ucKhachHang);
            ucKhachHang.BringToFront();
        }

		private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
		{
			grvKhachHang.RowTemplate.Height += 15;
            DataTable dt = new DataTable();
            dt = dtbase.ReadData("Select * from tKhachHang");
            grvKhachHang.DataSource = dt;
			grvKhachHang.Columns[1].Width = 200;
			DataGridViewImageColumn imageColumn_Add = new DataGridViewImageColumn();
			imageColumn_Add.Image = Image.FromFile(Application.StartupPath + "\\" + "plus.png");
			imageColumn_Add.HeaderText = "Sửa";
			grvKhachHang.Columns.Add(imageColumn_Add);
			grvKhachHang.AllowUserToAddRows = false;

			DataGridViewImageColumn imageColumn_Delete = new DataGridViewImageColumn();
			imageColumn_Delete.Image = Image.FromFile(Application.StartupPath + "\\" + "remove.png");
			imageColumn_Delete.HeaderText = "Xóa";
			//grvKhachHang.RowTemplate.Height += 15;
			grvKhachHang.Columns.Add(imageColumn_Delete);
			grvKhachHang.AllowUserToAddRows = false;
		}

		private void grvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

        public void loadSauKhiThoatUC_KhachHang()
        {
			DataTable dt = new DataTable();
			dt = dtbase.ReadData("Select * from tKhachHang");
			grvKhachHang.DataSource = dt;

		}

		private void grvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            string makhachhang = grvKhachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            UC_ChiTietKhachHang ucChiTiet = new UC_ChiTietKhachHang(makhachhang);
            int rowIndex = e.RowIndex;
            string tenkhachhang = grvKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            string cccd = grvKhachHang.CurrentRow.Cells["CCCD"].Value.ToString();
            DateTime ngaySinhKieuDate = (DateTime)grvKhachHang.CurrentRow.Cells["NgaySinh"].Value;
            string ngaysinh = ngaySinhKieuDate.ToString("dd/MM/yyyy");
            string gioitinh = grvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString();
            string diachi = grvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            string SDT = grvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
            if (grvKhachHang.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn có muốn xóa khách hàng :" + tenkhachhang + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    grvKhachHang.Rows.RemoveAt(grvKhachHang.CurrentRow.Index);
                    string sqlDelete = string.Format("Delete from tKhachHang where MaKhachHang = N'{0}'", makhachhang);
                    dtbase.ChangeData(sqlDelete);                    
                }
                return;
            }
            if (grvKhachHang.Columns[e.ColumnIndex].HeaderText == "Sửa")
            {
                UC_KhachHang ucKhachHang = new UC_KhachHang(this, makhachhang, tenkhachhang, ngaysinh, gioitinh, diachi, SDT, cccd, "Sửa");
                ucKhachHang.Location = new Point(365, 55);
                this.Controls.Add(ucKhachHang);
                ucKhachHang.BringToFront();
                return;
            }

            if (grvKhachHang.Columns[e.ColumnIndex].HeaderText == "Xóa" || grvKhachHang.Columns[e.ColumnIndex].HeaderText == "Sửa")
            {
                ucChiTiet.Visible = false;
            }
            if (rowIndex > 0 && rowIndex < grvKhachHang.Rows.Count)
			{
				// Lưu trữ dòng được click
				DataGridViewRow selectedRow = grvKhachHang.Rows[rowIndex];

				// Lấy nguồn dữ liệu (DataTable)
				DataTable dataTable = (DataTable)grvKhachHang.DataSource;

				// Lấy dữ liệu từ dòng được click
				DataRow selectedDataRow = ((DataRowView)selectedRow.DataBoundItem).Row;

				// Tạo một dòng mới
				DataRow newRow = dataTable.NewRow();
				newRow.ItemArray = selectedDataRow.ItemArray;

				dataTable.Rows.Remove(selectedDataRow);

				dataTable.Rows.InsertAt(newRow, 0);

				grvKhachHang.Refresh();
				if (rowIndex + 1 == grvKhachHang.Rows.Count)
					grvKhachHang.Rows[rowIndex].Selected = false;
				else
					grvKhachHang.Rows[rowIndex + 1].Selected = false;

				grvKhachHang.Rows[0].Selected = true;
             
                ucChiTiet.Location = new Point(100, 200);
                this.Controls.Add(ucChiTiet);
                ucChiTiet.BringToFront();
            }
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			string sqlKhachHang = String.Format("select MaKhachHang, TenKhachHang, NgaySinh, GioiTinh from tKhachHang where TenKhachHang like N'%{0}%'", txtSearch.Text);
			DataTable dtKhachHang = dtbase.ReadData(sqlKhachHang);
			grvKhachHang.DataSource = dtKhachHang;
			grvKhachHang.AllowUserToAddRows = false;
		}
		public void loadDSKhachHang()
		{
			string sqlKhachHang = String.Format("select MaKhachHang, TenKhachHang, NgaySinh, GioiTinh from tKhachHang");
			DataTable dtKhachHang = dtbase.ReadData(sqlKhachHang);
			grvKhachHang.DataSource = dtKhachHang;
			grvKhachHang.AllowUserToAddRows = false;
		}
	}
}
