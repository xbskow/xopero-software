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

namespace strona277
{

    public partial class MainWindow : Window
    {
        DinnerParty dinnerParty;
        BirthdayParty birthdayParty;
        public MainWindow()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty(5, true, false);
            birthdayParty = new BirthdayParty(5, false, "Sto lat!");
            fancyBox.IsChecked = false;
            healthyBox.IsChecked = true;
            healthyBox.Content = "Opcja zdrowa";
            guestsLabel.Text = "5";
            cakeWriting.Text = "Sto lat!";
            fancyBirthday.IsChecked = false;

            DisplayDinnerPartyCost();
            DisplayBirthdayPartyCost();
        }

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.Cost;
            costLabel.Content = Cost.ToString("c");
        }

        private void guestsLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(guestsLabel.Text, out _))
            {
                dinnerParty.NumberOfPeople = int.Parse(guestsLabel.Text);
                DisplayDinnerPartyCost();
            }
        }
        private void numberBirthday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(numberBirthday.Text, out _))
            {
                birthdayParty.NumberOfPeople = int.Parse(numberBirthday.Text);
                DisplayBirthdayPartyCost();
            }
        }

        private void fancyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.FancyDecorations = (bool)fancyBox.IsChecked;
            DisplayDinnerPartyCost();
        }

        private void healthyBox_Checked(object sender, RoutedEventArgs e)
        {
            dinnerParty.HealthyOption = (bool)fancyBox.IsChecked;
            DisplayDinnerPartyCost();
        }

        private void fancyBirthday_Checked(object sender, RoutedEventArgs e)
        {
            birthdayParty.FancyDecorations = (bool)fancyBirthday.IsChecked;
            DisplayBirthdayPartyCost();
        }

        private void cakeWriting_TextChanged(object sender, TextChangedEventArgs e)
        {
            birthdayParty.CakeWriting = cakeWriting.Text;
            DisplayBirthdayPartyCost();
        }

        private void DisplayBirthdayPartyCost()
        {
            tooLongLabel.IsEnabled = birthdayParty.CakeWritingTooLong;
            decimal cost = birthdayParty.Cost;
            birthdayCost.Content = cost.ToString("c");
        }
    }
}
