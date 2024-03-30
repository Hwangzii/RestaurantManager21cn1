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
    /// <summary>
    /// Interaction logic for Tang2.xaml
    /// </summary>
    public partial class Tang2 : UserControl
    {
        public event EventHandler DynamicButtonClicked;




        string connectstring = @"Data Source=DESKTOP-ELTO818;Initial Catalog=Quanlynhahang21CN111;Integrated Security=True;Encrypt=False";
        public Tang2()
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
                    for (int i = 1; i <= 40; i++)
                    {

                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        TextBlock dynamicTxtTenBanAn = new TextBlock();

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (maBanAn == i+20 )
                        {
                            dynamicTxtTenBanAn.Text = read["TenBan"].ToString();
                            dynamicTxtTenBanAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenBanAn.VerticalAlignment = VerticalAlignment.Center;
                            dynamicTxtTenBanAn.FontSize = 30;

                            dynamicStp.Children.Add(dynamicTxtTenBanAn);

                            dynamicBtn.Background = Brushes.White;
                            tablebooked.MauKhoiTao(dynamicTxtTenBanAn, dynamicBtn);
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

        protected virtual void OnDynamicButtonClicked(EventArgs e)
        {
            DynamicButtonClicked?.Invoke(this, e);
        }

        private void DynamicBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            StackPanel stackPanel = clickedButton.Content as StackPanel;
            TextBlock textBlock = stackPanel.Children[0] as TextBlock;

            tablebooked.NutDangChon = sender as Button;

            if (textBlock != null)
            {              
                OderMonAn orderForm = new OderMonAn();
                orderForm.settext(textBlock.Text);
                orderForm.Show();

                if (clickedButton.Background == Brushes.Red)
                {
                    foreach (FoodItem item in tablebooked.LoadHoadon(textBlock.Text))
                    {
                        orderForm.ListOderBox.Items.Add(item);
                    }
                    orderForm.Tongtien();
                }
            }
        }
    }
}
