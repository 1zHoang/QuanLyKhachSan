using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Model;
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
    public partial class FormQuanLyNhanVien : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        public FormQuanLyNhanVien()
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

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien ucNhanVien = new UC_NhanVien(this);
            ucNhanVien.Location = new Point(165, 55);
            this.Controls.Add(ucNhanVien);
            ucNhanVien.BringToFront();


        }

        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            string sqlNhanVien = String.Format("Select MaNhanVien, TenNhanVien, CCCD, GioiTinh, DienThoai, NgaySinh, ChucVu from tNhanVien");
            DataTable dtNhanVien = dtBase.ReadData(sqlNhanVien);
            dgvNhanVien.RowTemplate.Height += 15;
            dgvNhanVien.DataSource = dtNhanVien;
            dgvNhanVien.AllowUserToAddRows = false;

            dgvNhanVien.Columns["MaNhanVien"].Width = 120;
            dgvNhanVien.Columns["ChucVu"].Width = 120;
            dgvNhanVien.Columns["GioiTinh"].Width = 120;

            DataGridViewImageColumn imageColumn_Detail = new DataGridViewImageColumn();
            imageColumn_Detail.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Detail.HeaderText = "Chi tiết";
            imageColumn_Detail.Name = "Sua";
            dgvNhanVien.Columns.Add(imageColumn_Detail);
            dgvNhanVien.Columns["Sua"].Width = 80;


            DataGridViewImageColumn imageColumn_Remove = new DataGridViewImageColumn();
            imageColumn_Remove.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove.HeaderText = "Xóa";
            imageColumn_Remove.Name = "Xoa";
            dgvNhanVien.Columns.Add(imageColumn_Remove);
            dgvNhanVien.Columns["Xoa"].Width = 80;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].HeaderText == "Chi tiết")
            {
                string sqlMotNV = String.Format("select * from tNhanVien where MaNhanVien = '{0}'", dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                DataTable dtMotNV = dtBase.ReadData(sqlMotNV);
                if(dtMotNV.Rows.Count > 0)
                {
                    string maNhanVien = dtMotNV.Rows[0].Field<string>("MaNhanVien").ToString();
                    string tenNhanVien = dtMotNV.Rows[0].Field<string>("TenNhanVien").ToString();
                    string cCCD = dtMotNV.Rows[0].Field<string>("CCCD").ToString();
                    string gioiTinh = dtMotNV.Rows[0].Field<string>("GioiTinh").ToString();
                    string diaChi = dtMotNV.Rows[0].Field<string>("DiaChi").ToString();
                    string dienThoai = dtMotNV.Rows[0].Field<string>("DienThoai").ToString();
                    string ngaySinh = dtMotNV.Rows[0].Field<DateTime>("NgaySinh").ToString("dd/MM/yyyy");
                    string nameAnh = dtMotNV.Rows[0].Field<string>("Anh").ToString();
                    string chucVu = dtMotNV.Rows[0].Field<string>("ChucVu").ToString();
                    int luong = dtMotNV.Rows[0].Field<int>("Luong");

                    NhanVien nhanVien = new NhanVien(maNhanVien, tenNhanVien,cCCD,gioiTinh,diaChi,dienThoai,ngaySinh,nameAnh,chucVu,luong);

                    UC_NhanVien ucNhanVien = new UC_NhanVien(nhanVien, this);
                    ucNhanVien.Location = new Point(165, 55);
                    this.Controls.Add(ucNhanVien);
                    ucNhanVien.BringToFront();
                }
            }
            //if (dgvCacPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
            //{
            //    string sqlXoaPhong = String.Format("Delete from tPhong where MaPhong = '{0}'", txtMaPhong.Text = dgvCacPhong.CurrentRow.Cells["MaPhong"].Value.ToString());
            //    if (MessageBox.Show("Bạn chắc chắn muốn xóa phòng này?", "TB", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        dtBase.ChangeData(sqlXoaPhong);
            //    }
            //    loadDGVPhong();
            //}
        }

        public void loadDGVNhanVien()
        {
            string sqlNhanVien = String.Format("Select MaNhanVien, TenNhanVien, CCCD, GioiTinh, DienThoai, NgaySinh, ChucVu from tNhanVien");
            DataTable dtNhanVien = dtBase.ReadData(sqlNhanVien);
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sqlNhanVien = String.Format("Select MaNhanVien, TenNhanVien, CCCD, GioiTinh, DienThoai, NgaySinh, ChucVu from tNhanVien " +
                                               "Where MaNhanVien like '%{0}%' or TenNhanVien like N'%{0}%' or CCCD like '%{0}%' or GioiTinh like '%{0}%' or DienThoai like '%{0}%' or ChucVu like N'%{0}%'", txtSearch.Text);
            DataTable dtNhanVien = dtBase.ReadData(sqlNhanVien);
            dgvNhanVien.DataSource = dtNhanVien;
        }
    }
}
