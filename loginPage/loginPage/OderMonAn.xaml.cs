using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
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
        string connectstring = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";
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
                        for (int i = 1; i <= 35; i++)
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
                        for (int i = 11; i <= 20; i++)
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
                            int column = (i - 1) % 5;

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
                        for (int i = 21; i <= 30; i++)
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

                            int row = (i - 21) / 5;
                            int column = (i - 1) % 5;

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
                        for (int i = 31; i <= 35; i++)
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

                            int row = (i - 31) / 5;
                            int column = (i - 1) % 5;

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

        // Nam: Thêm thời gian vào column
        private void DynamicBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string foodTime = DateTime.Now.ToString("HH:mm");
            string foodName = ((TextBlock)((StackPanel)clickedButton.Content).Children[2]).Text;
            string foodPrice = ((TextBlock)((StackPanel)clickedButton.Content).Children[3]).Text;
            FoodItem newfoodItem = new FoodItem()
            {
               Name = foodName,
               Price = foodPrice,
               Qty = 1,
               Time = foodTime,
             };
             ListOderBox.Items.Add(newfoodItem);
           
            Tongtien();
        }

        private void Tongtien()
        {
            double tongtien = 0;
            foreach (FoodItem item in ListOderBox.Items)
            {
                tongtien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
            }
            luuThongtin.Content = tongtien.ToString() + " đ";
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

        // ============ Ngọc: Code nút lưu thông tin vào db ============//
        private void luuThongtin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectstring);
            if (ListOderBox.Items.Count == 0)
            {
                MessageBox.Show("Chưa có món ăn. Lưu thông tin thất bại");
            }
            else
            {
                try
                {
                    conn.Open();

                    string tenBan = tableNumber.Text;
                    string findTableID = "select * from BanAn where TenBan = @tenBan";
                    int banID = 0;

                    SqlCommand cmdTableID = new SqlCommand(findTableID, conn);
                    cmdTableID.Parameters.AddWithValue("@tenBan", tenBan);

                    using (SqlDataReader read = cmdTableID.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            banID = (int)read["MaBan"];
                        }
                    }

                    DateTime ngayAn = DateTime.Now;
                    double tongTien = 0;
                    foreach (FoodItem item in ListOderBox.Items)
                    {
                        tongTien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
                    }
                    int soLuongMon = 0;
                    foreach (FoodItem item in ListOderBox.Items)
                    {
                        soLuongMon += item.Qty;
                    }

                    string insertString = @"
                    insert into HoaDon
                    (MaBan, NgayAn, SoLuongMon, TongTien)
                    values (@maBan, @ngayAn, @soLuongMon, @tongTien)";

                    SqlCommand cmd = new SqlCommand(insertString, conn);
                    cmd.Parameters.AddWithValue("@ngayAn", ngayAn);
                    cmd.Parameters.AddWithValue("@soLuongMon", soLuongMon);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);
                    cmd.Parameters.AddWithValue("@maBan", banID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thông tin thành công");
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                finally
                {

                    // Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
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




    }

}
