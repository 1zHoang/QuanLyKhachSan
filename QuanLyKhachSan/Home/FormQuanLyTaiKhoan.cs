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
    public partial class FormQuanLyTaiKhoan : Form
    {
        private DataProcesser dtBase = new DataProcesser();
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            UC_TaiKhoan ucTaiKhoan = new UC_TaiKhoan(this, "thêm");
            ucTaiKhoan.Location = new Point(365, 75);
            this.Controls.Add(ucTaiKhoan);
            ucTaiKhoan.BringToFront();
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

        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            string sqlTaiKhoan = String.Format("Select tUser.MaNhanVien, TenNhanVien, Username, Quyen " +
                                               "from tUser inner join tNhanVien on tUser.MaNhanVien = tNhanVien.MaNhanVien");
            DataTable dtTaiKhoan = dtBase.ReadData(sqlTaiKhoan);
            dgvTaiKhoan.RowTemplate.Height += 15;
            dgvTaiKhoan.DataSource = dtTaiKhoan;
            dgvTaiKhoan.AllowUserToAddRows = false;

            DataGridViewImageColumn imageColumn_Edit = new DataGridViewImageColumn();
            imageColumn_Edit.Image = Image.FromFile(Application.StartupPath + "\\" + "edit.png");
            imageColumn_Edit.HeaderText = "Sửa";
            imageColumn_Edit.Name = "Sua";
            dgvTaiKhoan.Columns.Add(imageColumn_Edit);
            dgvTaiKhoan.Columns["Sua"].Width = 80;

            DataGridViewImageColumn imageColumn_Remove = new DataGridViewImageColumn();
            imageColumn_Remove.Image = Image.FromFile(Application.StartupPath + "\\" + "trash.png");
            imageColumn_Remove.HeaderText = "Xóa";
            imageColumn_Remove.Name = "Xoa";
            dgvTaiKhoan.Columns.Add(imageColumn_Remove);
            dgvTaiKhoan.Columns["Xoa"].Width = 80;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sqlTaiKhoan = String.Format("Select tUser.MaNhanVien, TenNhanVien, Username, Quyen " +
                                               "from tUser inner join tNhanVien on tUser.MaNhanVien = tNhanVien.MaNhanVien " +
                                               "where tUser.MaNhanVien like '%{0}%' or TenNhanVien like '%{0}%' or Username like '%{0}%' or Quyen like '%{0}%'", txtSearch.Text);
            DataTable dtTaiKhoan = dtBase.ReadData(sqlTaiKhoan);
            dgvTaiKhoan.DataSource = dtTaiKhoan;
        }

        public void loadDGVTaiKhoan()
        {
            string sqlTaiKhoan = String.Format("Select tUser.MaNhanVien, TenNhanVien, Username, Quyen " +
                                              "from tUser inner join tNhanVien on tUser.MaNhanVien = tNhanVien.MaNhanVien");
            DataTable dtTaiKhoan = dtBase.ReadData(sqlTaiKhoan);
            dgvTaiKhoan.DataSource = dtTaiKhoan;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvTaiKhoan.Columns[e.ColumnIndex].HeaderText == "Sửa")
            {
                string maNhanVien = dgvTaiKhoan.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                string taiKhoan = dgvTaiKhoan.CurrentRow.Cells["Username"].Value.ToString();
                string quyen = dgvTaiKhoan.CurrentRow.Cells["Quyen"].Value.ToString();
                UC_TaiKhoan uC_TaiKhoan = new UC_TaiKhoan(maNhanVien, taiKhoan, quyen, "Sửa", this);
                uC_TaiKhoan.Location = new Point(365, 75);
                this.Controls.Add(uC_TaiKhoan);
                uC_TaiKhoan.BringToFront();

            }
        }
    }
}
