using Guna.UI2.WinForms;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKhachSan.Home
{
    public partial class FormDanhSachPhong : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        private List<DataRow> listPhongDon = new List<DataRow>();
        private List<DataRow> listPhongDoi = new List<DataRow>();
        private List<DataRow> listPhongGD = new List<DataRow>();
        public FormDanhSachPhong()
        {
            InitializeComponent();
        }
        private Point viTriList = new Point();
        private void FormDanhSachPhong_Load(object sender, EventArgs e)
        {
            clearPanel();
            dateTime.Value = DateTime.Today;
            string sqlPhongThuevaDat = String.Format("SELECT tPhong.MaPhong, tPhong.MaLoai, TenLoaiPhong, tPhieuDat.MaKhachHang, CCCD, TenKhachHang, DATEDIFF(day, NgayDenDuKien, NgayDiDuKien) AS SoNgay, NgayDenDuKien, MaPhieuThue, tPhieuDat.MaPhieuDat, DonGiaPhong, " +
                                                        "CASE " +
                                                            "WHEN ThoiGianCheckOut IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng Trống' " +
                                                            "WHEN ThoiGianCheckIn IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng thuê' " +
                                                            "WHEN tChiTietPhongDat.MaPhong IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng đặt' " +
                                                            "ELSE N'Phòng trống' " +
                                                        "END AS TrangThai " +
                                                        "FROM tPhong " +
                                                            "INNER JOIN tLoaiPhong ON tPhong.MaLoai = tLoaiPhong.MaLoai " +
                                                            "LEFT JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                                                            "LEFT JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                                                            "LEFT JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                                                            "LEFT JOIN tKhachHang  ON tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                                                        "WHERE '{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien AND ThanhToan IS NULL", dateTime.Value.ToString("yyyy-MM-dd"));
            DataTable dtPhongThuevaDat = dtBase.ReadData(sqlPhongThuevaDat);

            string sqlCacPhong = String.Format("Select MaPhong, tPhong.MaLoai, TenLoaiPhong " +
                                                "from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai");
            DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);

             List<DataRow> listPhongThuevaDat = dtPhongThuevaDat.Select().ToList();

             List<DataRow> ListPhong = dtCacPhong.Select().ToList();

            foreach (var item in ListPhong)
            {
                var maPhong = item.Field<string>("MaPhong");
                var maLoai = item.Field<string>("MaLoai");
                var tenLoai = item.Field<string>("TenLoaiPhong");
                var matchingRow = listPhongThuevaDat.FirstOrDefault(row => row.Field<string>("MaPhong") == maPhong);

                if (matchingRow == null)
                {
                    // Tạo một DataRow mới với MaPhong và TrangThai
                    var newRow = dtPhongThuevaDat.NewRow();
                    newRow["MaPhong"] = maPhong;
                    newRow["MaLoai"] = maLoai; // Hoặc gán giá trị null tùy thuộc vào kiểu dữ liệu của cột
                    newRow["TenLoaiPhong"] = tenLoai;
                    newRow["TenKhachHang"] = DBNull.Value;
                    newRow["MaKhachHang"] = DBNull.Value;
                    newRow["CCCD"] = DBNull.Value;
                    newRow["SoNgay"] = DBNull.Value;
                    newRow["NgayDenDuKien"] = DBNull.Value;
                    newRow["MaPhieuThue"] = DBNull.Value;
                    newRow["DonGiaPhong"] = DBNull.Value;
                    newRow["TrangThai"] = "Phòng trống";

                    // Thêm DataRow mới vào listPhongThuevaDat
                    listPhongThuevaDat.Add(newRow);
                }
            }
            //MessageBox.Show(listPhongThuevaDat.Count().ToString());
            listPhongDon = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "1")).OrderBy(row => row["MaPhong"]).ToList();
            listPhongDoi = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "2")).OrderBy(row => row["MaPhong"]).ToList();
            listPhongGD = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "3")).OrderBy(row => row["MaPhong"]).ToList();

            //Phòng đơn
            HienlblLoai("Phòng đơn", new Point(50, 17));
            HienListPhong(listPhongDon, new Point(5, 50));

            ////Phòng Đôi          
            HienlblLoai("Phòng đôi", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongDoi, new Point(5, viTriList.Y + 50));

            ////Phòng Gia đình          
            HienlblLoai("Phòng gia đình", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongGD, new Point(5, viTriList.Y + 50));
        }
        private void HienListPhong(List<DataRow> listPhong, Point vitri)
        {
            int soDong = (listPhong.Count + (4 - 1)) / 4;
            int khoangCach = 20;// Khoảng cách giữa các phần tử
            int chieuDai = (265 + khoangCach) * 4; // Kích thước tổng thể theo chiều ngang
            int chieuRong = (155 + khoangCach) * soDong; // Kích thước tổng thể theo chiều dọc
            FlowLayoutPanel flpPhongDon = new FlowLayoutPanel();
            flpPhongDon.Size = new Size(chieuDai, chieuRong);
            flpPhongDon.Location = vitri;
            viTriList = new Point(30, vitri.Y + chieuRong);
            foreach (var item in listPhong)
            {
                PanelPhong test = new PanelPhong(item["MaPhong"].ToString(), item["TrangThai"].ToString(), item["TenKhachHang"].ToString(), item["SoNgay"].ToString(), item["MaLoai"].ToString(), item["NgayDenDuKien"].ToString(), item["MaPhieuThue"].ToString(), item["MaPhieuDat"].ToString(), item["DonGiaPhong"].ToString(), item["CCCD"].ToString(), item["MaKhachHang"].ToString(), item["TenLoaiPhong"].ToString(), this);
                test.Margin = new Padding(10);
                flpPhongDon.Controls.Add(test);
            }
            pListPhong.Controls.Add(flpPhongDon);
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

        private void clearPanel()
        {
            pListPhong.Controls.Clear();
        }
       

        private void loadListPhong(string sqlTinhTrang, string sqlLoaiPhong, string date)
        {
            string sqlPhongThuevaDat = String.Format("SELECT tPhong.MaPhong, tPhong.MaLoai, TenLoaiPhong, tPhieuDat.MaKhachHang, CCCD, TenKhachHang, DATEDIFF(day, NgayDenDuKien, NgayDiDuKien) AS SoNgay, NgayDenDuKien, MaPhieuThue, tPhieuDat.MaPhieuDat, DonGiaPhong, " +
                                                         "CASE " +
                                                             "WHEN ThoiGianCheckOut IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng Trống' " +
                                                             "WHEN ThoiGianCheckIn IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng thuê' " +
                                                             "WHEN tChiTietPhongDat.MaPhong IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng đặt' " +
                                                             "ELSE N'Phòng trống' " +
                                                         "END AS TrangThai " +
                                                         "FROM tPhong " +
                                                             "INNER JOIN tLoaiPhong ON tPhong.MaLoai = tLoaiPhong.MaLoai " +
                                                             "LEFT JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                                                             "LEFT JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                                                             "LEFT JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                                                             "LEFT JOIN tKhachHang  ON tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                                                         "WHERE '{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien AND ThanhToan IS NULL {1}", date, sqlLoaiPhong);

            DataTable dtPhongThuevaDat = dtBase.ReadData(sqlPhongThuevaDat);
            List<DataRow> listPhongThuevaDat = dtPhongThuevaDat.Select().ToList();
            if(!sqlLoaiPhong.Contains("TenKhachHang"))
            {
                string sqlCacPhong = String.Format("Select MaPhong, tPhong.MaLoai, TenLoaiPhong " +
                                                 "from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
                                                 "WHERE 1 = 1 {0}", sqlLoaiPhong);
                DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);


                List<DataRow> ListPhong = dtCacPhong.Select().ToList();
                foreach (var item in ListPhong)
                {
                    var maPhong = item.Field<string>("MaPhong");
                    var maLoai = item.Field<string>("MaLoai");
                    var tenLoai = item.Field<string>("TenLoaiPhong");
                    var matchingRow = listPhongThuevaDat.FirstOrDefault(row => row.Field<string>("MaPhong") == maPhong);

                    if (matchingRow == null)
                    {
                        // Tạo một DataRow mới với MaPhong và TrangThai
                        var newRow = dtPhongThuevaDat.NewRow();
                        newRow["MaPhong"] = maPhong;
                        newRow["MaLoai"] = maLoai; // Hoặc gán giá trị null tùy thuộc vào kiểu dữ liệu của cột
                        newRow["TenLoaiPhong"] = tenLoai;
                        newRow["TenKhachHang"] = DBNull.Value;
                        newRow["MaKhachHang"] = DBNull.Value;
                        newRow["CCCD"] = DBNull.Value;
                        newRow["SoNgay"] = DBNull.Value;
                        newRow["NgayDenDuKien"] = DBNull.Value;
                        newRow["MaPhieuThue"] = DBNull.Value;
                        newRow["DonGiaPhong"] = DBNull.Value;
                        newRow["TrangThai"] = "Phòng trống";

                        // Thêm DataRow mới vào listPhongThuevaDat
                        listPhongThuevaDat.Add(newRow);
                    }
                }
            }
            
            if (sqlTinhTrang == "") // nếu tìm tất cả phòng thì sqlTinhTrang là ""
            {
                listPhongDon = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "1")).OrderBy(row => row["MaPhong"]).ToList();
                listPhongDoi = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "2")).OrderBy(row => row["MaPhong"]).ToList();
                listPhongGD = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "3")).OrderBy(row => row["MaPhong"]).ToList();
            }
            else
            {
                listPhongDon = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "1" && row["TrangThai"].ToString() == sqlTinhTrang)).OrderBy(row => row["MaPhong"]).ToList();
                listPhongDoi = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "2" && row["TrangThai"].ToString() == sqlTinhTrang)).OrderBy(row => row["MaPhong"]).ToList();
                listPhongGD = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "3" && row["TrangThai"].ToString() == sqlTinhTrang)).OrderBy(row => row["MaPhong"]).ToList();
            }

        }

        private void loadPanel()
        {
            clearPanel();
            HienlblLoai("Phòng đơn", new Point(50, 17));
            HienListPhong(listPhongDon, new Point(5, 50));

            ////Phòng Đôi          
            HienlblLoai("Phòng đôi", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongDoi, new Point(5, viTriList.Y + 50));

            ////Phòng Gia đình          
            HienlblLoai("Phòng gia đình", new Point(50, viTriList.Y + 20));
            HienListPhong(listPhongGD, new Point(5, viTriList.Y + 50));
        }
        private void CheckedLoaiPhong(object sender, EventArgs e)
        {
            string date = dateTime.Value.ToString("yyyy-MM-dd");
            RadioButton rdo = (RadioButton)sender;
            string sqlLoaiPhong = "";

            if (rdo.Text.Equals("Phòng đơn"))
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '1'";
            }
            else if (rdo.Text.Equals("Phòng đôi"))
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '2'";
            }
            else if (rdo.Text.Equals("Phòng gia đình"))
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '3'";
            }
            else if (rdo.Text.Equals("Tất cả phòng"))
            {
                sqlLoaiPhong = "";
            }

            if (rdoAllTrangThai.Checked)
            {
                loadListPhong("", sqlLoaiPhong, date);
            }
            else if (rdoPhongTrong.Checked)
            {
                loadListPhong("Phòng trống", sqlLoaiPhong, date);
            }
            else if (rdoPhongThue.Checked)
            {
                loadListPhong("Phòng thuê", sqlLoaiPhong, date);
            }
            else if (rdoPhongDat.Checked)
            {
                loadListPhong("Phòng đặt", sqlLoaiPhong, date);
            }

            loadPanel();
        }

        private void CheckedTrangThai(object sender, EventArgs e)
        {
            string date = dateTime.Value.ToString("yyyy-MM-dd");
            RadioButton rdo = (RadioButton)sender;
            string sqlTrangThai = "";
            string sqlLoaiPhong = "";

            if (rdo.Text.Equals("Phòng trống"))
            {
                sqlTrangThai = "Phòng trống";
            }
            else if (rdo.Text.Equals("Phòng đã đặt"))
            {
                sqlTrangThai = "Phòng đặt";
            }
            else if (rdo.Text.Equals("Phòng đang thuê"))
            {
                sqlTrangThai = "Phòng thuê";
            }
            else if (rdo.Text.Equals("Tất cả phòng"))
            {
                sqlTrangThai = "";           
            }

            if (rdoAllLoaiPhong.Checked)
            {
                loadListPhong(sqlTrangThai, "", date);
            }
            else if (rdoDon.Checked)
            {
                sqlLoaiPhong += " AND tPhong.MaLoai = '1'";
                loadListPhong(sqlTrangThai, sqlLoaiPhong, date);
            }
            else if (rdoDoi.Checked)
            {
                sqlLoaiPhong += " AND tPhong.MaLoai = '2'";
                loadListPhong(sqlTrangThai, sqlLoaiPhong, date);
            }
            else if (rdoGiaDinh.Checked)
            {
                sqlLoaiPhong += " AND tPhong.MaLoai = '3'";
                loadListPhong(sqlTrangThai, sqlLoaiPhong, date);
            }
            else if (rdoAllLoaiPhong.Checked)
            {
                sqlLoaiPhong = "";  // cho nó là rỗng luôn vì cả rdoAllLoaiPhong nó luôn là rỗng rồi
                loadListPhong(sqlTrangThai, sqlLoaiPhong, date);
            }
            loadPanel();
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            string sqlTrangThai = "";
            string sqlLoaiPhong = "";

            if (!string.IsNullOrEmpty(txtTenPhong.Text))
            {
                string sqlTimPhong = String.Format(" AND tPhong.MaPhong = '{0}'", txtTenPhong.Text);
                loadListPhong(sqlTimPhong, sqlTimPhong, dateTime.Value.ToString("yyyy-MM-dd"));
                loadPanel();
                return;
            }

            if (rdoDon.Checked)
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '1'";
            }
            else if (rdoDoi.Checked)
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '2'";
            }
            else if (rdoGiaDinh.Checked)
            {
                sqlLoaiPhong = " AND tPhong.MaLoai = '3'";
            }
            else if (rdoAllLoaiPhong.Checked)
            {
                sqlLoaiPhong = "";
            }

            if (rdoPhongTrong.Checked)
            {
                sqlTrangThai = "Phòng trống";
            }
            else if (rdoPhongDat.Checked)
            {
                sqlTrangThai = "Phòng đặt";
            }
            else if (rdoPhongThue.Checked)
            {
                sqlTrangThai = "Phòng thuê";
            }
            else if (rdoAllTrangThai.Checked)
            {
                sqlTrangThai = "";
            }
            loadListPhong(sqlTrangThai, sqlLoaiPhong, dateTime.Value.ToString("yyyy-MM-dd"));
            loadPanel();
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            string date = dateTime.Value.ToString("yyyy-MM-dd");
            string sqlTimPhong = String.Format(" AND TenKhachHang like N'%{0}%'", txtTenPhong.Text);
            loadListPhong("", sqlTimPhong, date);
            loadPanel();
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

            public void LoadSauKhiThoatUC_ChiTiet()
            {
                clearPanel();
                dateTime.Value = DateTime.Today;
                string sqlPhongThuevaDat = String.Format("SELECT tPhong.MaPhong, tPhong.MaLoai, TenLoaiPhong, tPhieuDat.MaKhachHang, CCCD, TenKhachHang, DATEDIFF(day, NgayDenDuKien, NgayDiDuKien) AS SoNgay, NgayDenDuKien, MaPhieuThue, tPhieuDat.MaPhieuDat, DonGiaPhong, " +
                                                            "CASE " +
                                                                "WHEN ThoiGianCheckOut IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng Trống' " +
                                                                "WHEN ThoiGianCheckIn IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng thuê' " +
                                                                "WHEN tChiTietPhongDat.MaPhong IS NOT NULL AND ('{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien) THEN N'Phòng đặt' " +
                                                                "ELSE N'Phòng trống' " +
                                                            "END AS TrangThai " +
                                                            "FROM tPhong " +
                                                                "INNER JOIN tLoaiPhong ON tPhong.MaLoai = tLoaiPhong.MaLoai "+
                                                                "LEFT JOIN tChiTietPhongDat ON tPhong.MaPhong = tChiTietPhongDat.MaPhong " +
                                                                "LEFT JOIN tPhieuDat  ON tChiTietPhongDat.MaPhieuDat = tPhieuDat.MaPhieuDat " +
                                                                "LEFT JOIN tPhieuThue  ON tPhong.MaPhong = tPhieuThue.MaPhong AND tPhieuDat.MaPhieuDat = tPhieuThue.MaPHieuDat " +
                                                                "LEFT JOIN tKhachHang  ON tPhieuDat.MaKhachHang = tKhachHang.MaKhachHang " +
                                                            "WHERE '{0}' BETWEEN NgayDenDuKien AND NgayDiDuKien AND ThanhToan IS NULL", dateTime.Value.ToString("yyyy-MM-dd"));
                DataTable dtPhongThuevaDat = dtBase.ReadData(sqlPhongThuevaDat);

            string sqlCacPhong = String.Format("Select MaPhong, tPhong.MaLoai, TenLoaiPhong " +
                                                "from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai");
            DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);

                List<DataRow> listPhongThuevaDat = dtPhongThuevaDat.Select().ToList();

                List<DataRow> ListPhong = dtCacPhong.Select().ToList();
            foreach (var item in ListPhong)
            {
                var maPhong = item.Field<string>("MaPhong");
                var maLoai = item.Field<string>("MaLoai");
                var tenLoai = item.Field<string>("TenLoaiPhong");
                var matchingRow = listPhongThuevaDat.FirstOrDefault(row => row.Field<string>("MaPhong") == maPhong);

                if (matchingRow == null)
                {
                    // Tạo một DataRow mới với MaPhong và TrangThai
                    var newRow = dtPhongThuevaDat.NewRow();
                    newRow["MaPhong"] = maPhong;
                    newRow["MaLoai"] = maLoai; // Hoặc gán giá trị null tùy thuộc vào kiểu dữ liệu của cột
                    newRow["TenLoaiPhong"] = tenLoai;
                    newRow["TenKhachHang"] = DBNull.Value;
                    newRow["MaKhachHang"] = DBNull.Value;
                    newRow["CCCD"] = DBNull.Value;
                    newRow["SoNgay"] = DBNull.Value;
                    newRow["NgayDenDuKien"] = DBNull.Value;
                    newRow["MaPhieuThue"] = DBNull.Value;
                    newRow["DonGiaPhong"] = DBNull.Value;
                    newRow["TrangThai"] = "Phòng trống";

                    // Thêm DataRow mới vào listPhongThuevaDat
                    listPhongThuevaDat.Add(newRow);
                }
            }
            //MessageBox.Show(listPhongThuevaDat.Count().ToString());
                listPhongDon = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "1")).OrderBy(row => row["MaPhong"]).ToList();
                listPhongDoi = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "2")).OrderBy(row => row["MaPhong"]).ToList();
                listPhongGD = listPhongThuevaDat.Where((row => row["MaLoai"].ToString() == "3")).OrderBy(row => row["MaPhong"]).ToList();

                //Phòng đơn
                HienlblLoai("Phòng đơn", new Point(50, 17));
                HienListPhong(listPhongDon, new Point(5, 50));

                ////Phòng Đôi          
                HienlblLoai("Phòng đôi", new Point(50, viTriList.Y + 20));
                HienListPhong(listPhongDoi, new Point(5, viTriList.Y + 50));

                ////Phòng Gia đình          
                HienlblLoai("Phòng gia đình", new Point(50, viTriList.Y + 20));
                HienListPhong(listPhongGD, new Point(5, viTriList.Y + 50));
            }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {
            if(txtTenPhong.Text == "")
            {
                FormDanhSachPhong_Load(sender, e);
            }
        }

        private void pListPhong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
