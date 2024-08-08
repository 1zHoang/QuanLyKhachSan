using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public static class ListDanhMucTheoQuyen
       {
        public static List<DanhMuc> ListDanhMuc(int cap)
        {
            List<DanhMuc>  list = new List<DanhMuc>();
            if(cap == 1)
            {
                list.Add(new DanhMuc("Trang chủ", "FormTrangChu", "home32px.png"));
                list.Add(new DanhMuc("Phòng", "FormDanhSachPhong", "homeMenu.png"));
                list.Add(new DanhMuc("Đặt phòng", "FormDatPhong", "QLroom.png"));
                list.Add(new DanhMuc("Hóa đơn", "FormHoaDon", "billing.png"));
                list.Add(new DanhMuc("QL khách hàng", "FormQuanLyKhachHang", "client.png"));
                list.Add(new DanhMuc("QL phòng", "FormQuanLyPhong", "smart-home.png"));
                list.Add(new DanhMuc("QL dịch vụ", "FormQuanLyDichVu", "desk-bell.png"));
                list.Add(new DanhMuc("QL tài khoản", "FormQuanLyTaiKhoan", "add-user.png"));
                list.Add(new DanhMuc("QL nhân viên", "FormQuanLyNhanVien", "staff.png"));
                list.Add(new DanhMuc("Thống kê", "FormThongKe", "analysis.png"));
                return list;
            }
            else
            {
                list.Add(new DanhMuc("Trang chủ", "FormTrangChu", "home32px.png"));
                list.Add(new DanhMuc("Phòng", "FormDanhSachPhong", "homeMenu.png"));
                list.Add(new DanhMuc("Đặt phòng", "FormDatPhong", "QLroom.png"));
                list.Add(new DanhMuc("Hóa đơn", "FormHoaDon", "billing.png"));
                list.Add(new DanhMuc("QL khách hàng", "FormQuanLyKhachHang", "client.png"));
                return list;
            }                         
        }
    }
}
