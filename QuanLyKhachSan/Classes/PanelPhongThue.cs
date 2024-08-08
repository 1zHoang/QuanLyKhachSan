using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using QuanLyKhachSan.Home;
using QuanLyKhachSan.User_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace QuanLyKhachSan.Classes
{
    public class PanelPhongThue : Guna2Panel
    {
        public PanelPhongThue(string tenPhong, string tenKhachHang, string soNgay, string maLoai, string ngayDenDuKien, string NgayDiDuKien, string maPhieuDat, FormDatPhong that)
        {
            Color mau = Color.FromArgb(153, 153, 255);

            //Text = name;
            Font = new Font("Segoe UI", 15f);
            Size = new Size(240, 130);
            FillColor = mau;
            ForeColor = Color.Black;
            BorderRadius = 15;

            //Tên Phòng
            Label txtPhong = new Label();
            txtPhong.Text = tenPhong;
            txtPhong.BackColor = mau;
            txtPhong.ForeColor = Color.White;
            txtPhong.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            txtPhong.Location = new Point(10, 10);
            this.Controls.Add(txtPhong);

            //Trạng thái phòng
            Label txtTrangThai = new Label();
            txtTrangThai.Text = "Phòng đặt";
            txtTrangThai.AutoSize = true;
            txtTrangThai.BackColor = mau;
            txtTrangThai.ForeColor = Color.White;
            txtTrangThai.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
            txtTrangThai.Location = new Point(140, 10);
            this.Controls.Add(txtTrangThai);

            //Tên Khách hàng hoặc trạng thái
            Label txtName = new Label();
            txtName.Text = tenKhachHang;
            txtName.AutoSize = true;
            txtName.BackColor = mau;
            txtName.ForeColor = Color.White;
            txtName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            txtName.Location = new Point(63, 60);
            this.Controls.Add(txtName);

            //Icon
            Label txtIcon = new Label();
            txtIcon.Size = new Size(50, 50);
            txtIcon.BackColor = mau;
            txtIcon.ForeColor = Color.White;
            txtIcon.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold);
            txtIcon.Location = new Point(10, 40);
            if (maLoai.Equals("1"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "user.png");
            else if (maLoai.Equals("2"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "people.png");
            else if (maLoai.Equals("3"))
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "group.png");
            else
                txtIcon.Image = Image.FromFile(Application.StartupPath + "\\" + "mark.png");
            this.Controls.Add(txtIcon);

            //Tạo lớp
            Guna2Panel a1 = new Guna2Panel();
            a1.Size = new Size(240, 28);
            a1.FillColor = Color.Gainsboro;
            a1.BorderRadius = 15;
            a1.Location = new Point(0, 103);
            a1.CustomizableEdges = new CustomizableEdges(true, true, false, false);

            Label text = new Label();
            text.Text = soNgay + " ngày";
            text.Font = new Font("Microsoft Sans Serif", 10f);
            text.BackColor = Color.Gainsboro;
            text.Location = new Point(19, 3);
            a1.Controls.Add(text);
            text.BringToFront();

            this.Controls.Add(a1);
            Click += (sender, e) =>
            {
                that.DienThongtin(maPhieuDat);
            };
        }
    }
}
