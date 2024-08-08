using QuanLyKhachSan.Classes;
using QuanLyKhachSan.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Home
{
    public partial class FormQuanLyDichVu : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        public FormQuanLyDichVu()
        {
            InitializeComponent();
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

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            UC_ThemSanPham ucDichVu = new UC_ThemSanPham(this);
            ucDichVu.Location = new Point(365, 55);
            this.Controls.Add(ucDichVu);
            ucDichVu.BringToFront();
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            UC_LoaiDV ucLoaiDichVu = new UC_LoaiDV(this);
            ucLoaiDichVu.Location = new Point(365, 55);
            this.Controls.Add(ucLoaiDichVu);
            ucLoaiDichVu.BringToFront();
        }

        private void FormQuanLyDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.RowTemplate.Height += 15;
            dgvSanPham.RowTemplate.Height += 15;

            string sqlDinhVu = String.Format("select * from tDichVu");
            DataTable dtDichVu = dtBase.ReadData(sqlDinhVu);
            dgvDichVu.DataSource = dtDichVu;
            dgvDichVu.AllowUserToAddRows = false;

            cbDichVu.ValueMember = dtDichVu.Columns["MaDichVu"].ToString();
            cbDichVu.DisplayMember = dtDichVu.Columns["TenDichVu"].ToString();
            cbDichVu.DataSource = dtDichVu;


            string sqlSanPham = String.Format("select MaSanPham, TenDichVu, TenSanPham, DonGiaSP " +
                                              "from tSanPham inner join tDichVu on tSanPham.MaDichVu = tDichVu.MaDichVu");
            DataTable dtSanPham = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtSanPham;
            dgvSanPham.AllowUserToAddRows = false;


            // 2 ảnh vào sanpham
            DataGridViewImageColumn imageColumn_Edit = new DataGridViewImageColumn();
            imageColumn_Edit.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Edit.HeaderText = "Sửa";
            imageColumn_Edit.Name = "Sua";
            dgvSanPham.Columns.Add(imageColumn_Edit);
            dgvSanPham.Columns["Sua"].Width = 80;

            DataGridViewImageColumn imageColumn_Remove = new DataGridViewImageColumn();
            imageColumn_Remove.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove.HeaderText = "Xóa";
            imageColumn_Remove.Name = "Xoa";
            dgvSanPham.Columns.Add(imageColumn_Remove);
            dgvSanPham.Columns["Xoa"].Width = 80;


            //2 ảnh vào dịch vụ
            DataGridViewImageColumn imageColumn_Edit2 = new DataGridViewImageColumn();
            imageColumn_Edit2.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Edit2.HeaderText = "Sửa";
            imageColumn_Edit2.Name = "Sua";
            dgvDichVu.Columns.Add(imageColumn_Edit2);
            dgvDichVu.Columns["Sua"].Width = 50;

            DataGridViewImageColumn imageColumn_Remove2 = new DataGridViewImageColumn();
            imageColumn_Remove2.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove2.HeaderText = "Xóa";
            imageColumn_Remove2.Name = "Xoa";
            dgvDichVu.Columns.Add(imageColumn_Remove2);
            dgvDichVu.Columns["Xoa"].Width = 50;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].HeaderText == "Sửa")
            {
                pChinhSuaSP.Visible = true;
                txtMaSP.Text = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                cbDichVu.Text = dgvSanPham.CurrentRow.Cells["TenDichVu"].Value.ToString();
                txtTenSP.Text = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
                txtGia.Text = dgvSanPham.CurrentRow.Cells["DonGiaSP"].Value.ToString();
            }
            if (dgvSanPham.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string sqlXoaSanPham = String.Format("Delete from tSanPham where MaSanPham = '{0}'", dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString());
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phòng này?", "TB", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.ChangeData(sqlXoaSanPham);
                }
                loadDGVSanPham();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlUpdateSanPham = String.Format("Update tSanPham " +
                                                 "Set MaSanPham = '{0}', MaDichVu = '{1}', TenSanPham = '{2}', DonGiaSP = {3} " +
                                                 "Where MaSanPham = '{0}' ", txtMaSP.Text, cbDichVu.SelectedValue, txtTenSP.Text, int.Parse(txtGia.Text));
            dtBase.ChangeData(sqlUpdateSanPham);
            MessageBox.Show("Cập nhật thành công");
            pChinhSuaSP.Visible = false;
            loadDGVSanPham();
        }

        public void loadDGVSanPham()
        {
            string sqlSanPham = String.Format("select MaSanPham, TenDichVu, TenSanPham, DonGiaSP " +
                                             "from tSanPham inner join tDichVu on tSanPham.MaDichVu = tDichVu.MaDichVu");
            DataTable dtSanPham = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtSanPham;
        }
        public void loadDGVDichVu()
        {
            string sqlDinhVu = String.Format("select * from tDichVu");
            DataTable dtDichVu = dtBase.ReadData(sqlDinhVu);
            dgvDichVu.DataSource = dtDichVu;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                loadDGVSanPham();
                return;
            }
            string sqlSanPham = String.Format("select MaSanPham, TenDichVu, TenSanPham, DonGiaSP " +
                                              "from tSanPham inner join tDichVu on tSanPham.MaDichVu = tDichVu.MaDichVu " +
                                              "where MaSanPham like '%{0}%' or TenDichVu like N'%{0}%' or TenSanPham like N'%{0}%' or DonGiaSP like '%{0}%' ", txtSearch.Text);
            DataTable dtCacPhongTK = dtBase.ReadData(sqlSanPham);
            dgvSanPham.DataSource = dtCacPhongTK;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvSanPham.Columns[e.ColumnIndex].HeaderText == "Sửa")
            //{
            //    pChinhSuaSP.Visible = true;
            //    txtMaSP.Text = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            //    cbDichVu.Text = dgvSanPham.CurrentRow.Cells["TenDichVu"].Value.ToString();
            //    txtTenSP.Text = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            //    txtGia.Text = dgvSanPham.CurrentRow.Cells["DonGiaSP"].Value.ToString();
            //}
            if (dgvDichVu.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string sqlXoaDichVu = String.Format("Delete from tDichVu where MaDichVu = '{0}'", dgvDichVu.CurrentRow.Cells["MaDichVu"].Value.ToString());
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phòng này?", "TB", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.ChangeData(sqlXoaDichVu);
                }
                loadDGVDichVu();
            }
        }
    }
}
