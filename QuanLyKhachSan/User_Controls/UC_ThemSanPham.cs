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
    public partial class UC_ThemSanPham : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormQuanLyDichVu that;
        public UC_ThemSanPham(FormQuanLyDichVu that)
        {
            this.that = that;
            InitializeComponent();
        }
        public UC_ThemSanPham()
        {
            InitializeComponent();
        }

        private void UC_DichVu_Load(object sender, EventArgs e)
        {
            string sqlDichVu = String.Format("Select * from tDichVu");
            DataTable dtDichVu = dtBase.ReadData(sqlDichVu);
            cbDichVu.ValueMember = dtDichVu.Columns["MaDichVu"].ToString();
            cbDichVu.DisplayMember = dtDichVu.Columns["TenDichVu"].ToString();
            cbDichVu.DataSource = dtDichVu;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlThemSanPham = String.Format("Insert into tSanPham " +
                                     "Values('{0}','{1}','{2}',{3})", txtMaSanPham.Text, cbDichVu.SelectedValue, txtTenSanPham.Text, int.Parse(txtGia.Text));
            dtBase.ChangeData(sqlThemSanPham);

            MessageBox.Show("Thêm phòng thành công");
            that.loadDGVSanPham();
        }

    }
}
