using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.User_Controls
{
    public partial class UC_DatPhong : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormDatPhong that = new FormDatPhong();
        private string maKhach;
        private FlowLayoutPanel flpKhachHang = new FlowLayoutPanel();
        private Label lblLoi = new Label();

        public UC_DatPhong(FormDatPhong that)
        {
            InitializeComponent();
            this.that = that;
        }

        public UC_DatPhong()
        {
            InitializeComponent();
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
                lblLoi.BackColor = Color.WhiteSmoke;
                lblLoi.ForeColor = Color.Red;
                lblLoi.Location = new Point(dateTimeDi.Location.X, dateTimeDi.Location.Y + 38);
                panelContent.Controls.Add(lblLoi);
                lblLoi.BringToFront();
                return;
            }
            string maDatPhong = "PD" + Functions.SinhMaTuDong(txtCCCD.Text);
            string sqlDatPhong = "";
            string sqlKhachHang = String.Format("select * from tKhachHang where CCCD = '{0}'", txtCCCD.Text);
            string maKHNew = "";
            DataTable dtKhachHang = dtBase.ReadData(sqlKhachHang);

            if (dtKhachHang.Rows.Count == 0)
            {
                string ngaySinhChuan = chuyenNgay(txtNgaySinh.Text);
                maKHNew = "KH" + Functions.SinhMaTuDong(txtCCCD.Text);
                string sqlInsertKH = String.Format("Insert into tKhachHang " +
                                                   "Values('{0}',N'{1}','{2}','{3}','{4}','{5}','{6}')", maKHNew, txtTenKH.Text, ngaySinhChuan, cbGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtCCCD.Text);
                dtBase.ChangeData(sqlInsertKH);

                sqlDatPhong = String.Format("Insert into tPhieuDat " +
                                                  "Values('{0}','{1}','{2}','{3}','{4}','{5}')", maDatPhong, maKHNew, dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"), User.maNhanVien, DateTime.Now.ToString("yyyy-MM-dd"));
            }
            if (maKhach != null)
            {
                sqlDatPhong = String.Format("Insert into tPhieuDat " +
                                                    "Values('{0}','{1}','{2}','{3}','{4}','{5}')", maDatPhong, maKhach, dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"), User.maNhanVien, DateTime.Now.ToString("yyyy-MM-dd"));
            }
            dtBase.ChangeData(sqlDatPhong);

            foreach (DataGridViewRow row in dgvPhongChon.Rows)
            {
                string maPhong = row.Cells["maPhongC"].Value.ToString();

                string sqlChiTietPhongDat = String.Format("Insert into tChiTietPhongDat " +
                                                          "Values('{0}','{1}')", maDatPhong, maPhong);
                dtBase.ChangeData(sqlChiTietPhongDat);

            }
            MessageBox.Show("Đặt phòng thành công");
            this.Visible = false;
            that.loadPListPhong();
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

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            if (txtCCCD.Text == "")
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
            int chieuRong = (35 + 10) * listKhachHang.Count;
            flpKhachHang.Size = new Size(chieuDai, chieuRong);
            flpKhachHang.Location = new Point(122, 338);
            flpKhachHang.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flpKhachHang);
            flpKhachHang.BringToFront();
            foreach (DataRow row in listKhachHang)
            {
                string ngaySinh = ((DateTime)row["NgaySinh"]).ToString("dd-MM-yyyy");
                ButtonKhachHang panelKH = new ButtonKhachHang(row["TenKhachHang"].ToString(), ngaySinh, this);
                //panelKH.Margin = new Padding(); 
                flpKhachHang.Controls.Add(panelKH);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            that.loadPListPhong();
        }

        private void UC_DatPhong_Load(object sender, EventArgs e)
        {
            dateTimeDen.Value = DateTime.Now;
            DateTime date = dateTimeDen.Value;
            DateTime newDate = date.AddDays(5); // cộng 5 ngày
            string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
            dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            dgvPhongTrong.Rows.Clear();

            string sqlPhongThueVaDat = String.Format("SELECT tPhong.MaPhong, TenLoaiPhong, DonGiaPhong " +
                "FROM tPhong " +
                "inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
                "LEFT  JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                "LEFT  JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                "LEFT  JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                "WHERE (( '{0}' between NgayDenDuKien AND NgayDiDuKien) OR  ('{1}' between NgayDenDuKien AND NgayDiDuKien )) AND ThanhToan IS NULL " +
                "Order by tPhong.MaPhong", dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"));
            DataTable dtPhongThuevaDat = dtBase.ReadData(sqlPhongThueVaDat);

            string sqlCacPhong = String.Format("Select tPhong.MaPhong, TenLoaiPhong, DonGiaPhong " +
                                                "from tPhong inner join tLoaiPhong On tPhong.MaLoai = tLoaiPhong.MaLoai");

            DataTable dtPhong = dtBase.ReadData(sqlCacPhong);

            List<DataRow> listPhongThuevaDat = dtPhongThuevaDat.Select().ToList();
            List<DataRow> ListPhong = dtPhong.Select().ToList();
            dgvPhongTrong.RowTemplate.Height += 15;
            foreach (var item in ListPhong)
            {
                var maPhong = item.Field<string>("MaPhong");
                var matchingRow = listPhongThuevaDat.FirstOrDefault(row => row.Field<string>("MaPhong") == maPhong);
                if (matchingRow == null)
                {                 
                    string tenLoaiPhong = item.Field<string>("TenLoaiPhong");
                    decimal gia = item.Field<int>("DonGiaPhong");
                    dgvPhongTrong.Rows.Add(maPhong, tenLoaiPhong, gia);

                }
            }
         
            DataGridViewImageColumn imageColumn_Add = new DataGridViewImageColumn();
            imageColumn_Add.Image = Image.FromFile(Application.StartupPath + "\\" + "plus.png");
            imageColumn_Add.HeaderText = "Thêm";
            dgvPhongTrong.Columns.Add(imageColumn_Add);
            dgvPhongTrong.AllowUserToAddRows = false;

            dgvPhongChon.RowTemplate.Height += 15;
            DataGridViewImageColumn imageColumn_Delete = new DataGridViewImageColumn();
            imageColumn_Delete.Image = Image.FromFile(Application.StartupPath + "\\" + "remove.png");
            imageColumn_Delete.HeaderText = "Xóa";
            dgvPhongChon.Columns.Add(imageColumn_Delete);
            dgvPhongChon.AllowUserToAddRows = false;
        }

        private void dgvPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhongTrong.Columns[e.ColumnIndex].HeaderText == "Thêm")
            {
                string maPhong = dgvPhongTrong.CurrentRow.Cells["maPhong"].Value.ToString();
                string tenLoaiPhong = dgvPhongTrong.CurrentRow.Cells["tenLoaiPhong"].Value.ToString();
                string gia = dgvPhongTrong.CurrentRow.Cells["gia"].Value.ToString();
                dgvPhongChon.Rows.Add(maPhong, tenLoaiPhong, gia);
                dgvPhongTrong.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvPhongChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhongChon.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string maPhong = dgvPhongChon.CurrentRow.Cells["maPhongC"].Value.ToString();
                string tenLoaiPhong = dgvPhongChon.CurrentRow.Cells["tenLoaiPhongC"].Value.ToString();
                string gia = dgvPhongChon.CurrentRow.Cells["giaC"].Value.ToString();
                dgvPhongTrong.Rows.Add(maPhong, tenLoaiPhong, gia);
                dgvPhongChon.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dateTimeDen_ValueChanged(object sender, EventArgs e)
        {
            dgvPhongTrong.Rows.Clear();
            dgvPhongChon.Rows.Clear();
            DateTime date = dateTimeDen.Value;
            DateTime newDate = date.AddDays(5); // cộng 5 ngày
            string dateString = newDate.ToString("yyyy-MM-dd"); // Chuyển đổi thành chuỗi với định dạng "yyyy-MM-dd"
            dateTimeDi.Value = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture); // Gán giá trị cho thuộc tính Value của dateTimeDi
            loadPhongTrong(dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"));
        }

        private void dateTimeDi_ValueChanged(object sender, EventArgs e)
        {
            dgvPhongTrong.Rows.Clear();
            dgvPhongChon.Rows.Clear();
            loadPhongTrong(dateTimeDen.Value.ToString("yyyy-MM-dd"), dateTimeDi.Value.ToString("yyyy-MM-dd"));
        }


        private void loadPhongTrong (string ngayDen, string ngayDi)
        {
            dgvPhongTrong.Rows.Clear();
            string sqlPhongThueVaDat = String.Format("SELECT tPhong.MaPhong, TenLoaiPhong, DonGiaPhong " +
               "FROM tPhong " +
               "inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
               "LEFT  JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
               "LEFT  JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
               "LEFT  JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
               "WHERE (( '{0}' between NgayDenDuKien AND NgayDiDuKien) OR  ('{1}' between NgayDenDuKien AND NgayDiDuKien )) AND ThanhToan IS NULL " +
               "Order by tPhong.MaPhong", ngayDen, ngayDi);
            DataTable dtPhongThuevaDat = dtBase.ReadData(sqlPhongThueVaDat);

            string sqlCacPhong = String.Format("Select tPhong.MaPhong, TenLoaiPhong, DonGiaPhong " +
                                                "from tPhong inner join tLoaiPhong On tPhong.MaLoai = tLoaiPhong.MaLoai");

            DataTable dtPhong = dtBase.ReadData(sqlCacPhong);

            List<DataRow> listPhongThuevaDat = dtPhongThuevaDat.Select().ToList();
            List<DataRow> ListPhong = dtPhong.Select().ToList();
            foreach (var item in ListPhong)
            {
                var maPhong = item.Field<string>("MaPhong");
                var matchingRow = listPhongThuevaDat.FirstOrDefault(row => row.Field<string>("MaPhong") == maPhong);
                if (matchingRow == null)
                {
                    string tenLoaiPhong = item.Field<string>("TenLoaiPhong");
                    decimal gia = item.Field<int>("DonGiaPhong");
                    dgvPhongTrong.Rows.Add(maPhong, tenLoaiPhong, gia);

                }
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
                return "";
            }
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

        private void txtCCCD_Tab(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                flpKhachHang.Visible = false;
            }
        }
    }
}
