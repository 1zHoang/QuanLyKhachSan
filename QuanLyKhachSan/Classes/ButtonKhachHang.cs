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
    public class ButtonKhachHang : Guna2Button
    {
        public ButtonKhachHang(string tenKhachHang, string ngaySinh, UserControl that)
        {
            //xet Size
            Size = new Size(260, 35);
            Text = tenKhachHang + "  " + ngaySinh;
            Font = new Font("Microsoft Sans Serif", 10f);
            //BackColor = Color.White;
            FillColor = Color.White;
            ForeColor = Color.Black;
            TextAlign = HorizontalAlignment.Left;
            //BorderColor = Color.Black;
            this.MouseEnter += PanelKhachHang_MouseEnter;
            // Sự kiện MouseLeave
            this.MouseLeave += PanelKhachHang_MouseLeave;


            Click += (sender, e) =>
            {
                if (that.GetType() == typeof(UC_DatPhongNhanh))
                {
                    ((UC_DatPhongNhanh)that).dienThongTinKhachHang(tenKhachHang, ngaySinh);
                }
                else if(that.GetType() == typeof(UC_DatPhong))
{
                    ((UC_DatPhong)that).dienThongTinKhachHang(tenKhachHang, ngaySinh);
                }

            };
        }
        private void PanelKhachHang_MouseEnter(object sender, EventArgs e)
        {
            //lblTenKhachHang.BackColor = Color.LightGray;
            this.BackColor = Color.LightGray;
        }
        private void PanelKhachHang_MouseLeave(object sender, EventArgs e)
        {
            //lblTenKhachHang.BackColor = Color.White;
            this.BackColor = Color.White;
        }
    }
}
