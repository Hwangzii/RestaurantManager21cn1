﻿using Microsoft.Win32.SafeHandles;
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
        string connectstring = @"Data Source=DESKTOP-ELTO818;Initial Catalog=Quanlynhahang21CN11;Integrated Security=True";
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


        // Hùng: Mở bảng tạm thanh toán
        private void inhoadon_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;

            SoBann.Text = "Bàn: " + tableNumber.Text;
            Ngay_An.Text = "Ngày: " + DateTime.Now;
            StackPanell.Children.Clear();

            foreach (FoodItem item in ListOderBox.Items)
            {
                AddTextBlockWithThreeColumns(item.Name,item.Qty, item.Price);
            }

        }


        // Hùng: tạo bảng trong tạm thanh toán
        void AddTextBlockWithThreeColumns(string column1Text, int column2Text, string column3Text)
        {
            Grid grid = new Grid();
            grid.MinHeight = 25;
            grid.Margin = new Thickness(10, 10, 10, 10);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(280) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition()  );
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(140) });

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = column1Text;
            Grid.SetColumn(textBlock1, 0);
            grid.Children.Add(textBlock1);
            textBlock1.TextAlignment = TextAlignment.Left;
            textBlock1.Width = 300;

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = column2Text.ToString();
            Grid.SetColumn(textBlock2, 1);
            textBlock2.TextAlignment = TextAlignment.Center;
            grid.Children.Add(textBlock2);

            TextBlock textBlock3 = new TextBlock();
            textBlock3.Text = column3Text;
            Grid.SetColumn(textBlock3, 2);
            grid.Children.Add(textBlock3);
            textBlock3.TextAlignment = TextAlignment.Right;

            TextBlock textBlock4 = new TextBlock();
            double GiaTien = double.Parse(column3Text.Replace(" vnđ", ""));
            textBlock4.Text = (GiaTien* column2Text).ToString() + " vnđ ";
            Grid.SetColumn(textBlock4, 3);
            textBlock4.TextAlignment = TextAlignment.Right;
            grid.Children.Add(textBlock4);

            StackPanell.Children.Add(grid);
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

        // Hùng: Thêm biến public để lưu nút đang bị bấm

        Button TheButton;
        int soluong3;


        // Hùng: Thêm chức năng để gọi item từ một phần tử của nó

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        // Hùng: Thêm chức năng để mở panel thay đổi số lượng

        public void ChangeAmount_Click(object sender, RoutedEventArgs e)
        {
            TheButton = sender as Button;
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            string namee = item.Name;
            int Qtyy = item.Qty;

            //popup.visibility = visible
            popup.IsOpen = true;
            Hienthiso.Text = Qtyy.ToString();
            Hienthitenmon.Text = namee;

        }

        // Hùng: Thêm 2 chức năng tăng giảm số lượng

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            soluong3 += 1;
            Hienthiso.Text = soluong3.ToString();

        }

        private void ButtonClickSub(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            if (soluong3 > 1)
            {
                soluong3 -= 1;
                Hienthiso.Text = soluong3.ToString();
            }
        }

        // Hùng: 3 chức năng của 3 nút bấm trong bảng thay đổi số lượng

        private void Accept(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            item.Qty = soluong3;
            ListOderBox.Items.Refresh();
            Tongtien();
            popup.IsOpen = false;
        }

        public void Remove_Click(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            ListOderBox.Items.Remove(item);
            Tongtien();
            popup.IsOpen = false;

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void Click_Dong_Xac_Nhan(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = false;
        }



    }
}