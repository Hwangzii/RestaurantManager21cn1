using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    public partial class WhoAreYou : Window
    {
        public WhoAreYou()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(UDied_KeyDown);
        }
        
        // =========================== He who touch this function ================================= //
        // ============ not in the Master's name will incur the wrath of the Crow Lord ============ //
        async void UDied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string heWhoCanTouch = "Darth Zenn";
                string theChild = "Crowrrila";

                if (yourNamePlzTxtBox.Text == heWhoCanTouch)
                {
                    CrowWindow crowWindow = new CrowWindow();
                    crowWindow.Show();
                }
                else if (yourNamePlzTxtBox.Text == theChild)
                {
                    TheChild crowrrila = new TheChild();
                    crowrrila.Show();
                    SoundPlayer theChildSound = new SoundPlayer("Sounds/Crowrrila.wav");
                    theChildSound.Load();
                    theChildSound.Play();

                    await Task.Delay(4000);
                    crowrrila.Close();
                }
                else
                {
                    UDied youAreDead = new UDied();
                    youAreDead.Show();
                    SoundPlayer deathSound = new SoundPlayer("Sounds/Death.wav");
                    deathSound.Load();
                    deathSound.Play();

                    await Task.Delay(12000);
                    youAreDead.uDiedTxtBlock.Text = string.Empty;
                    youAreDead.thisImgWillKillU.Source = new BitmapImage(new Uri("Images/Crow/Alt.jpg", UriKind.Relative));

                    await Task.Delay(5000);
                    SoundPlayer altSound = new SoundPlayer("Sounds/Alt.wav");
                    altSound.Load();
                    altSound.Play();

                    await Task.Delay(15500);
                    youAreDead.Close();
                }
            }
        }
    }
}
