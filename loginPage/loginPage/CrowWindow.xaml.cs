using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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
    // =========================== He who touch this function ================================= //
    // ============ not in the Master's name will incur the wrath of the Crow Lord ============ //
    public partial class CrowWindow : Window
    {
        public CrowWindow()
        {
            InitializeComponent();
        }

        private async void crowBtn_Click(object sender, RoutedEventArgs e)
        {
            crowImage.Source = new BitmapImage(new Uri("Images/Crow/CrowCawing.jpg", UriKind.Relative));

            SoundPlayer crowSound = new SoundPlayer("Sounds/Crow.wav");
            crowSound.Load();
            crowSound.Play();

            await Task.Delay(500);
            crowImage.Source = new BitmapImage(new Uri("Images/Crow/Crow.jpg", UriKind.Relative));
        }
    }
}
