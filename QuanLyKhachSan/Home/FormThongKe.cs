using System.Drawing;
using QuanLyKhachSan.Classes;
using QuanLyKhachSan.User_Controls;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKhachSan.Home
{
    public partial class FormThongKe : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        public FormThongKe()
        {
            InitializeComponent();
        }
        private void FormThongKe_Load(object sender, EventArgs e)
        {
            lblThang.Text = DateTime.Now.Month.ToString();
            lblNam.Text = DateTime.Now.Year.ToString();
            int doanhThuTienPhong = 0;
            int doanhThuTienDV = 0;
            string sqlTongTienPhieuThue = String.Format("Select MaPhieuThue,Tongtien from tPhieuThue where MONTH(ThoiGianLapPT) = {0} and YEAR(ThoiGianLapPT) = {1}", int.Parse(lblThang.Text), int.Parse(lblNam.Text));
            DataTable dtTTPhieuThue = dtBase.ReadData(sqlTongTienPhieuThue);
            if(dtTTPhieuThue.Rows.Count > 0)
            {
                foreach(DataRow row in dtTTPhieuThue.Rows)
                {
                    int? tongTien = row.Field<int?>("TongTien");
                    if (tongTien != null)
                    {
                        doanhThuTienPhong += tongTien.Value;
                    }
                    string sqlTienDichVu = String.Format("Select ThanhTien from tChiTietSanPham where MaPhieuThue = '{0}'", row["MaPhieuThue"].ToString());
                    DataTable dtTienDV = dtBase.ReadData(sqlTienDichVu);
                    if (dtTienDV.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtTienDV.Rows)
                        {
                            int tien = int.Parse(item["ThanhTien"].ToString());
                            doanhThuTienDV += int.Parse(item["ThanhTien"].ToString());
                        }                                    
                    }                 
                }
                lblDTPhong.Text = doanhThuTienPhong.ToString("N0") + " VND";
                lblDTDichVu.Text = doanhThuTienDV.ToString("N0") + " VND";
                lblTongDT.Text = (doanhThuTienPhong + doanhThuTienDV).ToString("N0") + "VND";
            }

            loadBieuDoThang(int.Parse(lblThang.Text));
            loadBieuDoNam(int.Parse(lblNam.Text));
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

        private void lblTangThang_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(lblThang.Text);
            if (thang == 12)
            {
                thang = 1;
                lblThang.Text = thang.ToString();
                lblNam.Text = (int.Parse(lblNam.Text) + 1).ToString();
                loadBieuDoNam(int.Parse(lblNam.Text));
                loadBieuDoThang(thang);
                return;
            }
            lblThang.Text = (thang + 1).ToString();
            loadBieuDoThang(thang + 1);
        }

        private void lblGiamThang_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(lblThang.Text);
            if(thang == 1)
            {
                thang = 12;
                lblThang.Text = thang.ToString();
                lblNam.Text = (int.Parse(lblNam.Text) - 1).ToString();
                loadBieuDoNam(int.Parse(lblNam.Text));
                loadBieuDoThang(thang);
                return;
            }
            lblThang.Text = (thang - 1).ToString();
            loadBieuDoThang(thang - 1);
        }

        private void lblTangNam_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(lblNam.Text);
            lblNam.Text = (nam+1).ToString();
            loadBieuDoNam(nam + 1);
        }

        private void lblGiamNam_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(lblNam.Text);
            lblNam.Text = (nam-1).ToString();
            loadBieuDoNam(nam - 1);
        }


        private void loadBieuDoNam(int nam)
        {
            bdNam.Series.Clear();
            //Thêm dữ liệu vào biểu đồ đường
            Series lineTienPhong = new Series("Doanh thu phòng");
            Series lineTienDV = new Series("Doanh thu dịch vụ");
            Series lineTongTien = new Series("Tổng doanh thu");

            lineTienPhong.ChartType = SeriesChartType.Spline;
            lineTienDV.ChartType = SeriesChartType.Spline;
            lineTongTien.ChartType = SeriesChartType.Spline;
            // Thêm dữ liệu vào Series
            for (int i = 1; i <= 12; i++)
            {
                int tienPhong = 0;
                int tienDV = 0;
                int tienTong = 0;
                string sqlTienTheoThang = String.Format("Select MaPhieuThue,Tongtien from tPhieuThue where MONTH(ThoiGianLapPT) = {0} and YEAR(ThoiGianLapPT) = {1}", i, nam);
                DataTable dtTienTheoThang = dtBase.ReadData(sqlTienTheoThang);
                if (dtTienTheoThang.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTienTheoThang.Rows)
                    {
                        int? tongTien = row.Field<int?>("TongTien");
                        if (tongTien != null)
                        {
                            tienPhong += tongTien.Value;
                        }
                        string sqlTienDichVu = String.Format("Select ThanhTien from tChiTietSanPham where MaPhieuThue = '{0}'", row["MaPhieuThue"].ToString());
                        DataTable dtTienDV = dtBase.ReadData(sqlTienDichVu);
                        if (dtTienDV.Rows.Count > 0)
                        {
                            foreach (DataRow item in dtTienDV.Rows)
                            {
                                int tien = int.Parse(item["ThanhTien"].ToString());
                                tienDV += int.Parse(item["ThanhTien"].ToString());
                            }
                        }
                    }
                }
                tienTong = tienPhong + tienDV;
                lineTienPhong.Points.AddXY(i, tienPhong);
                lineTienDV.Points.AddXY(i, tienDV);
                lineTongTien.Points.AddXY(i, tienTong);
            }
            bdNam.Series.Add(lineTienPhong);
            bdNam.Series.Add(lineTienDV);
            bdNam.Series.Add(lineTongTien);
            //bdNam.Series[0].IsVisibleInLegend = false;
            bdNam.Legends[0].Docking = Docking.Bottom;
        }

        private void loadBieuDoThang(int thang)
        {
            bdThang.Series.Clear();
            int doanhThuTienPhong = 0;
            int doanhThuTienDV = 0;
            string sqlTongTienPhieuThue = String.Format("Select MaPhieuThue,Tongtien from tPhieuThue where MONTH(ThoiGianLapPT) = {0} and YEAR(ThoiGianLapPT) = {1}", thang, int.Parse(lblNam.Text));
            DataTable dtTTPhieuThue = dtBase.ReadData(sqlTongTienPhieuThue);
            if (dtTTPhieuThue.Rows.Count > 0)
            {
                foreach (DataRow row in dtTTPhieuThue.Rows)
                {
                    int? tongTien = row.Field<int?>("TongTien");
                    if (tongTien != null)
                    {
                        doanhThuTienPhong += tongTien.Value;
                    }
                    string sqlTienDichVu = String.Format("Select ThanhTien from tChiTietSanPham where MaPhieuThue = '{0}'", row["MaPhieuThue"].ToString());
                    DataTable dtTienDV = dtBase.ReadData(sqlTienDichVu);
                    if (dtTienDV.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtTienDV.Rows)
                        {
                            int tien = int.Parse(item["ThanhTien"].ToString());
                            doanhThuTienDV += int.Parse(item["ThanhTien"].ToString());
                        }
                    }
                }
                lblDTPhong.Text = doanhThuTienPhong.ToString("N0") + " VND";
                lblDTDichVu.Text = doanhThuTienDV.ToString("N0") + " VND";
                lblTongDT.Text = (doanhThuTienPhong + doanhThuTienDV).ToString("N0") + "VND";
            }

            //Thêm dữ liệu vào biểu đồ tròn
            Series series = new Series("Doanh thu theo tháng");
            series.ChartType = SeriesChartType.Pie;

            // Thêm dữ liệu vào Series
            series.Points.AddXY("Phòng", doanhThuTienPhong);
            series.Points.AddXY("Dịch vụ", doanhThuTienDV);
            series.Points[0].Color = Color.Yellow;
            series.Points[1].Color = Color.Blue;

            foreach (DataPoint point in series.Points)
            {
                point.Label = "#VALX: #PERCENT";
            }
            // Thêm Series vào Chart

            bdThang.Series.Add(series);
            bdThang.Series[0].IsVisibleInLegend = false;
            bdThang.Legends[0].Docking = Docking.Bottom;
        }

        private void pDoanhThuPhong_Click(object sender, EventArgs e)
        {
            UC_DoanhThu ucDoanhThu = new UC_DoanhThu("Phòng", int.Parse(lblThang.Text), int.Parse(lblNam.Text));
            ucDoanhThu.Location = new Point(206, 185);
            this.Controls.Add(ucDoanhThu);
            ucDoanhThu.BringToFront();
        }

        private void pDoanhThuDV_Click(object sender, EventArgs e)
        {
            UC_DoanhThu ucDoanhThu = new UC_DoanhThu("Dịch vụ", int.Parse(lblThang.Text), int.Parse(lblNam.Text));
            ucDoanhThu.Location = new Point(206, 185);
            this.Controls.Add(ucDoanhThu);
            ucDoanhThu.BringToFront();
        }
    }
}
