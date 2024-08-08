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

namespace QuanLyKhachSan.DangNhap
{
    public partial class FormDangNhap : Form
    {
        DataProcesser dtBase = new DataProcesser();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = Functions.MaHoaMatKhau(txtMatKhau.Text);
            string sqlDangNhap = String.Format("select *, TenNhanVien from tUser inner join tNhanVien on tUser.MaNhanVien = tNhanVien.MaNhanVien where Username = '{0}' and Pass = '{1}'", taiKhoan, matKhau);
            DataTable tuser = dtBase.ReadData(sqlDangNhap);
            if (tuser.Rows.Count > 0)
            {
                User.maNhanVien = tuser.Rows[0].Field<string>("MaNhanVien");
                User.quyenHan = tuser.Rows[0].Field<int>("Quyen");
                User.tenNhanVien = tuser.Rows[0].Field<string>("TenNhanVien");
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.Show();
                this.Visible = false;
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            label4.Image = (Image)Properties.Resources.ResourceManager.GetObject("user");
        }
    }
}
