using QuanLyKhachSan.Classes;
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

namespace QuanLyKhachSan
{
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
        }
        private void Test2_Load(object sender, EventArgs e)
        {

            // Tạo một đối tượng Chart
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Tạo một đối tượng Series để chứa dữ liệu
            Series series = new Series("Series 1");
            series.ChartType = SeriesChartType.Pie;

            // Thêm dữ liệu vào Series
            series.Points.AddXY("A", 30);
            series.Points.AddXY("B", 20);
            series.Points.AddXY("C", 15);
            series.Points.AddXY("D", 35);

            // Thêm Series vào Chart
            chart.Series.Add(series);

            // Thêm Chart vào Controls của Form
            this.Controls.Add(chart);
        }

        private void HienListPhong(int soPhanTu, Point vitri)
        {
            //int soDong = (soPhanTu + (4 - 1)) / 4;
            //int khoangCach = 20;// Khoảng cách giữa các phần tử
            //int chieuDai = (220 + khoangCach) * 4; // Kích thước tổng thể theo chiều ngang
            //int chieuRong = (135 + khoangCach) * soDong; // Kích thước tổng thể theo chiều dọc
            //FlowLayoutPanel flpPhongDon = new FlowLayoutPanel();
            //flpPhongDon.Size = new Size(chieuDai, chieuRong);
            //flpPhongDon.Location = vitri;
            //viTriList = new Point(30, vitri.Y + chieuRong); 
            //for (int i = 0; i < soPhanTu; i++)
            //{
            //    PanelPhong test = new PanelPhong(this.ParentForm);
            //    test.Margin = new Padding(10);
            //    flpPhongDon.Controls.Add(test);
            //}
            //pListPhong.Controls.Add(flpPhongDon);
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
    }
}
