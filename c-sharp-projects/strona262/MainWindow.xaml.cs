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

namespace strona262
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Farmer farmer;
        public MainWindow()
        {
            InitializeComponent();
            farmer = new Farmer(15, 30);
        }

        private void numberOfCowsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(numberOfCowsBox.Text, out _)) farmer.NumberOfCows = int.Parse(numberOfCowsBox.Text);
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Potrzebuję {farmer.BagsOfFeed} worków paszy do wykarmienia {farmer.NumberOfCows} krów");
        }
    }
}
