using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Classes
{
    public class Functions
    {
        public static string SinhMaTuDong(string cCCD)
        {
            string ma = "";
            ma += DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            ma += cCCD.Substring(0, 3);
            Random random = new Random();
            int randomNumber = random.Next(100, 1000);
            ma += randomNumber.ToString();
            return ma;
        }

        public static string MaHoaMatKhau(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();

            }
        }
    }
}
