using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace loginPage
{
    internal class BanAnDAO
    {
        string connectionString = "Data Source=HOANGPHI;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";

        public List<BanAn> getBanAnTang1(Grid targetTableGrid)
        {
            List<BanAn> listBanAn = new List<BanAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from BanAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    BanAn banAn = new BanAn();
                    banAn.MaBan = (int)reader.GetInt32(0);

                    for (int i = 1; i <= 20; i++)
                    {
                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        TextBlock dynamicTxtTenBanAn = new TextBlock();

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (banAn.MaBan == i)
                        {
                            dynamicTxtTenBanAn.Text = (string)reader.GetString(3);
                            dynamicTxtTenBanAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenBanAn.VerticalAlignment = VerticalAlignment.Center;
                            dynamicTxtTenBanAn.FontSize = 30;

                            dynamicStp.Children.Add(dynamicTxtTenBanAn);
                            dynamicBtn.Background = Brushes.White;
                            tablebooked.MauKhoiTao(dynamicTxtTenBanAn, dynamicBtn);
                            dynamicBtn.Margin = new Thickness(0, 20, 20, 20);
                            dynamicBtn.Content = dynamicStp;
                            dynamicBtn.Style = (Style)Application.Current.FindResource("buttondes");
                            dynamicBtn.Click += DynamicBtn_Click;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetTableGrid.Children.Add(dynamicBtn);
                        }
                    }

                    listBanAn.Add(banAn);
                }
            }

            return listBanAn;
        }
        public List<BanAn> getBanAnTang2(Grid targetTableGrid)
        {
            List<BanAn> listBanAn = new List<BanAn>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlcommand = new SqlCommand("Select * from BanAn", sqlConnection);

            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    BanAn banAn = new BanAn();
                    banAn.MaBan = (int)reader.GetInt32(0);

                    for (int i = 21; i <= 40; i++)
                    {
                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        TextBlock dynamicTxtTenBanAn = new TextBlock();

                        int row = (i - 21) / 5;
                        int column = (i - 1) % 5;

                        if (banAn.MaBan == i)
                        {
                            dynamicTxtTenBanAn.Text = (string)reader.GetString(3);
                            dynamicTxtTenBanAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenBanAn.VerticalAlignment = VerticalAlignment.Center;
                            dynamicTxtTenBanAn.FontSize = 30;

                            dynamicStp.Children.Add(dynamicTxtTenBanAn);
                            dynamicBtn.Background = Brushes.White;
                            tablebooked.MauKhoiTao(dynamicTxtTenBanAn, dynamicBtn);
                            dynamicBtn.Margin = new Thickness(0, 20, 20, 20);
                            dynamicBtn.Content = dynamicStp;
                            dynamicBtn.Style = (Style)Application.Current.FindResource("buttondes");
                            dynamicBtn.Click += DynamicBtn_Click;

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            targetTableGrid.Children.Add(dynamicBtn);
                        }
                    }

                    listBanAn.Add(banAn);
                }
            }

            return listBanAn;
        }
        public void DynamicBtn_Click(object sender, RoutedEventArgs e)
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

                if (tablebooked.LuuHoadon.Exists(i=>i.Ban == textBlock.Text))
                {
                    foreach (FoodItem item in tablebooked.LoadHoadon(textBlock.Text))
                    {
                        orderForm.ListOderBox.Items.Add(item);
                    }
                    orderForm.Tongtien();
                }
            }
            //Hùng: lưu nút đang chọn và load hóa đơn nếu có
        }
    }
}
