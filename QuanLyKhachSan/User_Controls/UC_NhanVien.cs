using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
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
    public partial class UC_NhanVien : UserControl
    {
        private Label lblLoi = new Label();
        private FormQuanLyNhanVien that;
        private NhanVien nhanVien;
        private string picName;
        private DataProcesser dtBase = new DataProcesser();
        public UC_NhanVien()
        {
            InitializeComponent();
        }
        public UC_NhanVien(FormQuanLyNhanVien that)
        {
            this.that = that;
            InitializeComponent();
        }
        public UC_NhanVien(NhanVien nhanVien, FormQuanLyNhanVien that)
        {
            this.that = that;
            this.nhanVien = nhanVien;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            if(nhanVien != null)
            {
                lblTieuDe.Text = "Thông tin nhân viên";
                txtHoTen.Text = nhanVien.tenNhanVien;
                txtNgaySinh.Text = nhanVien.ngaySinh;
                txtCCCD.Text = nhanVien.cCCD;
                cbGioiTinh.Text = nhanVien.gioiTinh;
                txtLuong.Text = nhanVien.luong.ToString();
                txtSDT.Text = nhanVien.dienThoai;
                txtDiaChi.Text = nhanVien.diaChi;
                txtChucVu.Text = nhanVien.chucVu;
                try
                {
                    picBox.Image = Image.FromFile(Application.StartupPath + "\\" + nhanVien.nameAnh);
                    picName = nhanVien.nameAnh;
                }
                catch (System.IO.FileNotFoundException)
                {

                }         
                HienTxt(false);
                btnLuu.Visible = false;
                btnThem.Visible = false;
            }
            else
            {
                btnLuu.Visible = false;
                btnChinhSua.Visible = false;
            }


        }

        private void HienTxt(bool hien)
        {
            txtHoTen.Enabled = hien;
            txtNgaySinh.Enabled = hien;
            txtCCCD.Enabled = hien;
            cbGioiTinh.Enabled = hien;
            txtLuong.Enabled = hien;
            txtSDT.Enabled = hien;
            txtDiaChi.Enabled = hien;
            txtChucVu.Enabled = hien;
            btnAnh.Enabled = hien;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            HienTxt(true);
            btnLuu.Visible=true;
            btnChinhSua.Visible=false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                checkLoi(txtHoTen, "Không được để tên khách hàng trống");
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
            if (txtCCCD.Text.Trim().Length < 12)
            {
                checkLoi(txtCCCD, "Số căn công dân không hợp lệ");
                return;
            }
            if (txtLuong.Text.Trim() == "")
            {
                checkLoi(txtLuong, "Không được để lương trống");
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
            if(txtChucVu.Text.Trim() == "")
            {
                checkLoi(txtDiaChi, "Không được để chức vụ trống");
                return;
            }
            string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);
            string maNhanVien = "NV" + Functions.SinhMaTuDong(txtCCCD.Text);
            string sqlThemNhanVien = String.Format("Insert into tNhanVien " +
                                                   "Values('{0}', N'{1}','{2}','{3}', N'{4}','{5}','{6}','{7}',N'{8}',{9})",
                                                   maNhanVien,txtHoTen.Text, txtCCCD.Text, cbGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, ngaySinhChuan, picName, txtChucVu.Text, int.Parse(txtLuong.Text));
            dtBase.ChangeData(sqlThemNhanVien);
            MessageBox.Show("Thêm nhân viên thành công");
            that.loadDGVNhanVien();
            this.Visible = false;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFie = new OpenFileDialog();
            openFie.Filter = "JPEG images|*.jpg|Bitmap images|*.bmp|All Filtes|*.*";
            openFie.FilterIndex = 1;
            if (openFie.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = Image.FromFile(openFie.FileName);
                picName = openFie.SafeFileName;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                checkLoi(txtHoTen, "Không được để tên khách hàng trống");
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
            if (txtCCCD.Text.Trim().Length < 12)
            {
                checkLoi(txtCCCD, "Số căn công dân không hợp lệ");
                return;
            }
            if (txtLuong.Text.Trim() == "")
            {
                checkLoi(txtLuong, "Không được để lương trống");
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
            if (txtChucVu.Text.Trim() == "")
            {
                checkLoi(txtDiaChi, "Không được để chức vụ trống");
                return;
            }
            string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);       
            string sqlSuaNhanVien = String.Format("Update  tNhanVien " +
                                                   "Set TenNhanVien =  N'{1}', CCCD = '{2}', GioiTinh = '{3}', DiaChi = N'{4}', DienThoai = '{5}', NgaySinh = '{6}', Anh = '{7}', ChucVu =  N'{8}', luong = {9} " +
                                                   "where MaNhanVien = '{0}'",
                                                   nhanVien.maNhanVien, txtHoTen.Text, txtCCCD.Text, cbGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, ngaySinhChuan, picName, txtChucVu.Text, int.Parse(txtLuong.Text));
            dtBase.ChangeData(sqlSuaNhanVien);
            MessageBox.Show("Sửa nhân viên thành công");
            that.loadDGVNhanVien();
            this.Visible = false;
        }

        private void checkLoi(Guna2TextBox txtBox, string loi)
        {
            txtBox.BorderColor = Color.Red;
            lblLoi = new Label();
            lblLoi.Text = "* " + loi;
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
