using QuanLyKhachSan.Classes;
using QuanLyKhachSan.DangNhap;
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
    public partial class FormQuanLyPhong : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        public FormQuanLyPhong()
        {
            InitializeComponent();
        }

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {      

            dgvCacPhong.RowTemplate.Height += 15;
            dgvLoaiPhong.RowTemplate.Height += 15;
            pChinhSuaPhong.Visible = false;
            string sqlCacPhong = String.Format("select MaPhong, TenLoaiPhong, DonGiaPhong from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai");
            DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);
            dgvCacPhong.DataSource = dtCacPhong;
            dgvCacPhong.AllowUserToAddRows = false;

            string sqlCacLoaiPhong = String.Format("Select * from tLoaiPhong");
            DataTable dtCacLoaiPhong = dtBase.ReadData(sqlCacLoaiPhong);
            dgvLoaiPhong.DataSource = dtCacLoaiPhong;
            dgvLoaiPhong.AllowUserToAddRows = false;

            cbLoai.ValueMember = dtCacLoaiPhong.Columns["MaLoai"].ToString();
            cbLoai.DisplayMember = dtCacLoaiPhong.Columns["TenLoaiPhong"].ToString();
            cbLoai.DataSource = dtCacLoaiPhong;

            //2 image sửa và xóa vào phong
            DataGridViewImageColumn imageColumn_Edit = new DataGridViewImageColumn();
            imageColumn_Edit.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Edit.HeaderText = "Sửa";
            imageColumn_Edit.Name = "Sua";
            dgvCacPhong.Columns.Add(imageColumn_Edit);
            dgvCacPhong.Columns["Sua"].Width = 80;

            DataGridViewImageColumn imageColumn_Remove = new DataGridViewImageColumn();
            imageColumn_Remove.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove.HeaderText = "Xóa";
            imageColumn_Remove.Name = "Xoa";
            dgvCacPhong.Columns.Add(imageColumn_Remove);
            dgvCacPhong.Columns["Xoa"].Width = 80;


            // 2 image sửa và xóa vào loaiphong
            DataGridViewImageColumn imageColumn_Edit2 = new DataGridViewImageColumn();
            imageColumn_Edit2.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Edit2.HeaderText = "Sửa";
            imageColumn_Edit2.Name = "Sua";
            dgvLoaiPhong.Columns.Add(imageColumn_Edit2);
            dgvLoaiPhong.Columns["Sua"].Width = 50;

            DataGridViewImageColumn imageColumn_Remove2 = new DataGridViewImageColumn();
            imageColumn_Remove2.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove2.HeaderText = "Xóa";
            imageColumn_Remove2.Name = "Xoa";
            dgvLoaiPhong.Columns.Add(imageColumn_Remove2);
            dgvLoaiPhong.Columns["Xoa"].Width = 50;

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

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            UC_LoaiPhong ucThemLoaiPhong = new UC_LoaiPhong(this);
            ucThemLoaiPhong.Location = new Point(365, 95);
            this.Controls.Add(ucThemLoaiPhong);
            ucThemLoaiPhong.BringToFront();
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            UC_ThemPhong ucThemPhong = new UC_ThemPhong(this);
            ucThemPhong.Location = new Point(365, 95);
            this.Controls.Add(ucThemPhong);
            ucThemPhong.BringToFront();
        }

        private void dgvCacPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCacPhong.Columns[e.ColumnIndex].HeaderText == "Sửa")
            {
                pChinhSuaPhong.Visible = true;
                txtMaPhong.Text = dgvCacPhong.CurrentRow.Cells["MaPhong"].Value.ToString();
                cbLoai.Text = dgvCacPhong.CurrentRow.Cells["TenLoaiPhong"].Value.ToString();
                txtGia.Text = dgvCacPhong.CurrentRow.Cells["DonGiaPhong"].Value.ToString();
            }
            if (dgvCacPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string sqlXoaPhong = String.Format("Delete from tPhong where MaPhong = '{0}'", txtMaPhong.Text = dgvCacPhong.CurrentRow.Cells["MaPhong"].Value.ToString());
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phòng này?", "TB", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.ChangeData(sqlXoaPhong);
                }
                loadDGVPhong();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlUpdatePhong = String.Format("Update tPhong " +
                                                  "Set MaPhong = '{0}', MaLoai = '{1}', DonGiaPhong = {2} " +
                                                  "Where MaPhong = '{0}' ", txtMaPhong.Text, cbLoai.SelectedValue, int.Parse(txtGia.Text));
            dtBase.ChangeData(sqlUpdatePhong);
            MessageBox.Show("Cập nhật thành công");
            pChinhSuaPhong.Visible = false;
            loadDGVPhong();
        }

        public void loadDGVPhong()
        {
            string sqlCacPhong = String.Format("select MaPhong, TenLoaiPhong, DonGiaPhong from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai");
            DataTable dtCacPhong = dtBase.ReadData(sqlCacPhong);
            dgvCacPhong.DataSource = dtCacPhong;
        }

        public void loadDGVLoaiPhong()
        {
            string sqlCacLoaiPhong = String.Format("Select * from tLoaiPhong");
            DataTable dtCacLoaiPhong = dtBase.ReadData(sqlCacLoaiPhong);
            dgvLoaiPhong.DataSource = dtCacLoaiPhong;
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                loadDGVPhong();
                return;
            }
            string sqlTimKiem = String.Format("select MaPhong, TenLoaiPhong, DonGiaPhong " +
                                              "from tPhong inner join tLoaiPhong on tPhong.MaLoai = tLoaiPhong.MaLoai " +
                                              "where MaPhong like '%{0}%' or TenLoaiPhong like N'%{0}%' or DonGiaPhong like '%{0}%' ", txtSearch.Text);
            DataTable dtCacPhongTK = dtBase.ReadData(sqlTimKiem);
            dgvCacPhong.DataSource = dtCacPhongTK;

        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string sqlXoaLoaiPhong = String.Format("Delete from tLoaiPhong where MaLoai = '{0}'",dgvLoaiPhong.CurrentRow.Cells["MaLoai"].Value.ToString());
                if (MessageBox.Show("Bạn chắc chắn muốn xóa loại phòng này?", "TB", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.ChangeData(sqlXoaLoaiPhong);
                }
                loadDGVLoaiPhong();
            }
        }
    }
}
