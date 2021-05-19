using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace strona477
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Guy joe;
        Guy bob;
        int bank = 100;

        public void UpdateForm()
        {
            joesCashLabel.Text = $"{joe.Name} ma {joe.Cash} zł";
            bobsCashLabel.Text = $"{bob.Name} ma {bob.Cash} zł";
            bankCashLabel.Text = $"Bank ma {bank} zł";
        }

        public MainWindow()
        {
            InitializeComponent();

            joe = new Guy() { Name = "Joe", Cash = 50 };
            bob = new Guy() { Name = "Bob", Cash = 100 };

            UpdateForm();
        }

        private void bankGivesToJoe_Click(object sender, RoutedEventArgs e)
        {
            if (bank >= 10)
            {
                bank -= joe.ReceiveCash(10);
                UpdateForm();
            }
            else
            {
                MessageBox.Show("Bank nie posiada takiej ilości pieniędzy");
            }
        }

        private void bankTakesfromBob_Click(object sender, RoutedEventArgs e)
        {
            bank += bob.GiveCash(5);
            UpdateForm();
        }

        private void joeGivesToBob_Click(object sender, RoutedEventArgs e)
        {
            bob.ReceiveCash(joe.GiveCash(10));
            UpdateForm();
        }

        private void bobGivesToJoe_Click(object sender, RoutedEventArgs e)
        {
            joe.ReceiveCash(bob.GiveCash(5));
            UpdateForm();
        }

        private void saveJoe_Click(object sender, RoutedEventArgs e)
        {
            using (Stream output = File.Create("Plik_faceta.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, joe);
            }
        }

        private void loadJoe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Stream input = File.OpenRead("Plik_faceta.dat"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    joe = (Guy)formatter.Deserialize(input);
                }
                UpdateForm();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nie znaleziono pliku.", "Ostrzeżenie");
            }

        }
    }
}
