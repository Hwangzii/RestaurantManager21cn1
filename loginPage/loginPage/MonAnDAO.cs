using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Navigation;

namespace loginPage
{
    internal class MonAnDAO
    {
        string connectionString = "Data Source = HOANGPHI; Initial Catalog = Quanlynhahang21CN1;" + "Integrated Security = True; TrustServerCertificate = True";
        public List<MonAn> getAllMonAn(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 1; i <= 50; i++)
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

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }

                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }

        public List<MonAn> getMonNuong(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 1; i <= 10; i++)
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

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }
                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }

        public List<MonAn> getMonLau(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 11; i <= 20; i++)
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

                        int row = (i - 11) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }
                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }
        public List<MonAn> getMonNong(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 21; i <= 30; i++)
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

                        int row = (i - 21) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }
                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }
        public List<MonAn> getDoUong(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 31; i <= 40; i++)
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

                        int row = (i - 31) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }
                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }
        public List<MonAn> getMonTrangMieng(Grid targetGrid, TabItem targetTabItem, RoutedEventHandler targetRoutedEventHandler)
        {
            List<MonAn> listMonAn = new List<MonAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from MonAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = (int)reader.GetInt32(0);
                    monAn.TenMon = (string)reader.GetString(2);
                    monAn.GiaTien = (int)reader.GetInt32(3);

                    for (int i = 41; i <= 50; i++)
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

                        int row = (i - 41) / 5;
                        int column = (i - 1) % 5;

                        if (monAn.MaMonAn == i)
                        {
                            dynamicTxtTenMonAn.Text = i.ToString() + ".  " + monAn.TenMon;
                            dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                            dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                            dynamicTxtTenMonAn.FontSize = 20;
                            dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                            dynamicTxtGiaMonAn.Text = ((int)monAn.GiaTien).ToString("#,##") + " vnđ";
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
                            //dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += targetRoutedEventHandler;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetGrid.Children.Add(dynamicBtn);
                        }
                    }
                    listMonAn.Add(monAn);
                }
            }
            return listMonAn;
        }
    }
}
