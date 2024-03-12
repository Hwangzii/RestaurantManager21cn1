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

    public partial class trangchu : Window
    {
        string connectstring = @"Data Source=DESKTOP-BTLUTR6\SQLEXPRESS;Initial Catalog=restaurant_DB;Integrated Security=True;Encrypt=False";

        private ComboBoxItem previousSelectedItem;

        public trangchu()
        {
            InitializeComponent();

            pageContainer.Children.Add(new page5());

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tang1TabItem.IsSelected)
            {
                int maBanAn = 0;
                SqlConnection con = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("select top 20 * from banan_TB", con);
                con.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maBanAn = (int)read["MaBanAn"];
                        for (int i = 1; i <= 20; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();

                            int row = (i - 1) / 3;
                            int column = (i - 1) % 3;

                            if (maBanAn == i)
                            {
                                dynamicTxtTenMonAn.Text = "Bàn " + read["TenBanAn"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicStp.Children.Add(dynamicBorder);
                                dynamicStp.Children.Add(dynamicTxtTenMonAn);

                                dynamicBtn.Background = Brushes.White;
                                dynamicBtn.Margin = new Thickness(0, 10, 10, 0);
                                dynamicBtn.Content = dynamicStp;

                                Grid.SetColumn(dynamicBtn, column);
                                Grid.SetRow(dynamicBtn, row);

                                banTang1Grid.Children.Add(dynamicBtn);
                            }
                        }
                    }
                }
            }
            else if (tang2TabItem.IsSelected)
            {
                int maBanAn = 0;
                SqlConnection con = new SqlConnection(connectstring);
                SqlCommand command = new SqlCommand("select * from banan_TB not in (select top 20 * from banan_TB)", con);
                con.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maBanAn = (int)read["MaBanAn"];
                        for (int i = 21; i <= 40; i++)
                        {
                            Button dynamicBtn = new Button();
                            StackPanel dynamicStp = new StackPanel();
                            Border dynamicBorder = new Border();
                            TextBlock dynamicTxtTenMonAn = new TextBlock();

                            int row = (i - 21) / 3;
                            int column = i % 3;

                            if (maBanAn == i)
                            {
                                dynamicTxtTenMonAn.Text = "Bàn " + read["TenBanAn"].ToString();
                                dynamicTxtTenMonAn.HorizontalAlignment = HorizontalAlignment.Center;
                                dynamicTxtTenMonAn.VerticalAlignment = VerticalAlignment.Bottom;
                                dynamicTxtTenMonAn.Margin = new Thickness(0, 0, 0, 0);
                                dynamicTxtTenMonAn.FontSize = 20;
                                dynamicTxtTenMonAn.TextWrapping = TextWrapping.Wrap;

                                dynamicStp.Children.Add(dynamicBorder);
                                dynamicStp.Children.Add(dynamicTxtTenMonAn);

                                dynamicBtn.Background = Brushes.White;
                                dynamicBtn.Margin = new Thickness(0, 10, 10, 0);
                                dynamicBtn.Content = dynamicStp;

                                Grid.SetColumn(dynamicBtn, column);
                                Grid.SetRow(dynamicBtn, row);

                                banTang1Grid.Children.Add(dynamicBtn);
                            }
                        }
                    }
                }
            }
        }

        private void comboBoxMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxMenu.SelectedItem;
            string selectedMenu = selectedItem.Content.ToString();

            // kiểm tra mục được chọn và thực hiện hành động tương tự
            switch (selectedMenu)
            {
                case "All":
                    // hiển thị nội dung tương ứng với món nóng trong pageContainer
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new page5());
                    break;
                case "Món Nướng":
                    // hiển thị nội dung tương ứng với món lẩu trong pageContainer
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new page4());
                    break;
                case "Đồ Lẩu":
                    // hiển thị nội dung tương ứng với đồ uống trong pageContainer
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new page3());
                    break;
                case "Món nóng":
                    // hiển thị nội dung tương ứng với đồ uống trong pageContainer
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new page2());
                    break;
                case "Đồ uống":
                    // hiển thị nội dung tương ứng với đồ tráng miệng trong pageContainer
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new page1());
                    break;
                default:
                    if (pageContainer != null)
                    {
                        pageContainer.Children.Clear();
                        pageContainer.Children.Add(new page5());
                    }
                    break;
            }
        }

        private void pageFood2_Selected(object sender, RoutedEventArgs e)
        {
            // Xóa nội dung hiện tại của pageContainer (nếu có)
            pageContainer.Children.Clear();

            // Thêm page1 vào pageContainer
            pageContainer.Children.Add(new page5());
        }

        private void pageFood3_Selected(object sender, RoutedEventArgs e)
        {
            // Xóa nội dung hiện tại của pageContainer (nếu có)
            pageContainer.Children.Clear();

            // Thêm page1 vào pageContainer
            pageContainer.Children.Add(new page4());
        }

        private void pageFood4_Selected(object sender, RoutedEventArgs e)
        {
            // Xóa nội dung hiện tại của pageContainer (nếu có)
            pageContainer.Children.Clear();

            // Thêm page1 vào pageContainer
            pageContainer.Children.Add(new page3());
        }

        private void pageFood5_Selected(object sender, RoutedEventArgs e)
        {
            // Xóa nội dung hiện tại của pageContainer (nếu có)
            pageContainer.Children.Clear();

            // Thêm page1 vào pageContainer
            pageContainer.Children.Add(new page2());
        }

        private void pageFood6_Selected(object sender, RoutedEventArgs e)
        {
            pageContainer.Children.Clear();
            pageContainer.Children.Add(new page1());
        }
    }
}
