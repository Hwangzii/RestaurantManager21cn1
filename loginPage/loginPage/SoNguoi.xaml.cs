using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for SoNguoi.xaml
    /// </summary>
    public partial class SoNguoi : Window
    {
        private ConfigurationData m_data;


        public class ConfigurationData : INotifyPropertyChanged
        {
            private int _BaudRate;
            public int BaudRate
            {
                get { return _BaudRate; }
                set { _BaudRate = value; OnPropertyChanged("BaudRate"); }
            }

            //below is the boilerplate code supporting PropertyChanged events:
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }

        public SoNguoi()
        {
            InitializeComponent();
            m_data = new ConfigurationData();
            this.DataContext = m_data;  // This is the glue that connects the
                                        // textbox to the object instance    

        }



    }
}
