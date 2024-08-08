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
    public partial class UC_LoaiPhong : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormQuanLyPhong that;
        public UC_LoaiPhong(FormQuanLyPhong that)
        {
            this.that = that;
            InitializeComponent();
        }
        public UC_LoaiPhong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlThemLoaiPhong = String.Format("Insert into tLoaiPhong " +
                                               "Values('{0}',N'{1}')", txtMaLoaiPhong.Text, txtTenLoaiPhong.Text);
            dtBase.ChangeData(sqlThemLoaiPhong);

            MessageBox.Show("Thêm loại phòng thành công");
            that.loadDGVLoaiPhong();
        }
    }
}
