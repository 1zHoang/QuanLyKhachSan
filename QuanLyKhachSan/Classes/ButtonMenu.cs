using Guna.UI2.WinForms;
using QuanLyKhachSan.Home;
using QuanLyKhachSan.User_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKhachSan.Classes
{
    public class ButtonMenu : Guna2Button
    {

        public ButtonMenu(string name, string formName, string nameImage, Form that)
        {
            Text = name;
            Font = new Font("Segoe UI", 15f);
            Size = new Size(275, 45);
            FillColor = Color.White;
            ForeColor = Color.Black;
            TextAlign = HorizontalAlignment.Left;
            TextOffset = new Point(20, 0);
            Image = Image.FromFile(Application.StartupPath + "\\" + nameImage);
            ImageAlign = HorizontalAlignment.Left;
            string URL = "QuanLyKhachSan.Home."+ formName;
            Click += (sender, e) =>
            {
                Type formType = Type.GetType(URL);
                if (formType != null)
                {
                    Form form = (Form)Activator.CreateInstance(formType);
                    form.Show();
                    that.Visible = false;
                }
            };
        }
    }
}
