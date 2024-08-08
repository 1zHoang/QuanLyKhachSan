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
    public partial class UC_ThemPhong : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormQuanLyPhong that;
        public UC_ThemPhong(FormQuanLyPhong that)
        {
            this.that = that;
            InitializeComponent();
        }

        public UC_ThemPhong()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlThemPhong = String.Format("Insert into tPhong " +
                                                "Values('{0}','{1}','{2}')", txtMaPhong.Text, cbLoaiPhong.SelectedValue, txtGia.Text);
            dtBase.ChangeData(sqlThemPhong);

            MessageBox.Show("Thêm phòng thành công");
            that.loadDGVPhong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void UC_ThemPhong_Load(object sender, EventArgs e)
        {
            string sqlCacLoaiPhong = String.Format("Select * from tLoaiPhong");
            DataTable dtCacLoaiPhong = dtBase.ReadData(sqlCacLoaiPhong);
            cbLoaiPhong.ValueMember = dtCacLoaiPhong.Columns["MaLoai"].ToString();
            cbLoaiPhong.DisplayMember = dtCacLoaiPhong.Columns["TenLoaiPhong"].ToString();
            cbLoaiPhong.DataSource = dtCacLoaiPhong;
        }

    }
}
