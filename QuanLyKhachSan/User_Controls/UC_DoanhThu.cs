using QuanLyKhachSan.Classes;
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
    public partial class UC_DoanhThu : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private string yeucau;
        private int thang;
        private int nam;
        public UC_DoanhThu()
        {
            InitializeComponent();
        }

        public UC_DoanhThu(string yeuCau, int thang, int nam)
        {
            this.yeucau = yeuCau;
            this.thang = thang;
            this.nam = nam;
            InitializeComponent();
        }

        private void UC_DoanhThu_Load(object sender, EventArgs e)
        {
            dgvDoanhThu.RowTemplate.Height += 15;
            dgvDoanhThu.AllowUserToAddRows = false;
            if (yeucau == "Phòng")
            {
                lblTieuDe.Text = "Thống Kê Doanh Thu Phòng";
                string sqlDoanhThuTungPhong = String.Format("select * from DoanhThuPhong({0}, {1})", thang, nam);
                DataTable dtDoanhThuTungPhong = dtBase.ReadData(sqlDoanhThuTungPhong);
                dgvDoanhThu.DataSource = dtDoanhThuTungPhong;

                List<DataRow> rows = dtDoanhThuTungPhong.Select().OrderByDescending(row => (int)row["DoanhThuPhong"]).Take(3).ToList();
                if (rows.Count >= 1)
                    lblTop1.Text =  "Phòng " + rows[0].Field<String>("MaPhong").ToString();
                if (rows.Count >= 2)
                    lblTop2.Text =  "Phòng " + rows[1].Field<String>("MaPhong").ToString();
                if (rows.Count >= 3)
                    lblTop3.Text =  "Phòng " + rows[2].Field<String>("MaPhong").ToString();
            }
            else if(yeucau == "Dịch vụ")
            {
                lblTieuDe.Text = "Thống Kê Doanh Thu Sản Phẩm";
                string sqlDoanhThuTungSP = String.Format(" select* from DoanhThuDV({0}, {1})", thang, nam);
                DataTable dtDoanhThuTungSP = dtBase.ReadData(sqlDoanhThuTungSP);
                dgvDoanhThu.DataSource = dtDoanhThuTungSP;
                List<DataRow> rows = dtDoanhThuTungSP.Select().OrderByDescending(row => (int)row["TienDV"]).Take(3).ToList() ;
                if (rows.Count >= 1)
                    lblTop1.Text = rows[0].Field<string>("TenSanPham").ToString();

                if (rows.Count >= 2)
                    lblTop2.Text = rows[1].Field<string>("TenSanPham").ToString();

                if (rows.Count >= 3)
                    lblTop3.Text = rows[2].Field<string>("TenSanPham").ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
