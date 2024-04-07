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
            //
            tang1UserControl.DynamicButtonClicked += Tang1UserControl_DynamicButtonClicked;
            gridShowTable.Children.Add(tang1UserControl);
        }

        private void Tang1UserControl_DynamicButtonClicked(object sender, EventArgs e)
        {
            // Tạm ẩn cửa sổ hiện tại khi nhấp vào nút dynamicBtn
            this.Visibility = Visibility.Collapsed;
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
            doanhthu doanhthuUserControl = new doanhthu();
            gridShowTable.Children.Add(doanhthuUserControl);
        }

        // Phi: thêm logout
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(); // Tạo mới một instance của MainWindow
            mainWindow.Show(); // Hiển thị MainWindow
            this.Close(); // Đóng cửa sổ hiện tại
        }

        // Hùng: Tạo List Luu hoa don tam thoi
        public static List<LuuHoaDon> LuuHoadon = new List<LuuHoaDon>();

        // Hùng: Tạo Button để nhớ button bàn đang bấm
        public static Button NutDangChon = new Button();
        

        // Hùng: Phương thức load hóa đơn
        public static List<FoodItem> LoadHoadon(string a)
        {
            LuuHoaDon item = LuuHoadon.Find(i => i.Ban == a);
            if (item != null)
            {
                return item.Danhsach;
            }
            else { return new List<FoodItem>(); }
        }

        // Hùng: Phương thức khi thanh toán
        public static void ThanhToanXong(string a)
        {
            int i = LuuHoadon.FindIndex(i => i.Ban == a);
            if (i >= 0)
            {
                LuuHoadon.RemoveAt(i);
            }
            NutDangChon.Background = Brushes.White;
            MessageBox.Show("Thanh toan thanh cong");
        }

        // Hùng: Khi khởi tạo, kiểm tra nút
        public static void MauKhoiTao(TextBlock txtb, Button bt)
        {
            foreach(LuuHoaDon item in LuuHoadon)
            {
                if (txtb.Text == item.Ban)
                {
                    bt.Background = Brushes.LightSkyBlue;
                    break;
                }
            }
        }

    }
}
