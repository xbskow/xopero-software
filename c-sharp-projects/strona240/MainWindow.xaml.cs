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

namespace strona240
{

    public partial class MainWindow : Window
    {
        DinnerParty dinnerParty;
        public MainWindow()
        {
            InitializeComponent();

            dinnerParty = new DinnerParty() { NumberOfPeople = 5 };
            dinnerParty.SetHealthyOption(false);
            dinnerParty.CalculateCostOfDecorations(true);
            DisplayDinnerPartyCost();
        }

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(healthyBox.IsEnabled);
            costLabel.Content = Cost.ToString("c");
        }

        private void guestsLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            dinnerParty.NumberOfPeople = int.Parse(guestsLabel.Text);
            DisplayDinnerPartyCost();
        }

        private void fancyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.CalculateCostOfDecorations(fancyBox.IsEnabled);
            DisplayDinnerPartyCost();
        }

        private void healthyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyBox.IsEnabled);
            DisplayDinnerPartyCost();
        }
    }
}
