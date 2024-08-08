using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;
using QuanLyKhachSan.User_Controls;
using System.Data;
using System.Drawing.Text;
using QuanLyKhachSan.Home;

namespace QuanLyKhachSan.Classes
{
    public class PanelPhong :Guna2Panel
    {
        public PanelPhong(string tenPhong, string trangThai, string tenKhachHang, string soNgay, string maLoai, string ngayDuKienDen, string maPhieuThue, string maPhieuDat, string donGia, string cCCD, string maKhachHang, string tenLoai, FormDanhSachPhong that) {
            Color mau = Color.FromArgb(30, 219, 175);
            //trống 30, 219, 175
            // đặt 153, 153,255
            // thuê 160,160,160
            if (trangThai.Equals("Phòng đặt"))
                mau = Color.FromArgb(153, 153, 255);
            if (trangThai.Equals("Phòng thuê"))
                mau = Color.FromArgb(160, 160, 160);

            //Text = name;
            Font = new Font("Segoe UI", 15f);
            Size = new Size(265,155);                  
            FillColor = mau;
            ForeColor = Color.Black;
            BorderRadius = 15;

            //Tên Phòng
            Label txtPhong = new Label();
            txtPhong.Text = tenPhong;
            txtPhong.BackColor = mau;
            txtPhong.ForeColor = Color.White;
            txtPhong.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            txtPhong.Location = new Point(10,10);
            this.Controls.Add(txtPhong);

            //Trạng thái phòng
            Label txtTrangThai = new Label();
            txtTrangThai.Text = trangThai;
            txtTrangThai.BackColor = mau;
            txtTrangThai.ForeColor = Color.White;
            txtTrangThai.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
            txtTrangThai.Location = new Point(150, 10);
            this.Controls.Add(txtTrangThai);

            //Tên Khách hàng hoặc trạng thái
            Label txtName = new Label();
            if(!tenKhachHang.Equals(""))
                txtName.Text = tenKhachHang;
            else
                txtName.Text = "Phòng trống";            
            txtName.AutoSize = true;
            txtName.BackColor = mau;
            txtName.ForeColor = Color.White;
            txtName.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold);
            txtName.Location = new Point(63, 50);
            this.Controls.Add(txtName);

            //Icon
            Label txtIcon = new Label();
            txtIcon.Size = new Size(50, 50);
            txtIcon.BackColor = mau;
            txtIcon.ForeColor = Color.White;
            txtIcon.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold);
            txtIcon.Location = new Point(10, 40);
            if(maLoai.Equals("1") && !trangThai.Equals("Phòng trống"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "user.png");
            else if(maLoai.Equals("2") && !trangThai.Equals("Phòng trống"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "people.png");
            else if(maLoai.Equals("3") && !trangThai.Equals("Phòng trống"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "group.png");
            else
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "mark.png");
            this.Controls.Add(txtIcon);

            //Tạo lớp
            Guna2Panel a1 = new Guna2Panel();
            a1.Size = new Size(265, 31);
            a1.FillColor = Color.Gainsboro;
            a1.BorderRadius = 15;
            a1.Location = new Point(0, 125);

            Guna2Panel a2 = new Guna2Panel();
            a2.Size = new Size(265, 22);
            a2.FillColor = Color.Gainsboro;
            a2.Location = new Point(0, 119);
            Label text = new Label();
            if (!soNgay.Equals(""))
                text.Text = soNgay + " ngày";
            else
                text.Text = "Trống";
            text.Font = new Font("Microsoft Sans Serif", 11f);
            text.BackColor = Color.Gainsboro;
            text.Location = new Point(19, 4);
            a2.Controls.Add(text);

            this.Controls.Add(a2);
            this.Controls.Add(a1);

            Click += (sender, e) =>
            {
                UC_ChiTietPhong ucChiTietPhong = new UC_ChiTietPhong(tenPhong, tenKhachHang, ngayDuKienDen, soNgay, trangThai, maPhieuThue, maPhieuDat, donGia, cCCD, maKhachHang, tenLoai, that);
                ucChiTietPhong.Location = new Point(240, 75);
                that.Controls.Add(ucChiTietPhong);
                ucChiTietPhong.BringToFront();
            };
        }
    }
}
