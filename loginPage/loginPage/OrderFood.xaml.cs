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

namespace loginPage
{
    /// <summary>
    /// Interaction logic for OrderFood.xaml
    /// </summary>
    public partial class OrderFood : Window
    {
        public OrderFood()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        

        

        

        

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem cửa sổ chủ có tồn tại không
            if (this.Owner != null)
            {
                // Đặt cửa sổ chủ là cửa sổ hiện tại và đóng cửa sổ hiện tại
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
