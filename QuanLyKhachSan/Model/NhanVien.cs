using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class NhanVien
    {
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string cCCD { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string ngaySinh { get; set; }
        public string nameAnh { get; set; }
        public string chucVu { get; set; }
        public int luong { get; set; }

        public NhanVien(string maNhanVien, string tenNhanVien, string cCCD, string gioiTinh, string diaChi, string dienThoai, string ngaySinh, string nameAnh, string chucVu, int luong)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.cCCD = cCCD;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.ngaySinh = ngaySinh;
            this.nameAnh = nameAnh;
            this.chucVu = chucVu;
            this.luong = luong;
        }
        public NhanVien()
        {

        }
    }
}
