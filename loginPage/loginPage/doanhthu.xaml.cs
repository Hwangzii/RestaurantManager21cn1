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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginPage
{
    /// <summary>
    /// Interaction logic for doanhthu.xaml
    /// </summary>
    public partial class doanhthu : UserControl
    {
        public doanhthu()
        {
            InitializeComponent();
        }

        private void btnxemDoanhThu_Click(object sender, RoutedEventArgs e)
        {
            HoaDonFoodKorean HDonFood = new HoaDonFoodKorean();

            var hoaDonFood = HDonFood.GetAddBills();
            Dataview.ItemsSource = hoaDonFood;
        }
    }
}
