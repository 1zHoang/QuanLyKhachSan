using QuanLyKhachSan.Classes;
using System;
using System.Collections;
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

namespace QuanLyKhachSan.User_Controls
{
    public partial class Uc_ThemDichVu : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private string maPhieuThue;
        private UC_ChiTietPhong that;

        public Uc_ThemDichVu()
        {
            InitializeComponent();
        }

        public Uc_ThemDichVu(string maPhieuThue, UC_ChiTietPhong that)
        {
            InitializeComponent();
            this.maPhieuThue = maPhieuThue;
            this.that = that;
        }

        private void Uc_ThemDichVu_Load(object sender, EventArgs e)
        {
            string sqlDichVu = String.Format("Select * from tDichVu");
            DataTable dtDV =  dtBase.ReadData(sqlDichVu);
            cbDichVu.ValueMember = dtDV.Columns["MaDichVu"].ToString();
            cbDichVu.DisplayMember = dtDV.Columns["TenDichVu"].ToString();
            cbDichVu.DataSource = dtDV;

            string sqlSanPham = String.Format("Select MaSanPham, TenSanPham, DonGiaSP from tSanPham WHERE MaDichVu = 'DV01'");
            DataTable dtSP = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtSP;
            dgvSanPham.RowTemplate.Height += 15; 

            DataGridViewImageColumn imageColumn_Add = new DataGridViewImageColumn();
            imageColumn_Add.Image = Image.FromFile(Application.StartupPath + "\\" + "plus.png");
            imageColumn_Add.HeaderText = "Thêm";
            dgvSanPham.Columns.Add(imageColumn_Add);          
            dgvSanPham.AllowUserToAddRows = false;

            DataGridViewImageColumn imageColumn_Delete = new DataGridViewImageColumn();
            imageColumn_Delete.Image = Image.FromFile(Application.StartupPath + "\\" + "remove.png");
            imageColumn_Delete.HeaderText = "Xóa";
            dgvDichVuChon.RowTemplate.Height += 15;
            dgvDichVuChon.Columns.Add(imageColumn_Delete);
            dgvDichVuChon.AllowUserToAddRows = false;
        }

        private void cbDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
            string sqlSanPham = String.Format("Select MaSanPham, TenSanPham, DonGiaSP from tSanPham WHERE MaDichVu = '{0}'", cbDichVu.SelectedValue);
            DataTable dtSP = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtSP;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sqlSanPham = String.Format("Select MaSanPham, TenSanPham, DonGiaSP from tSanPham WHERE TenSanPham  LIKE '%{0}%'", txtTimKiem.Text);
            DataTable dtSP = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtSP;
        }


        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].HeaderText == "Thêm")
            {
                string maSanPham = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                string tenSanPham = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
                string donGiaSP = dgvSanPham.CurrentRow.Cells["DonGiaSP"].Value.ToString();
                string soLuong = "1";
                string thanhTien = donGiaSP;
                dgvDichVuChon.Rows.Add(maSanPham,tenSanPham, soLuong, thanhTien);
            }
        }

        private void dgvDichVuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDichVuChon.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {              
                dgvDichVuChon.Rows.RemoveAt(dgvDichVuChon.CurrentRow.Index);
            }
        }

        private void dgvDichVuChon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDichVuChon.Columns[e.ColumnIndex].Name == "soLuong")
            {
                DataGridViewRow row = dgvDichVuChon.Rows[e.RowIndex];
                string tenSanPham = Convert.ToString(row.Cells["tenSanPham"].Value);
                DataGridViewRow foundRow = dgvSanPham.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(m => Convert.ToString(row.Cells["tenSanPham"].Value) == tenSanPham);

                int donGia = 0;
                if (foundRow != null)
                {
                    donGia = int.Parse( Convert.ToString(foundRow.Cells["donGiaSP"].Value));
                }

                DataGridViewCell soLuongCell = row.Cells["soLuong"];
                DataGridViewCell thanhTienCell = row.Cells["thanhTien"];

                if (soLuongCell.Value != null)
                {
                    int soLuong = Convert.ToInt32(soLuongCell.Value);
                    int tien = Convert.ToInt32(thanhTienCell.Value);

                    int thanhTien = soLuong * donGia;
                    thanhTienCell.Value = thanhTien.ToString();
                }
            }
        
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(maPhieuThue);
            foreach (DataGridViewRow row in dgvDichVuChon.Rows)
            {
                string maSanPham = row.Cells["maSanPham"].Value.ToString();
                int soLuong = int.Parse(row.Cells["soLuong"].Value.ToString());

                string sqlSanPham = String.Format("Select * from tChiTietSanPham Where MaPhieuThue = '{0}' AND MaSanPham = '{1}'", maPhieuThue, maSanPham);
                DataTable dt = dtBase.ReadData(sqlSanPham);
                if (dt.Rows.Count > 0)
                {
                    string sqlUpdate = String.Format("Update tChiTietSanPham set SoLuong = SoLuong + {0}  Where MaPhieuThue = '{1}' AND MaSanPham = '{2}' ", soLuong, maPhieuThue, maSanPham);
                    dtBase.ChangeData(sqlUpdate);
                    //MessageBox.Show("Thành Công");            
                }
                else
                {
                    string sqlInsert = String.Format("Insert into tChiTietSanPham(MaPhieuThue, MaSanPham, SoLuong) values ('{0}', '{1}', {2})", maPhieuThue, maSanPham, soLuong);
                    dtBase.ChangeData(sqlInsert);
                    //MessageBox.Show("Thành Công");
                }
            }
            MessageBox.Show("Thành Công");
            dgvDichVuChon.Rows.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           this.Visible = false;
            that.LoadData();
        }
    }
}
