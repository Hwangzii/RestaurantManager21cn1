using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Xử lý logic khi Border được click
        }


        private void ban1Button_Click(object sender, RoutedEventArgs e)
        {
            
            var test = new backtest();
            test.Show();
            this.Hide();
            this.Close();
        }
        


        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void ban2Button_Click_1(object sender, RoutedEventArgs e)
        {
            var test = new danhsachbanan();
            test.Show();
            this.Hide();
            this.Close();
        }
    }
}
