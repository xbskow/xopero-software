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

namespace strona201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Elephant lloyd = new Elephant() { Name = "Lloyd", EarSize = 40 };
        Elephant lucinda = new Elephant() { Name = "Lucinda", EarSize = 33 };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lloydBox_Click(object sender, RoutedEventArgs e)
        {
            lloyd.WhoAmI();
        }

        private void lucindaBox_Click(object sender, RoutedEventArgs e)
        {
            lucinda.WhoAmI();
        }

        private void swapBox_Click(object sender, RoutedEventArgs e)
        {
            Elephant lucindaBackup = new Elephant { Name = "Lucinda", EarSize = lucinda.EarSize };
            lucinda = lloyd;
            lloyd = lucindaBackup;
            MessageBox.Show("Obiekty zamienione.", "Wiadomość");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            lloyd.TellMe("Cześć", lucinda);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            lucinda.SpeakTo(lloyd, "Witaj");
        }
    }
}
