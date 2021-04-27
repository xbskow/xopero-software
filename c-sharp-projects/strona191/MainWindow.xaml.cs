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

namespace strona191
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int milesTraveled;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double rate = 0.39;
            decimal amountOwed;
            int startingMileage = int.Parse(startBox.Text);
            int endingMileage = int.Parse(finishBox.Text);
            if (endingMileage > startingMileage)
            {
                milesTraveled = endingMileage - startingMileage;
                amountOwed = milesTraveled * (decimal)rate;
                resultBlock.Text = amountOwed.ToString();
            }
            else
            {
                MessageBox.Show("Końcowy stan licznika musi być większy od początkowego.", "Błąd");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{milesTraveled} kilometrów", "Przebyta odległość");
        }
    }
}
