using Guna.UI2.WinForms;
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
    public partial class UC_TaiKhoan : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FlowLayoutPanel flpNhanVien = new FlowLayoutPanel();
        private FormQuanLyTaiKhoan that;
        private string maNhanVien;
        private string taiKhoan;
        private string quyen;
        private string tinhTrang;

        public UC_TaiKhoan(string maNhanVien, string taiKhoan, string quyen, string tinhTrang ,FormQuanLyTaiKhoan that)
        {
            this.maNhanVien = maNhanVien;
            this.taiKhoan = taiKhoan; ;
            this.quyen = quyen;
            this.that = that;
            this.tinhTrang = tinhTrang;
            InitializeComponent();
        }

        public UC_TaiKhoan(FormQuanLyTaiKhoan that, string tinhTrang)
        {
            this.that = that;
            InitializeComponent();
            this.tinhTrang = tinhTrang;
        }
        public UC_TaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                flpNhanVien.Visible = false;
                return;
            }
            flpNhanVien.Visible = true;
            string sqlTimNhanVien = string.Format("Select * from tNhanVien WHERE MaNhanVien  LIKE '%{0}%'", txtMaNhanVien.Text);
            DataTable dtNhanVien = dtBase.ReadData(sqlTimNhanVien);

            List<DataRow> listNhanVien = dtNhanVien.Select().ToList();
            flpNhanVien.Controls.Clear();
            int chieuDai = 259;
            int chieuRong = (35 + 10) * listNhanVien.Count;
            flpNhanVien.Size = new Size(chieuDai, chieuRong);
            flpNhanVien.Location = new Point(170,155);
            flpNhanVien.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flpNhanVien);
            flpNhanVien.BringToFront();
            foreach (DataRow row in listNhanVien)
            {
                Guna2Button btn = new Guna2Button();
                btn.Size = new Size(260, 35);
                btn.Text = row["MaNhanVien"].ToString() + " - " + row["TenNhanVien"].ToString();
                btn.Font = new Font("Microsoft Sans Serif", 10f);
                //BackColor = Color.White;
                btn.FillColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.TextAlign = HorizontalAlignment.Left;
                btn.Click += (clickSender, clickEvent) =>
                {
                    txtMaNhanVien.Text = row["MaNhanVien"].ToString();
                    flpNhanVien.Visible = false;
                };
                flpNhanVien.Controls.Add(btn);
            }
        }

        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            if(tinhTrang.Equals("Sửa"))
            {
                txtMaNhanVien.Text = maNhanVien;
                txtMaNhanVien.Enabled = false;
                txtTaiKhoan.Text = taiKhoan;
                cbQuyen.Text = quyen;
                lblTieuDe.Text = "Sửa thông tin";
                flpNhanVien.Visible = false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(tinhTrang.Equals("Thêm"))
            {
                string matKhau = Functions.MaHoaMatKhau(txtMatKhau.Text);
                string sqlThemTK = String.Format("insert into tUser " +
                                                 "values ('{0}','{1}','{2}','{3}')", txtMaNhanVien.Text, txtTaiKhoan.Text, matKhau, cbQuyen.Text);
                dtBase.ChangeData(sqlThemTK);
                MessageBox.Show("Thêm tài khoản thành công");
                that.loadDGVTaiKhoan();
            }
            else if(tinhTrang.Equals("Sửa"))
            {
                string matKhau = Functions.MaHoaMatKhau(txtMatKhau.Text);
                string sqlSuaTK = String.Format("update tUser " +
                                                "set MaNhanVien = '{0}',Username =  '{1}', Pass = '{2}', Quyen = '{3}' where MaNhanVien = '{0}'", txtMaNhanVien.Text, txtTaiKhoan.Text, matKhau, cbQuyen.Text);
                dtBase.ChangeData(sqlSuaTK);
                MessageBox.Show("Thay đổi thành công");
                that.loadDGVTaiKhoan();
            }
        }
    }
}
