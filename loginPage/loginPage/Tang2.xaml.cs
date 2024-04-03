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




        string connectstring = @"Data Source=DESKTOP-BTLUTR6\SQLEXPRESS;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";
        public Tang2()
        {
            InitializeComponent();

            BanAnDAO banAnDAO = new BanAnDAO();

            banAnDAO.getBanAnTang2(gridTable2);
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

                if (clickedButton.Background == Brushes.LightSkyBlue)
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
