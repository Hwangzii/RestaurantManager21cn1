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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginPage
{
    
    public partial class Tang1 : UserControl
    {
        // Khai báo sự kiện DynamicButtonClicked
        public event EventHandler DynamicButtonClicked;

        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1;Integrated Security=True";
        public Tang1()
        {
            InitializeComponent();
            int maBanAn = 0;
            SqlConnection conn = new SqlConnection(connectstring);
            SqlCommand command = new SqlCommand("select *  from BanAn", conn);
            conn.Open();

           

            using (SqlDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    maBanAn = (int)read["MaBan"];
                    for (int i = 1; i <= 20; i++)
                    {

                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        TextBlock dynamicTxtTenBanAn = new TextBlock();

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (maBanAn == i)
                        {
                            dynamicTxtTenBanAn.Text = read["TenBan"].ToString();
                            dynamicTxtTenBanAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenBanAn.VerticalAlignment = VerticalAlignment.Center;
                            dynamicTxtTenBanAn.FontSize = 30;


                            dynamicStp.Children.Add(dynamicTxtTenBanAn);

                            dynamicBtn.Background = Brushes.White;
                            dynamicBtn.Margin = new Thickness(0, 20, 20, 20);
                            dynamicBtn.Content = dynamicStp;
                            dynamicBtn.Style = (Style)FindResource("buttondes");
                            dynamicBtn.Click += DynamicBtn_Click;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            gridTable1.Children.Add(dynamicBtn);
                        }
                    }
                }
            }
        }
        // Phương thức để kích hoạt sự kiện DynamicButtonClicked
        protected virtual void OnDynamicButtonClicked(EventArgs e)
        {
            DynamicButtonClicked?.Invoke(this, e);
        }

        private void DynamicBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            StackPanel stackPanel = clickedButton.Content as StackPanel;
            TextBlock textBlock = stackPanel.Children[0] as TextBlock;

            if (textBlock != null)
            {
                OderMonAn orderForm = new OderMonAn();
                orderForm.settext(textBlock.Text);
                orderForm.Show();
                
            }
        }

    }
}
