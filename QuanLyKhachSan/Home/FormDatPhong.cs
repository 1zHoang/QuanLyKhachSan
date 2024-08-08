using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.User_Controls;
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

namespace QuanLyKhachSan.Home
{
    public partial class FormDatPhong : Form
    {
        private Point viTriList = new Point();
        private DataProcesser dtBase = new DataProcesser();
        private List<DataRow> listALLPhieuThue;
        int vitri = 0;
        int trangHienTai = 1;
        int soPhanTu;

        public FormDatPhong()
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
        private void FormDatPhong_Load(object sender, EventArgs e)
        {   
            txtSearch.Enabled = false;
            dgvCacPhongDat.RowTemplate.Height += 15;
            string sqlPhongThue = String.Format("SELECT tPhong.MaPhong, tPhong.MaLoai, TenKhachHang, DATEDIFF(day, NgayDenDuKien, NgayDiDuKien) AS SoNgay, NgayDenDuKien, NgayDiDuKien, tPhieuDat.MaPhieuDat " +
                "FROM tPhong " +
                "inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
                "LEFT JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                "LEFT JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                "LEFT JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                "LEFT JOIN tKhachHang  ON tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                "WHERE '{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien  AND MaPhieuThue Is NULL " +
                "Order by tPhong.MaPhong", DateTime.Today.ToString("yyyy-MM-dd"));

            DataTable dtPhongThue = dtBase.ReadData(sqlPhongThue);
            List<DataRow> listPhongThueDon = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "1").OrderBy(row => row["MaPhong"]).ToList();
            List<DataRow> listPhongThueDoi = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "2").OrderBy(row => row["MaPhong"]).ToList();
            List<DataRow> listPhongThueGD = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "3").OrderBy(row => row["MaPhong"]).ToList();


            HienlblLoai("Phòng đơn", new Point(50, 0));
            HienListPhong(listPhongThueDon, new Point(5, 30));

            ////Phòng Đôi          
            HienlblLoai("Phòng đôi", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongThueDoi, new Point(5, viTriList.Y + 50));

            ////Phòng Gia đình          
            HienlblLoai("Phòng gia đình", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongThueGD, new Point(5, viTriList.Y + 50));

            dgvDatPhong.RowTemplate.Height += 15;
            DataGridViewImageColumn imageColumn_detail = new DataGridViewImageColumn();
            imageColumn_detail.Image = Image.FromFile(Application.StartupPath + "\\" + "detail.png");
            imageColumn_detail.HeaderText = "Chi Tiết";
            dgvDatPhong.Columns.Add(imageColumn_detail);
            dgvDatPhong.AllowUserToAddRows = false;
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            UC_DatPhong ucDatPhong = new UC_DatPhong(this);
            ucDatPhong.Location = new Point(70, 55);
            this.Controls.Add(ucDatPhong);
            ucDatPhong.BringToFront();
        }

        private void HienlblLoai(string tenLoai, Point vitri)
        {
            Label lblLoaiPhong = new Label();
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Text = tenLoai;
            lblLoaiPhong.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold);
            lblLoaiPhong.ForeColor = Color.FromArgb(7, 161, 124);
            lblLoaiPhong.BackColor = Color.White;
            lblLoaiPhong.Location = vitri;
            pListPhong.Controls.Add(lblLoaiPhong);
        }


        private void HienListPhong(List<DataRow> listPhong, Point vitri)
        {
            int soDong = (listPhong.Count + (3 - 1)) / 3;
            int khoangCach = 20;// Khoảng cách giữa các phần tử
            int chieuDai = (240 + khoangCach) * 3; // Kích thước tổng thể theo chiều ngang
            int chieuRong = (130 + khoangCach) * soDong; // Kích thước tổng thể theo chiều dọc
            FlowLayoutPanel flpPhongDon = new FlowLayoutPanel();
            flpPhongDon.Size = new Size(chieuDai, chieuRong);
            flpPhongDon.Location = vitri;
            viTriList = new Point(30, vitri.Y + chieuRong);
            foreach (var item in listPhong)
            {
                PanelPhongThue test = new PanelPhongThue(item["MaPhong"].ToString(), item["TenKhachHang"].ToString(), item["SoNgay"].ToString(), item["MaLoai"].ToString(), item["NgayDenDuKien"].ToString(), item["NgayDiDuKien"].ToString(), item["MaPhieuDat"].ToString(), this);
                test.Margin = new Padding(10);
                flpPhongDon.Controls.Add(test);
            }
            pListPhong.Controls.Add(flpPhongDon);
        }

        public void DienThongtin(string maPhieuDat)
        {
            string sqlThongTin = String.Format("select MaPhieuDat, NgayDenDuKien,NgayDiDuKien, TenKhachHang from tPhieuDat inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang where MaPhieuDat = '{0}'", maPhieuDat);
            DataTable dtThongTin = dtBase.ReadData(sqlThongTin);
            lblTenKhachHang.Text = dtThongTin.Rows[0].Field<string>("TenKhachHang");
            lblMaPhieuDat.Text = dtThongTin.Rows[0].Field<string>("MaPhieuDat");
            lblNgayDen.Text = dtThongTin.Rows[0].Field<DateTime>("NgayDenDuKien").ToString("dd/MM/yyyy");
            lblNgayDi.Text = dtThongTin.Rows[0].Field<DateTime>("NgayDiDuKien").ToString("dd/MM/yyyy");
        }

        private void btnLSDatPhong_Click(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
            pLSPhieuDat.Visible = true;
            pListPhong.Visible = false;
            string sqlPhieuThue = String.Format("SELECT MaPhieuDat, TenKhachHang, NgayLap, TenNhanVien " +
                "from tPhieuDat " +
                "inner join tNhanVien on tPhieuDat.MaNhanVien = tNhanVien.MaNhanVien " +
                "inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                "order by NgayLap DESC");
            DataTable dtPhieuThue = dtBase.ReadData(sqlPhieuThue);

            listALLPhieuThue = dtPhieuThue.Select().ToList();
            int soTrang = (listALLPhieuThue.Count + (10 - 1)) / 10;

            lblSoTrang.Text = soTrang.ToString();

            lblTrangHienTai.Text = "1";

            List<DataRow> listPhanTrang = listALLPhieuThue.GetRange(vitri, 10);
            soPhanTu = listALLPhieuThue.Count();

            foreach (DataRow row in listPhanTrang)
            {
                dgvDatPhong.Rows.Add(row.ItemArray);
            }

        }

        private void loadDGV(int vitri)
        {
            //MessageBox.Show(list.Count.ToString());
            List<DataRow> listPhanTrang;
            dgvDatPhong.Rows.Clear();
            int soTrang = (listALLPhieuThue.Count + (10 - 1)) / 10;
            lblSoTrang.Text = soTrang.ToString();
            if (listALLPhieuThue.Count / 10 == 0)
            {
                listPhanTrang = listALLPhieuThue.GetRange(vitri, listALLPhieuThue.Count);
            }
            else
            {
                if (soPhanTu < 10)
                    listPhanTrang = listALLPhieuThue.GetRange(vitri, soPhanTu);
                else
                    listPhanTrang = listALLPhieuThue.GetRange(vitri, 10);
            }

            foreach (DataRow row in listPhanTrang)
            {
                dgvDatPhong.Rows.Add(row.ItemArray);
            }
        }

        private void btnTangTrang_Click(object sender, EventArgs e)
        {
            if (trangHienTai == (listALLPhieuThue.Count + (10 - 1)) / 10)
            {
                return;
            }

            trangHienTai += 1;
            lblTrangHienTai.Text = trangHienTai.ToString();
            vitri += 10;
            soPhanTu -= 10;
            loadDGV(vitri);

        }

        private void btnGiamTrang_Click(object sender, EventArgs e)
        {
            if (trangHienTai == 1)
            {
                return;
            }
            trangHienTai -= 1;
            lblTrangHienTai.Text = trangHienTai.ToString();
            vitri -= 10;
            soPhanTu += 10;
            loadDGV(vitri);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            vitri = 0;
            trangHienTai = 1;
            lblTrangHienTai.Text = trangHienTai.ToString();
            string sqlPhieuThue = String.Format("SELECT MaPhieuDat, TenKhachHang, NgayLap, TenNhanVien " +
                                                "from tPhieuDat " +
                                                "inner join tNhanVien on tPhieuDat.MaNhanVien = tNhanVien.MaNhanVien " +
                                                "inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                                                "where MaPhieuDat like '%{0}%' or TenKhachHang LIKE N'%{0}%' or NgayLap like '%{0}%' " +
                                                "order by NgayLap DESC", txtSearch.Text);

            DataTable dtPhieuThue = dtBase.ReadData(sqlPhieuThue);
            listALLPhieuThue = dtPhieuThue.Select().ToList();
            soPhanTu = listALLPhieuThue.Count();

            if (listALLPhieuThue.Count > 0)
            {
                loadDGV(vitri);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pLSPhieuDat.Visible = false;
            pListPhong.Visible = true;
            lblDSPhong.Visible = false;
            dgvCacPhongDat.Visible = false;
            txtSearch.Text = "";
            lblMaPhieuDat.Text = "";
            lblTenKhachHang.Text = "";
            lblNgayDen.Text = "";
            lblNgayDi.Text = "";
        }

        private void dgvDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblDSPhong.Visible = true;
            dgvCacPhongDat.Visible = true;
            string maPhieuDat = dgvDatPhong.CurrentRow.Cells["MaPhieuDat"].Value.ToString();

            string sqlThongTin = String.Format("select MaPhieuDat, NgayDenDuKien,NgayDiDuKien, TenKhachHang from tPhieuDat inner join tKhachHang on tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang where MaPhieuDat = '{0}'", maPhieuDat);
            DataTable dtChiTietPhong = dtBase.ReadData(sqlThongTin);
            if (dtChiTietPhong.Rows.Count > 0)
            {
                lblTenKhachHang.Text = dtChiTietPhong.Rows[0].Field<string>("TenKhachHang");
                lblMaPhieuDat.Text = dtChiTietPhong.Rows[0].Field<string>("MaPhieuDat");
                lblNgayDen.Text = (dtChiTietPhong.Rows[0].Field<DateTime>("NgayDenDuKien")).ToString("dd/MM/yyyy");
                lblNgayDi.Text = (dtChiTietPhong.Rows[0].Field<DateTime>("NgayDiDuKien")).ToString("dd/MM/yyyy");
            }
            string sqlCacPhong = String.Format("select MaPhong from tChiTietPhongDat Where MaPhieuDat = '{0}'", maPhieuDat);
            DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);
            dgvCacPhongDat.DataSource = dtCacPhong;
        }

        public void loadPListPhong()
        {
            txtSearch.Enabled = false;
            pLSPhieuDat.Visible = false;
            pListPhong.Visible = true;
            pListPhong.Controls.Clear();
            string sqlPhongThue = String.Format("SELECT tPhong.MaPhong, tPhong.MaLoai, TenKhachHang, DATEDIFF(day, NgayDenDuKien, NgayDiDuKien) AS SoNgay, NgayDenDuKien, NgayDiDuKien, tPhieuDat.MaPhieuDat " +
                "FROM tPhong " +
                "inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
                "LEFT JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                "LEFT JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                "LEFT JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                "LEFT JOIN tKhachHang  ON tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                "WHERE '{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien  AND MaPhieuThue Is NULL " +
                "Order by tPhong.MaPhong", DateTime.Today.ToString("yyyy-MM-dd"));

            DataTable dtPhongThue = dtBase.ReadData(sqlPhongThue);
            List<DataRow> listPhongThueDon = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "1").OrderBy(row => row["MaPhong"]).ToList();
            List<DataRow> listPhongThueDoi = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "2").OrderBy(row => row["MaPhong"]).ToList();
            List<DataRow> listPhongThueGD = dtPhongThue.Select().ToList().Where(row => row["MaLoai"].ToString() == "3").OrderBy(row => row["MaPhong"]).ToList();


            HienlblLoai("Phòng đơn", new Point(50, 0));
            HienListPhong(listPhongThueDon, new Point(5, 30));

            ////Phòng Đôi          
            HienlblLoai("Phòng đôi", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongThueDoi, new Point(5, viTriList.Y + 50));

            ////Phòng Gia đình          
            HienlblLoai("Phòng gia đình", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongThueGD, new Point(5, viTriList.Y + 50));

        }

    }
}
