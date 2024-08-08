using QuanLyKhachSan.Classes;
using QuanLyKhachSan.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.User_Controls
{
    public partial class UC_ChiTietPhong : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private string namePhong;
        private string tenKhachHang;
        private string ngayDat;
        private string soNgayThue;
        private string trangThai;
        private string maPhieuThue;
        private string maPhieuDat;
        private string donGia;
        private string cCCD;
        private string maKhachHang;
        private int tongTienDichVu;
        private string tenLoai;
        private FormDanhSachPhong that = new FormDanhSachPhong();
        public UC_ChiTietPhong(string nameP, string tenKhachHang, string NgayDat, string soNgayThue, string trangThai, string maPhieuThue, string maPhieuDat, string donGia, string cCCD, string maKhachHang, string tenLoai, FormDanhSachPhong that)
        {
            InitializeComponent();
            namePhong = nameP;
            this.tenKhachHang = tenKhachHang;
            this.ngayDat = NgayDat;
            this.soNgayThue = soNgayThue;
            this.trangThai = trangThai;
            this.maPhieuThue = maPhieuThue;
            this.maPhieuDat = maPhieuDat;
            this.donGia = donGia;
            this.cCCD = cCCD;
            this.maKhachHang = maKhachHang;
            this.tenLoai = tenLoai;
            this.that = that;

        }

        private void UC_ChiTietPhong_Load(object sender, EventArgs e)
        {
            dgvDichVu.RowTemplate.Height += 12;
            lblNamePhong.Text = "Phòng " + namePhong;
            lblTenKhachHang.Text = tenKhachHang;
            lblNgayDat.Text = ngayDat;
            lblTrangThai.Text = trangThai;
            if (!soNgayThue.Equals(""))
                lblSoNgayThue.Text = soNgayThue + "ngày";
            else
                lblSoNgayThue.Text = "";

            string sqlDichVu = String.Format("Select TenSanPham, SoLuong, ThanhTien " +
                                            "from tSanPham inner join tChiTietSanPham on tSanPham.MaSanPham = tChiTietSanPham.MaSanPham " +
                                            "Where  MaPhieuThue = '{0}' ", maPhieuThue);

            if (trangThai == "Phòng trống")
            {
                btnThemDichVu.Visible = false;
                btnNhanPhong.Visible = false;
                btnThanhToan.Visible = false;
                btnHuyPhong.Visible = false;
            }
            if (trangThai == "Phòng đặt")
            {
                btnThanhToan.Visible = false;
                btnDatPhong.Visible = false;
                btnThemDichVu.Visible = false;
            }
            if (trangThai == "Phòng thuê")
            {
                btnHuyPhong.Visible = false;
                btnDatPhong.Visible = false;
                btnNhanPhong.Visible = false;
                DataTable dtDichVu = dtBase.ReadData(sqlDichVu);
                dgvDichVu.DataSource = dtDichVu;
                dgvDichVu.AllowUserToAddRows = false;
                tongTienDichVu = 0;
                foreach (DataGridViewRow row in dgvDichVu.Rows)
                {
                    string thanhTien = row.Cells["ThanhTien"].Value.ToString();
                    tongTienDichVu += int.Parse(thanhTien);
                }

                lblTongTienDichVu.Text = tongTienDichVu.ToString("N0") + " VND";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            that.LoadSauKhiThoatUC_ChiTiet();
            this.Visible = false;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maHoaDon = "HD" + Functions.SinhMaTuDong(cCCD);
            string maNhanVien = User.maNhanVien;
            int tongTienThue = int.Parse(soNgayThue) * int.Parse(donGia);
            string ngayLapHoaDon = DateTime.Now.ToString("yyyy-MM-dd");

            //khi thanh toán 1 phiếu thuê sẽ cập nhật các trường dưới
            string sqlCNTrangThaiPhong = string.Format("Update tPhieuThue " +
                                                          "set ThoiGianCheckOut = '{0}' , ThanhToan = 'Đã thanh toán', TongTien = {3}" +
                                                          "where MaPhieuDat = '{1}' and MaPhieuThue = '{2}'", ngayLapHoaDon, maPhieuDat, maPhieuThue, tongTienThue);
            dtBase.ChangeData(sqlCNTrangThaiPhong);


            //đoạn này là kiểm tra xem trong còn phòng nào cùng phiếu đặt nữa không
            string sqlKTPhieuDat = string.Format("select * from tPhieuThue where MaPhieuDat = '{0}' AND ThanhToan IS NULL", maPhieuDat);
            DataTable dtPD = dtBase.ReadData(sqlKTPhieuDat);

            //nếu còn phòng trong cùng 1 đợt đặt thì sẽ không chưa tạo hóa đơn
            if(dtPD.Rows.Count > 0)
            {
                //MessageBox.Show("hahaha");
            }
            else // nếu đã hết phòng trong cùng 1 đợt đặt thì sẽ tạo hóa đơn thanh toán
            {
                int TongTien = 0;
                string sqlCacPhieuThue = String.Format("select * from tPhieuThue WHERE MaPhieuDat= '{0}'", maPhieuDat);
                DataTable dtCacPhieuThue = dtBase.ReadData(sqlCacPhieuThue);
                //MessageBox.Show(sqlCacPhieuThue);
                //MessageBox.Show(namePhong);
                //MessageBox.Show(dtCacPhieuThue.Rows.Count.ToString());
                // Tính tổng tiền của từng phiếu thuê
                foreach (DataRow row in dtCacPhieuThue.Rows)
                {
                    TongTien += int.Parse(row["TongTien"].ToString());
                    string sqlTienDichVu = String.Format("Select ThanhTien from tChiTietSanPham where MaPhieuThue = '{0}'", row["MaPhieuThue"].ToString());
                    DataTable dtTienDV = dtBase.ReadData(sqlTienDichVu);                 
                    if (dtTienDV.Rows.Count > 0)
                    {
                        int tienDichVu = 0;
                        MessageBox.Show(dtTienDV.Rows.Count.ToString());
                        foreach (DataRow item in dtTienDV.Rows)
                        {
                            tienDichVu += int.Parse(item["ThanhTien"].ToString());                 
                        }
                        
                        TongTien += tienDichVu;
                        //MessageBox.Show(tienDichVu.ToString());
                        //MessageBox.Show(TongTien.ToString());
                    }
                }        
                string sqlHoaDon = string.Format("INSERT INTO tHoaDon (MaHoaDon, MaNhanVien, MaPhieuDat, TongTien, NgayLapHoaDon) " +
                                     "VALUES ('{0}', '{1}', '{2}', {3}, '{4}')", maHoaDon, maNhanVien, maPhieuDat, TongTien, ngayLapHoaDon);
                dtBase.ChangeData(sqlHoaDon);
                UC_HoaDon uC_HoaDon = new UC_HoaDon("",maPhieuThue);
                uC_HoaDon.Location = new Point(250, 5);
                Parent.Controls.Add(uC_HoaDon);
                uC_HoaDon.BringToFront();
                //MessageBox.Show("Thêm hóa đơn thành công");
            }
            that.LoadSauKhiThoatUC_ChiTiet();
            this.Visible = false;
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            UC_DatPhongNhanh ucDatPhong = new UC_DatPhongNhanh(that, namePhong, tenLoai);
            ucDatPhong.Location = new Point(150, 65);
            that.Controls.Add(ucDatPhong);
            ucDatPhong.BringToFront();
            this.Visible = false;
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Phòng thuê";
            btnHuyPhong.Visible = false;
            string maPhieuThue = "PT" + Functions.SinhMaTuDong(cCCD);
            string ngayLapPT = DateTime.Now.ToString("yyyy-MM-dd");

            //MessageBox.Show(maPhieuThue + " " + this.maPhieuDat + " " + namePhong + " " + ngayLapPT + " " + ngayLapPT);
            string sqlThemPhieuThue = String.Format("Insert into tPhieuThue(MaPhieuThue, MaPhieuDat, MaPhong, ThoiGianLapPT, ThoiGianCheckIn) " +
                                                    "Values('{0}', '{1}', '{2}', '{3}', '{4}')", maPhieuThue, maPhieuDat, namePhong, ngayLapPT, ngayLapPT);
            dtBase.ChangeData(sqlThemPhieuThue);
            //MessageBox.Show(maPhieuThue);
            this.maPhieuThue = maPhieuThue;
            loadDGV();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            Uc_ThemDichVu uc_ThemDichVu = new Uc_ThemDichVu(maPhieuThue, this);
            uc_ThemDichVu.Location = new Point(230, 76);
            Parent.Controls.Add(uc_ThemDichVu);
            uc_ThemDichVu.BringToFront();
        }

        private void loadDGV()
        {
            string sqlDichVu = String.Format("Select TenSanPham, SoLuong, ThanhTien " +
                                           "from tSanPham inner join tChiTietSanPham on tSanPham.MaSanPham = tChiTietSanPham.MaSanPham " +
                                           "Where  MaPhieuThue = '{0}' ", maPhieuThue);
            btnNhanPhong.Visible = false;
            btnThanhToan.Visible = true;
            btnThemDichVu.Visible = true;
            DataTable dtDichVu = dtBase.ReadData(sqlDichVu);
            dgvDichVu.DataSource = dtDichVu;
            dgvDichVu.AllowUserToAddRows = false;
            tongTienDichVu = 0;
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                string thanhTien = row.Cells["ThanhTien"].Value.ToString();
                tongTienDichVu += int.Parse(thanhTien);
            }
            lblTongTienDichVu.Text = tongTienDichVu.ToString("N0") + " VND";
        }

        public void LoadData()
        {
            string sqlDichVu = String.Format("Select TenSanPham, SoLuong, ThanhTien " +
                                            "from tSanPham inner join tChiTietSanPham on tSanPham.MaSanPham = tChiTietSanPham.MaSanPham " +
                                            "Where  MaPhieuThue = '{0}' ", maPhieuThue);
            DataTable dtDichVu = dtBase.ReadData(sqlDichVu);
            dgvDichVu.DataSource = dtDichVu;
            dgvDichVu.AllowUserToAddRows = false;
            int tongTien = 0;
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                string thanhTien = row.Cells["ThanhTien"].Value.ToString();
                tongTien += int.Parse(thanhTien);
            }
            lblTongTienDichVu.Text = tongTien.ToString("N0") + " VND";
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn hủy phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlHuyChiTietPhong = String.Format("delete from tChiTietPhongDat where MaPhieuDat = '{0}'", maPhieuDat);
                string sqlHuyPhongDat = String.Format("delete from tPhieuDat where MaPhieuDat = '{0}'", maPhieuDat);
                dtBase.ChangeData(sqlHuyChiTietPhong);
                dtBase.ChangeData(sqlHuyPhongDat);
                that.LoadSauKhiThoatUC_ChiTiet();
                this.Visible = false;
            }
        }
    }
}
