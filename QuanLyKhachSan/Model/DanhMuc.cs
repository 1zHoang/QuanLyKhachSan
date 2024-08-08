using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class DanhMuc
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Form { get; set; } 

        public DanhMuc(string name, string form, string icon)
        {
            Name = name;
            Form = form;
            Icon = icon;
        }
    }
}
