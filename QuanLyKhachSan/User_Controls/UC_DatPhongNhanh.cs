using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKhachSan.User_Controls
{
    public partial class UC_DatPhongNhanh : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormDanhSachPhong that = new FormDanhSachPhong();
        private string namePhong;
        private string tenLoai;
        private string maKhach;
        private FlowLayoutPanel flpKhachHang = new FlowLayoutPanel();
        private Label lblLoi = new Label();

        public UC_DatPhongNhanh(FormDanhSachPhong that, string namePhong, string tenLoai)
        {
            InitializeComponent();
            this.that = that;
            this.namePhong = namePhong;
            this.tenLoai = tenLoai;
        }
        public UC_DatPhongNhanh()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void UC_DatPhongNhanh_Load(object sender, EventArgs e)
        {
            dateTimeDen.Value = DateTime.Today;
            string sqlTimNgay = String.Format("SELECT TOP 1 NgayDenDuKien " +
                                                "FROM tPhieuDat inner join tChiTietPhongDat ON tPhieuDat.MaPhieuDat = tChiTietPhongDat.MaPhieuDat " +
                                                "WHERE NgayDenDuKien > '{0}' AND MaPhong = '{1}' " +
                                                "ORDER BY NgayDenDuKien ASC;", DateTime.Today.ToString("yyyy-MM-dd"), namePhong);
            DataTable dtNgay = dtBase.ReadData(sqlTimNgay);
            if(dtNgay.Rows.Count > 0)
            {
                DateTime date = dtNgay.Rows[0].Field<DateTime>("NgayDenDuKien").Date; // Lấy ngày từ cột "NgayDenDuKien" và bỏ đi phần thời gian
                DateTime newDate = date.AddDays(-1); // Trừ đi 1 ngày
                string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
                dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            }
            else
            {
                DateTime date = dateTimeDen.Value;
                DateTime newDate = date.AddMonths(1);
                string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
                dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            }

            lblPhongDat.Text = namePhong;
            lblLoaiPhong.Text = tenLoai;       
        }
        private void dateTimeDen_ValueChanged(object sender, EventArgs e)
        {
            string sqlTimNgay = String.Format("SELECT TOP 1 NgayDenDuKien " +
                                                "FROM tPhieuDat inner join tChiTietPhongDat ON tPhieuDat.MaPhieuDat = tChiTietPhongDat.MaPhieuDat " +
                                                "WHERE NgayDenDuKien >= '{0}' AND MaPhong = '{1}' " +
                                                "ORDER BY NgayDenDuKien ASC;", dateTimeDen.Value, namePhong);
            DataTable dtNgay = dtBase.ReadData(sqlTimNgay);
            if (dtNgay.Rows.Count > 0)
            {
                DateTime date = dtNgay.Rows[0].Field<DateTime>("NgayDenDuKien").Date; // Lấy ngày từ cột "NgayDenDuKien" và bỏ đi phần thời gian
                DateTime newDate = date.AddDays(-1); // Trừ đi 1 ngày
                string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
                dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            }
            else
            {
                DateTime date = dateTimeDen.Value;
                DateTime newDate = date.AddMonths(1); // cộng 2 tháng
                string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
                dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            }
        }
        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            if(txtCCCD.Text == "")
            {

                flpKhachHang.Visible = false;
                return;
            }
            flpKhachHang.Visible = true;
            string sqlTimKhachHang = string.Format("Select * from tKhachHang WHERE CCCD  LIKE '%{0}%'", txtCCCD.Text);
            DataTable dtKhachHang = dtBase.ReadData(sqlTimKhachHang);

            List<DataRow> listKhachHang = dtKhachHang.Select().ToList();
            flpKhachHang.Controls.Clear();
            int chieuDai = 259;
            int chieuRong = ( 35 + 10) * listKhachHang.Count;
            flpKhachHang.Size = new Size(chieuDai, chieuRong);
            flpKhachHang.Location = new Point(138,342);
            flpKhachHang.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flpKhachHang);
            flpKhachHang.BringToFront();
            foreach (DataRow row in listKhachHang)
            {
                string ngaySinh = ((DateTime)row["NgaySinh"]).ToString("dd-MM-yyyy");
                ButtonKhachHang panelKH = new ButtonKhachHang(row["TenKhachHang"].ToString(), ngaySinh, this);
                flpKhachHang.Controls.Add(panelKH);
            }
        }
        public void dienThongTinKhachHang(string TenKhachHang, string ngaySinh)
        {
            string sqlKhachHang = String.Format("Select * from tKhachHang WHERE CCCD  LIKE '%{0}%' AND TenKhachHang = N'{1}'", txtCCCD.Text, TenKhachHang, ngaySinh);
            DataTable dtKhachHang = dtBase.ReadData(sqlKhachHang);
            txtTenKH.Text = dtKhachHang.Rows[0].Field<string>("TenKhachHang");
            txtNgaySinh.Text = dtKhachHang.Rows[0].Field<DateTime>("NgaySinh").ToString("dd-MM-yyyy");
            txtCCCD.Text = dtKhachHang.Rows[0].Field<string>("CCCD");
            txtSDT.Text = dtKhachHang.Rows[0].Field<string>("DienThoai");
            txtDiaChi.Text = dtKhachHang.Rows[0].Field<string>("DiaChi");
            cbGioiTinh.Text = dtKhachHang.Rows[0].Field<string>("GioiTinh");
            maKhach = dtKhachHang.Rows[0].Field<string>("MaKhachHang");
            flpKhachHang.Visible = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim() == "")
            {
                checkLoi(txtTenKH, "Không được để tên khách hàng trống");
                return;
            }
            if (txtNgaySinh.Text.Trim() == "")
            {
                checkLoi(txtNgaySinh, "Không được để ngày sinh trống");
                return;
            }
            if (txtNgaySinh.Text.Trim().Length < 9 || txtNgaySinh.Text.Trim().Length > 10)
            {
                checkLoi(txtNgaySinh, "Ngày sinh không hợp lệ");
                return;
            }
            if (txtCCCD.Text.Trim() == "")
            {
                checkLoi(txtCCCD, "Không được để CCCD trống");
                return;
            }
            if (txtCCCD.Text.Trim().Length < 11)
            {
                checkLoi(txtCCCD, "Số căn công dân không hợp lệ");
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                checkLoi(txtSDT, "Không được để số điện thoại trống");
                return;
            }
            if (txtSDT.Text.Trim().Length < 10)
            {
                checkLoi(txtSDT, "Số điện thoại không hợp lệ");
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                checkLoi(txtDiaChi, "Không được để địa chỉ trống");
                return;
            }
            if (dateTimeDi.Value < dateTimeDen.Value)
            {
                lblLoi = new Label();
                lblLoi.Text = "* Thời gian đi không hợp lệ";
                lblLoi.Font = new Font("Microsoft Sans Serif", 9f);
                lblLoi.AutoSize = true;
                lblLoi.BackColor = Color.White;
                lblLoi.ForeColor = Color.Red;
                lblLoi.Location = new Point(dateTimeDi.Location.X, dateTimeDi.Location.Y + 38);
                panelCRight.Controls.Add(lblLoi);
                lblLoi.BringToFront();
                return;
            }     
        string maDatPhong = "PD" + Functions.SinhMaTuDong(txtCCCD.Text);
            string sqlDatPhong = "";
            string sqlKhachHang = String.Format("select * from tKhachHang where CCCD = '{0}'", txtCCCD.Text);
            string maKHNew = "";
            DataTable dtKhachHang = dtBase.ReadData(sqlKhachHang);
            if(dtKhachHang.Rows.Count == 0)
            {
                string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);
                maKHNew = "KH" + Functions.SinhMaTuDong(txtCCCD.Text);
                string sqlInsertKH = String.Format("Insert into tKhachHang " +
                                                   "Values('{0}',N'{1}','{2}','{3}','{4}','{5}','{6}')", maKHNew,txtTenKH.Text, ngaySinhChuan, cbGioiTinh.Text,txtDiaChi.Text, txtSDT.Text, txtCCCD.Text);
                dtBase.ChangeData(sqlInsertKH);

                sqlDatPhong = String.Format("Insert into tPhieuDat " +
                                                  "Values('{0}','{1}','{2}','{3}','{4}','{5}')", maDatPhong, maKHNew, dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"), User.maNhanVien, DateTime.Now.ToString("yyyy-MM-dd"));
            }
            if (maKhach != null)
            {
                sqlDatPhong = String.Format("Insert into tPhieuDat " +
                                                    "Values('{0}','{1}','{2}','{3}','{4}','{5}')", maDatPhong, maKhach, dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"), User.maNhanVien, DateTime.Now.ToString("yyyy-MM-dd"));
            }
                
            string sqlChiTietPhongDat = String.Format("Insert into tChiTietPhongDat " +
                                                      "Values('{0}','{1}')", maDatPhong, namePhong);

            dtBase.ChangeData(sqlDatPhong);
            dtBase.ChangeData(sqlChiTietPhongDat);

            MessageBox.Show("Đặt phòng thành công");
            this.Visible = false;
            that.LoadSauKhiThoatUC_ChiTiet();
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
                return "";
            }
        }

        private void checkLoi(Guna2TextBox txtBox, string loi)
        {
            txtBox.BorderColor = Color.Red;
            lblLoi = new Label();
            lblLoi.Text =  "* " + loi;
            lblLoi.Font = new Font("Microsoft Sans Serif", 9f);
            lblLoi.AutoSize = true;
            lblLoi.BackColor = Color.WhiteSmoke;
            lblLoi.ForeColor = Color.Red;
            lblLoi.Location = new Point(txtBox.Location.X, txtBox.Location.Y + 41);
            panelContent.Controls.Add(lblLoi);
            lblLoi.BringToFront();
        }

        private void ClickNhapLai(object sender, EventArgs e)
        {
            try
            {
                Guna2TextBox rdo = (Guna2TextBox)sender;
                rdo.BorderColor = Color.FromArgb(213, 218, 223);
                if (lblLoi.Visible == true)
                    lblLoi.Visible = false;
            }
            catch (InvalidCastException)
            {
                Guna2DateTimePicker rdo = (Guna2DateTimePicker)sender;
                rdo.BorderColor = Color.White;
                if (lblLoi.Visible == true)
                    lblLoi.Visible = false;
            }

        }

        private void txtCCCD_Tab(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                flpKhachHang.Visible = false;
            }
        }  
    }
}
