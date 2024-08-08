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
    public partial class UC_LoaiDV : UserControl
    {
        private DataProcesser dtBase = new DataProcesser();
        private FormQuanLyDichVu that;
        public UC_LoaiDV(FormQuanLyDichVu that)
        {
            this.that = that;
            InitializeComponent();
        }
        public UC_LoaiDV()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlThemDichVu = String.Format("Insert into tDichVu " +
                                            "Values('{0}',N'{1}')", txtMaLoai.Text, txtTenLoai.Text);
            dtBase.ChangeData(sqlThemDichVu);

            MessageBox.Show("Thêm loại phòng thành công");
            that.loadDGVDichVu();
        }
    }
}
