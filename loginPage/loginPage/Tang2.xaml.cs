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
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=restaurant_DB_vxn;Integrated Security=True";
        public Tang2()
        {
            InitializeComponent();
            int maBanAn = 21;
            SqlConnection conn = new SqlConnection(connectstring);
            SqlCommand command = new SqlCommand("select *  from banan_TB", conn);
            conn.Open();


            using (SqlDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    maBanAn = (int)read["MaBanAn"];
                    for (int i = 1; i <= 40; i++)
                    {

                        Button dynamicBtn = new Button();
                        StackPanel dynamicStp = new StackPanel();
                        TextBlock dynamicTxtTenBanAn = new TextBlock();

                        int row = (i - 1) / 5;
                        int column = (i - 1) % 5;

                        if (maBanAn == i+20 )
                        {
                            dynamicTxtTenBanAn.Text = read["TenBanAn"].ToString();
                            dynamicTxtTenBanAn.HorizontalAlignment = HorizontalAlignment.Center;
                            dynamicTxtTenBanAn.VerticalAlignment = VerticalAlignment.Center;
                            dynamicTxtTenBanAn.FontSize = 30;


                            dynamicStp.Children.Add(dynamicTxtTenBanAn);

                            dynamicBtn.Background = Brushes.White;
                            dynamicBtn.Margin = new Thickness(0, 20, 20, 20);
                            dynamicBtn.Content = dynamicStp;

                            dynamicBtn.Click += (sender, e) =>
                            {
                                OderMonAn openOder = new OderMonAn();
                                openOder.Show();
                            };

                            Grid.SetColumn(dynamicBtn, column);
                            Grid.SetRow(dynamicBtn, row);

                            gridTable1.Children.Add(dynamicBtn);
                        }
                    }

                }
            }
        }
    }
}
