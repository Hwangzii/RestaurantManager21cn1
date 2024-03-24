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
    
    public partial class phieuhoadon : Window
    {
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1;Integrated Security=True";
        public phieuhoadon()
        {
            InitializeComponent();
        }



        private void formthanhtoan_Loaded(object sender, RoutedEventArgs e)
        {
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;

            this.Left = 0;
            this.Top = 0;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectstring);
            
            if(tenktTxtBox.Text != null && sdtkhTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập SĐT của khách hàng");
            }
            else if(sdtkhTxtBox.Text != null && tenktTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập tên của khách hàng");
            }
            else if(tenktTxtBox.Text != null && sdtkhTxtBox.Text != null)
            {
                try {
                    string tenKH = tenktTxtBox.Text;
                    string sdtKH = sdtkhTxtBox.Text;
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

                    string insertString = @"insert into HoaDon (TenKH, SDTKH, NgayAn, SoLuongMon, TongTien) values (@tenKH, @sdtKH, @ngayAn, @soLuongMon, @tongTien)";

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
    }
}
