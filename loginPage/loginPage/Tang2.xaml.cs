﻿using System;
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

        string connectstring = @"Data Source=DESKTOP-ELTO818;Initial Catalog=Quanlynhahang21CN11;Integrated Security=True";
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
                            dynamicBtn.Margin = new Thickness(0, 20, 20, 20);
                            dynamicBtn.Content = dynamicStp;

                            dynamicBtn.Click += (sender, e) =>
                            {
                                var orderMonAn = new OderMonAn();
                                orderMonAn.WindowState = WindowState.Maximized;
                                orderMonAn.Show();
                                var closerMonAn = new tablebooked();
                                closerMonAn.Close();
                                OnDynamicButtonClicked(EventArgs.Empty);
                            };

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
    }
}