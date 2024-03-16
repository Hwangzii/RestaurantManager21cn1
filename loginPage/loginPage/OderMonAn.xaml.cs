using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// <summary>
    /// Interaction logic for OderMonAn.xaml
    /// </summary>
    public partial class OderMonAn : Window
    {
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=restaurant_DB_vxn;Integrated Security=True";
        public OderMonAn()
        {
            InitializeComponent();
        }

        private void goimonTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonNuongTabItem.IsSelected)
            {
                int maMonAn = 0;
                SqlConnection conn = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("SELECT * FROM monan_TB", conn);
                conn.Open();
                using(SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMA"];
                        for (int i = 1; i < 35; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();
                            TextBlock dynamicTxtGiaMonAn = new TextBlock();
                            Image dynamicImg = new Image();
                            string foodImageURL = string.Format(@"/Images/diet.png",i); ///Images/{0}.jpg
                            BitmapImage foodImg = new BitmapImage(new Uri(foodImageURL,UriKind.Relative));
                            dynamicImg.Source=foodImg;
                            dynamicImg.Width= 150;
                            dynamicImg.Height = 150;

                            int row = (i-1)/5;
                            int column = (i-1)%5;

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
                                dynamicBtn.Style = (Style)FindResource("buttondes");

                                Grid.SetColumn(dynamicBtn, column);
                                Grid.SetRow(dynamicBtn, row);

                                monNuongGrid.Children.Add(dynamicBtn);
                            }
                        }
                    }
                }
            }

            else if (MonLauTabItem.IsSelected)
            {
                int maMonAn = 0;
                SqlConnection conn = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("SELECT * FROM monan_TB", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMA"];
                        for (int i = 11; i <= 35; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();
                            TextBlock dynamicTxtGiaMonAn = new TextBlock();
                            Image dynamicImg = new Image();
                            string foodImageURL = string.Format(@"/Images/diet.png", i);
                            BitmapImage foodImg = new BitmapImage(new Uri(foodImageURL, UriKind.Relative));
                            dynamicImg.Source = foodImg;
                            dynamicImg.Width = 150;
                            dynamicImg.Height = 150;

                            int row = (i - 11) / 5;
                            int column = i % 5;

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

                                monLauGrid.Children.Add(dynamicBtn);
                            }


                        }
                    }
                }
            }

            else if (monChinTabItem.IsSelected)
            {
                int maMonAn = 0;
                SqlConnection conn = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("SELECT * FROM monan_TB", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMA"];
                        for (int i = 11; i <= 35; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();
                            TextBlock dynamicTxtGiaMonAn = new TextBlock();
                            Image dynamicImg = new Image();
                            string foodImageURL = string.Format(@"/Images/diet.png", i);
                            BitmapImage foodImg = new BitmapImage(new Uri(foodImageURL, UriKind.Relative));
                            dynamicImg.Source = foodImg;
                            dynamicImg.Width = 150;
                            dynamicImg.Height = 150;

                            int row = (i - 11) / 5;
                            int column = i % 5;

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

                                monChinGrid.Children.Add(dynamicBtn);
                            }


                        }
                    }
                }
            }

            else if (DoUongTabItem.IsSelected)
            {
                int maMonAn = 0;
                SqlConnection conn = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("SELECT * FROM monan_TB", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMA"];
                        for (int i = 11; i <= 35; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();
                            TextBlock dynamicTxtGiaMonAn = new TextBlock();
                            Image dynamicImg = new Image();
                            string foodImageURL = string.Format(@"/Images/diet.png", i);
                            BitmapImage foodImg = new BitmapImage(new Uri(foodImageURL, UriKind.Relative));
                            dynamicImg.Source = foodImg;
                            dynamicImg.Width = 150;
                            dynamicImg.Height = 150;

                            int row = (i - 11) / 5;
                            int column = i % 5;

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

                                DoUongGrid.Children.Add(dynamicBtn);
                            }


                        }
                    }
                }
            }
        }

        private void inhoadon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("chua co su kien nao");
        }

        private void thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("chua co su kien nao");
        }
    }
}
