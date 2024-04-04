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

        public Tang1()
        {
            InitializeComponent();
            
            BanAnDAO banAnDAO = new BanAnDAO();

            banAnDAO.getBanAnTang1(gridTable1);
        }

        // Phương thức để kích hoạt sự kiện DynamicButtonClicked
        protected virtual void OnDynamicButtonClicked(EventArgs e)
        {
            DynamicButtonClicked?.Invoke(this, e);
        }
    }
}
