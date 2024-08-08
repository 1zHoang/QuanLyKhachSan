using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.DangNhap;
using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKhachSan.User_Controls
{
    public partial class LeftMenu : UserControl
    {
        private List<DanhMuc> listDM = new List<DanhMuc>();
        public LeftMenu()
        {
            InitializeComponent();
        }
        private void btnAn_Click_2(object sender, EventArgs e)
        {
            this.Width = 260;
            transactionLeftMenu.HideSync(this);

        }

        private void LeftMenu_Load(object sender, EventArgs e)
        {
            lblTenNhanVien.Text = User.tenNhanVien;
            listDM = ListDanhMucTheoQuyen.ListDanhMuc(User.quyenHan);
            foreach(var item in listDM)
            {
                ButtonMenu btn = new ButtonMenu(item.Name,item.Form, item.Icon, this.ParentForm);
                btn.Margin = new Padding(5);
                flpDanhMuc.Controls.Add(btn);                
            }
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
        }
    }
}
