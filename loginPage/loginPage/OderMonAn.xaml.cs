using Microsoft.Win32.SafeHandles;
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
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1;Integrated Security=True";
        public OderMonAn()
        {
            InitializeComponent();
        }

        // Nam: hiển thị số bàn
        public void settext(string text)
        {
            tableNumber.Text = text;
        }

        private void goimonTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonNuongTabItem.IsSelected)
            {
                int maMonAn = 0;
                SqlConnection conn = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("SELECT * FROM MonAn", conn);
                conn.Open();
                using(SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMonAn"];
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
                                dynamicTxtTenMonAn.Text = i.ToString() + ".  " + read["TenMon"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicTxtGiaMonAn.Text = read["GiaTien"].ToString() + " vnđ";
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
                                dynamicBtn.Click += DynamicBtn_Click;

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
                SqlCommand command = new SqlCommand("SELECT * FROM MonAn", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMonAn"];
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
                                dynamicTxtTenMonAn.Text = i.ToString() + ".  " + read["TenMon"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicTxtGiaMonAn.Text = read["GiaTien"].ToString() + " vnđ";
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
                                dynamicBtn.Click += DynamicBtn_Click;

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
                SqlCommand command = new SqlCommand("SELECT * FROM MonAn", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMonAn"];
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
                                dynamicTxtTenMonAn.Text = i.ToString() + ".  " + read["TenMon"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicTxtGiaMonAn.Text = read["GiaTien"].ToString() + " vnđ";
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
                                dynamicBtn.Click += DynamicBtn_Click;

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
                SqlCommand command = new SqlCommand("SELECT * FROM MonAn", conn);
                conn.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maMonAn = (int)read["MaMonAn"];
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
                                dynamicTxtTenMonAn.Text = i.ToString() + ".  " + read["TenMon"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicTxtGiaMonAn.Text = read["GiaTien"].ToString() + " vnđ";
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
                                dynamicBtn.Click += DynamicBtn_Click;

                                Grid.SetColumn(dynamicBtn, column);
                                Grid.SetRow(dynamicBtn, row);

                                DoUongGrid.Children.Add(dynamicBtn);
                            }


                        }
                    }
                }
            }
        }

        private void DynamicBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string foodName = ((TextBlock)((StackPanel)clickedButton.Content).Children[2]).Text;
            string foodPrice = ((TextBlock)((StackPanel)clickedButton.Content).Children[3]).Text;

            bool itemFound = false;
            foreach (FoodItem item in ListOderBox.Items)
            {
                if (item.Name == foodName)
                {
                    item.Qty++;
                    itemFound = true; 
                    break;
                }
            }
            if (!itemFound)
            {
                FoodItem newfoodItem = new FoodItem()
                {
                    Name = foodName,
                    Price = foodPrice,
                    Qty = 1,
                };
                ListOderBox.Items.Add(newfoodItem);
            }
            else
            {
                ListOderBox.Items.Refresh();
            }
            Tongtien();
        }

        private void Tongtien()
        {
            double tongtien = 0;
            foreach (FoodItem item in ListOderBox.Items)
            {
                tongtien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
            }
            thanhtoan.Content = tongtien.ToString() + " đ";
        }

        private void inhoadon_Click(object sender, RoutedEventArgs e)
        {
            phieuhoadon inhoadon = new phieuhoadon();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;
            inhoadon.Left = 0;
            inhoadon.Top = 0;
            inhoadon.Width = w/3;
            inhoadon.Height = h;
            inhoadon.Show();
        }

        private void thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("chua co su kien nao");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            // Tìm và đóng cửa sổ tablebooked khi nhấp vào nút Back
            Window tablebookedWindow = Application.Current.Windows.OfType<tablebooked>().FirstOrDefault();
            if (tablebookedWindow != null)
            {
                tablebookedWindow.Visibility = Visibility.Visible;
                this.Close(); // Đóng cửa sổ hiện tại (OderMonAn)
            }

        }

        // Phi: code thêm hiển thị giao diện  
        private void OrderfoodForm_Loaded(object sender, RoutedEventArgs e)
        {
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;
            this.WindowState = WindowState.Maximized;
            this.Left = 0;
            this.Top = 0;
            this.Width = w;
            this.Height = h;
        }
    }
}
