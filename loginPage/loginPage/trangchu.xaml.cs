using System;
using System.Collections.Generic;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace loginPage
{

    public partial class trangchu : Window
    {

        private ComboBoxItem previousSelectedItem;


        public trangchu()
        {
            InitializeComponent();

            pageContainer.Children.Add(new page5());

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
                case "test":
                    pageContainer.Children.Clear();
                    pageContainer.Children.Add(new pagetest());
                    break;
                default:
                    /*if (1>0)
                    {
                        
                    }
                    else
                    {

                    }*/
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

        private void pageFood7_Selected(object sender, RoutedEventArgs e)
        {
            pageContainer.Children.Clear();
            pageContainer.Children.Add(new pagetest());
        }
    }


    
}
