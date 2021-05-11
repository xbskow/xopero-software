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
        int people = 5;
        public MainWindow()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty();
            dinnerParty.SetPartyOptions(people, false);
            guestsLabel.Text = dinnerParty.GetNumberOfPeople().ToString();
            dinnerParty.CalculateCostOfDecorations(false);
            healthyBox.IsChecked = true;
            dinnerParty.SetHealthyOption(true);

            DisplayDinnerPartyCost();
        }

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost((bool) healthyBox.IsChecked);
            costLabel.Content = Cost.ToString("c");
        }

        private void guestsLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(guestsLabel.Text, out int _)) {
                people = int.Parse(guestsLabel.Text);
                dinnerParty.SetPartyOptions(people, (bool) fancyBox.IsChecked);
                DisplayDinnerPartyCost();
            }

        }

        private void fancyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.SetPartyOptions(people, (bool) fancyBox.IsChecked);
            DisplayDinnerPartyCost();
        }

        private void healthyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.SetHealthyOption((bool) healthyBox.IsChecked);
            DisplayDinnerPartyCost();
        }
    }
}
