using System;
using System.Windows;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Data;
using System.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Controls;
using System.Data.Sql;
using System.Data.SqlClient;




namespace loginPage
{

    public partial class MainWindow : Window
    {
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaxximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                
                if (IsMaxximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1024;
                    this.Height = 720;
                    IsMaxximize = false ;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaxximize = true ;
                }
            }
        }

        




        private void button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (con = new SqlConnection(connectstring))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Quanly WHERE TaiKhoan=@Username AND MatKhau=@Password";
                    using (cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text);

                        int count = (int)cmd.ExecuteScalar();
                        if (count == 1)
                        {
                            tablebooked dashboarch = new tablebooked();
                            dashboarch.WindowState = WindowState.Maximized;
                            dashboarch.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


        }

        private void ForgotpasswordButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hiện chưa thể ấn quên mật khẩu", "cảnh báo",
            MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void signupButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hiện chưa có tính năng đăng ký","thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void loginUI_Loaded(object sender, RoutedEventArgs e)
        {
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;

            this.Left = 0;
            this.Top = 0;
            this.Width = w;
            this.Height = h;
        }
    }
}
