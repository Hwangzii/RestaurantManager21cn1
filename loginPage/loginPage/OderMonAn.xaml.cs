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
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";
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

                                dynamicTxtGiaMonAn.Text = ((int)read["GiaTien"]).ToString("#,##") + " vnđ";                               
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

                                dynamicTxtGiaMonAn.Text = ((int)read["GiaTien"]).ToString("#,##") + " vnđ";
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

                                dynamicTxtGiaMonAn.Text = ((int)read["GiaTien"]).ToString("#,##") + " vnđ";
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

                                dynamicTxtGiaMonAn.Text = ((int)read["GiaTien"]).ToString("#,##") + " vnđ";
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
            hienthitongtien.Text = tongtien.ToString("#,##") + " đ";
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

        // Hùng + Phi: 3 chức năng của 3 nút bấm trong bảng thay đổi số lượng


        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            ListOderBox.Items.Remove(item);
            Tongtien();
            popup.IsOpen = false;
        }

        private void luuBtn_Click(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            item.Qty = soluong3;
            ListOderBox.Items.Refresh();
            Tongtien();
            popup.IsOpen = false;
        }

        // Hùng: Thêm 2 chức năng tăng giảm số lượng

        private void truBtn_Click(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            if (soluong3 > 1)
            {
                soluong3 -= 1;
                Hienthiso.Text = soluong3.ToString();
            }
        }

        private void congBtn_Click(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            soluong3 += 1;
            Hienthiso.Text = soluong3.ToString();

        }

        private void thanhtoanBtn_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(connectstring);

            if (tenktTxtBox.Text != null && sdtkhTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập SĐT của khách hàng");
            }
            else if (sdtkhTxtBox.Text != null && tenktTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập tên của khách hàng");
            }
            else if (tenktTxtBox.Text != null && sdtkhTxtBox.Text != null)
            {
                try
                {
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
                hienthitongtien.Text = tongTien.ToString();

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

        private void inhoadonBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hiện chưa thể in phiếu thanh toán!");
        }

        // === PHI: Thêm câu lênh mở Popup hóa đơn
        private void inhoadon_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
            Thoigian.Text = "Ngày: " + DateTime.Now.ToString();
            Ban.Text = "Bàn: " + tableNumber.Text;
            TongTien.Text = hienthitongtien.Text;
            SortThatShitOut();
            Hienthi.Children.Clear();

            // === Hùng: Thêm item vào hóa đơn từ List ====
            foreach (FoodItem item in Danhsach)
            {
                Grid grid = new Grid();
                grid.MinHeight = 25;
                grid.Margin = new Thickness(10, 10, 10, 10);
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(300) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });

                TextBlock textBlock1 = new TextBlock();
                textBlock1.Text = item.Name;
                Grid.SetColumn(textBlock1, 0);
                grid.Children.Add(textBlock1);
                textBlock1.TextAlignment = TextAlignment.Left;
                textBlock1.Width = 300;

                TextBlock textBlock2 = new TextBlock();
                textBlock2.Text = item.Qty.ToString();
                Grid.SetColumn(textBlock2, 1);
                textBlock2.TextAlignment = TextAlignment.Center;
                grid.Children.Add(textBlock2);

                TextBlock textBlock3 = new TextBlock();
                textBlock3.Text = item.Price;
                Grid.SetColumn(textBlock3, 2);
                grid.Children.Add(textBlock3);
                textBlock3.TextAlignment = TextAlignment.Right;

                TextBlock textBlock4 = new TextBlock();
                double GiaTien = double.Parse(item.Price.Replace(" vnđ", ""));
                textBlock4.Text = (GiaTien * item.Qty).ToString() + " vnđ ";
                Grid.SetColumn(textBlock4, 3);
                textBlock4.TextAlignment = TextAlignment.Right;
                grid.Children.Add(textBlock4);

                Hienthi.Children.Add(grid);
            }


        }

        // === PHI: thêm hủy in hóa đơn ====
        private void huythanhtoanBtn_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = false;
        }

        // === Hùng: Lấ int ID từ tên món để sort ====
        private int GetID(string a)
        {
            int IDD;
            if (Char.IsNumber(a, 1))
            {
                IDD = Convert.ToInt32(a[0]) * 10 + Convert.ToInt32(a[1]);
            }
            else
            {
                IDD = Convert.ToInt32(a[0]);
            }
            return IDD;
        }

        // === Hùng: Tạo một List để sắp xếp item ====
        List<FoodItem> Danhsach = new List<FoodItem>();

        private void SortThatShitOut()
        {
            Danhsach.Clear();
            foreach (FoodItem item in ListOderBox.Items)
            {
                if (Danhsach.Exists(x => x.Name == item.Name))
                {
                    FoodItem item1 = Danhsach.Find(x => x.Name == item.Name);
                    item1.Qty += item.Qty;
                }
                else
                {
                    Danhsach.Add(new FoodItem { Name = item.Name, Qty = item.Qty, Price = item.Price, ID = GetID(item.Name) });
                }
            }
            Danhsach = Danhsach.OrderBy(x => x.ID).ToList();

        }


    }

}
