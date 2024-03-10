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
        

        // FIX LAI CODE

        public trangchu()
        {
            InitializeComponent();
            
        }

       

        private void comboBoxMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xóa các UserControl hiện tại trong pageContainer
            pageContainer.Children.Clear();

            // Lấy ComboBoxItem đã chọn
            ComboBoxItem selectedItem = comboBoxMenu.SelectedItem as ComboBoxItem;

            // Kiểm tra ComboBoxItem đã chọn và hiển thị Page tương ứng
            if (selectedItem != null)
            {
                if (selectedItem.Content.ToString() == "Món nóng")
                {
                    // Hiển thị Page1
                    
                    page1 page1 = new page1();
                    pageContainer.Children.Add(page1);
                }
                // Xử lý các ComboBoxItem khác ở đây
            }
        }
    }


    
}
