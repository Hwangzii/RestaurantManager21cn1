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
    
    public partial class tablebooked : Window
    {
        

        
        public tablebooked()
        {
            InitializeComponent();
            ShowTang1UserControl();
        }

        private void ShowTang1UserControl()
        {
            Tang1 tang1UserControl = new Tang1();
            gridShowTable.Children.Add(tang1UserControl);
        }



        private void Tang1Btn_Click(object sender, RoutedEventArgs e)
        {
            Tang1 tang1UserControl = new Tang1();
            gridShowTable.Children.Add(tang1UserControl);
        }

        private void Tang2Btn_Click(object sender, RoutedEventArgs e)
        {
            Tang2 tang2UserControl = new Tang2();
            gridShowTable.Children.Add(tang2UserControl);
        }

        private void doanhthuBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hiện chưa có sự kiện nào", "thông báo",
            MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
