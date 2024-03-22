using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace loginPage
{
    public partial class ThanhToan : Window
    {
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1;Integrated Security=True";
        public ThanhToan()
        {
            InitializeComponent();
        }

        // ---------------------------------   Ngọc làm phần này   ---------------------------------//
        private void xacnhanBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectstring);

            if (tenkhTxtBlock.Text != null && sdtkhTxtBlock.Text == null)
            {
                MessageBox.Show("Vui lòng điền sđt của khách hàng");
            }
            else if (sdtkhTxtBlock.Text != null && tenkhTxtBlock.Text == null)
            {
                MessageBox.Show("Vui lòng điền tên của khách hàng");
            }
            else if (tenkhTxtBlock.Text != null && sdtkhTxtBlock.Text != null)
            {
                try
                {
                    string tenKH = tenkhTxtBlock.Text;
                    string sdtKH = sdtkhTxtBlock.Text;
                    DateTime ngayAn = DateTime.Now;
                    double tongTien = 0;
                    foreach (FoodItem item in foodLV.Items)
                    {
                        tongTien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
                    }
                    int soLuongMon = 0;
                    foreach (FoodItem item in foodLV.Items)
                    {
                        soLuongMon += item.Qty;
                    }

                    conn.Open();

                    string insertString = @"
                 insert into HoaDon
                 (TenKH, SDTKH, NgayAn, SoLuongMon, TongTien)
                 values (@tenKH, @sdtKH, @ngayAn, @soLuongMon, @tongTien)";

                    SqlCommand cmd = new SqlCommand(insertString, conn);
                    cmd.Parameters.AddWithValue("@tenKH", tenKH);
                    cmd.Parameters.AddWithValue("@sdtKH", sdtKH);
                    cmd.Parameters.AddWithValue("@ngayAn", ngayAn);
                    cmd.Parameters.AddWithValue("@soLuongMon", soLuongMon);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    // Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    this.Close();
                }
            }
            else
            {
                try
                {
                    DateTime ngayAn = DateTime.Now;
                    double tongTien = 0;
                    foreach (FoodItem item in foodLV.Items)
                    {
                        tongTien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
                    }
                    int soLuongMon = 0;
                    foreach (FoodItem item in foodLV.Items)
                    {
                        soLuongMon += item.Qty;
                    }

                    conn.Open();

                    string insertString = @"
                 insert into HoaDon
                 (NgayAn, SoLuongMon, TongTien)
                 values (@ngayAn, @soLuongMon, @tongTien)";

                    SqlCommand cmd = new SqlCommand(insertString, conn);
                    cmd.Parameters.AddWithValue("@ngayAn", ngayAn);
                    cmd.Parameters.AddWithValue("@soLuongMon", soLuongMon);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    // Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    this.Close();
                }
            }
        }

        private void huyboBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // ---------------------------------           DZ           ---------------------------------//
    }
}
