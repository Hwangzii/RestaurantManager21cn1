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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginPage
{
    public partial class page5 : UserControl
    {
        string connectstring = @"Data Source=DESKTOP-BTLUTR6\SQLEXPRESS;Initial Catalog=restaurant_DB;Integrated Security=True;Encrypt=False";
        public page5()
        {
            InitializeComponent();
            int maMonAn = 0;
            SqlConnection con = new SqlConnection(connectstring);
            SqlCommand command = new SqlCommand("select * from monan_TB", con);
            con.Open();
            using (SqlDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    maMonAn = (int)read["MaMA"];
                    for (int i = 1; i <= 35; i++)
                    {
                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        Border dynamicBorder = new Border();
                        TextBlock dynamicTxtTenMonAn = new TextBlock();
                        TextBlock dynamicTxtGiaMonAn = new TextBlock();
                        Image dynamicImg = new Image();
                        string foodImageURL = string.Format(@"/Images/{0}.jpg", i);
                        BitmapImage foodImg = new BitmapImage(new Uri(foodImageURL, UriKind.Relative));
                        dynamicImg.Source = foodImg;
                        dynamicImg.Width = 150;
                        dynamicImg.Height = 150;

                        int row = (i - 1) / 3;
                        int column = (i - 1) % 3;

                        if (maMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + read["TenMA"].ToString();
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = read["DonGia"].ToString() + " vnđ";
                            dynamicTxtGiaMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtGiaMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtGiaMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtGiaMonAn.FontSize = 16;
                            dynamicTxtGiaMonAn.Foreground = Brushes.Gray;
                            dynamicTxtGiaMonAn.TextWrapping = TextWrapping.WrapWithOverflow;

                            dynamicStp.Children.Add(dynamicBorder);
                            dynamicStp.Children.Add(dynamicImg);
                            dynamicStp.Children.Add(dynamicTxtTenMonAn);
                            dynamicStp.Children.Add(dynamicTxtGiaMonAn);

                            dynamicBtn.Background = Brushes.White;
                            dynamicBtn.Margin = new Thickness(0, 10, 10, 0);
                            dynamicBtn.Content = dynamicStp;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            allGrid.Children.Add(dynamicBtn);
                        }
                    }
                }
            }
        }
    }
}
