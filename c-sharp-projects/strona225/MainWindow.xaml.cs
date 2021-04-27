using System;
using System.Collections.Generic;
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

namespace strona225
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomizer = new Random();
        Guy janek, bartek, arek;

        public MainWindow()
        {
            InitializeComponent();
            janek = new Guy()
            {
                Name = "Janek",
                Cash = 50,
                MyRadioButton = janekRadioButton,
                MyLabel = janekBetLabel
            };
            bartek = new Guy()
            {
                Name = "Bartek",
                Cash = 75,
                MyRadioButton = bartekRadioButton,
                MyLabel = bartekBetLabel
            };
            arek = new Guy()
            {
                Name = "Arek",
                Cash = 45,
                MyRadioButton = arekRadioButton,
                MyLabel = arekBetLabel
            };

            Guy[] guys = new Guy[] { janek, bartek, arek };
            foreach (Guy guy in guys)
            {
                guy.ClearBet();
            }

            Greyhound[] dogs = new Greyhound[4];
            dogs[0] = new Greyhound() {
                MyPictureBox = image1,
                StartingPosition = (int)image1.Margin.Left,
                RacetrackLength = (int)racetrackPictureBox.Width - (int)image1.Width,
                MyRandom = randomizer };
            dogs[1] = new Greyhound() {
                MyPictureBox = image2,
                StartingPosition = (int)image2.Margin.Left,
                RacetrackLength = (int)racetrackPictureBox.Width - (int)image2.Width,
                MyRandom = randomizer };
            dogs[2] = new Greyhound() {
                MyPictureBox = image3,
                StartingPosition = (int)image3.Margin.Left,
                RacetrackLength = (int)racetrackPictureBox.Width - (int)image3.Width,
                MyRandom = randomizer };
            dogs[3] = new Greyhound() {
                MyPictureBox = image4,
                StartingPosition = (int)image4.Margin.Left,
                RacetrackLength = (int)racetrackPictureBox.Width - (int)image4.Width,
                MyRandom = randomizer };
        }

        private void janekRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //nameText.Content = janek.Name;
        }
    }
}
