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
    }
}
