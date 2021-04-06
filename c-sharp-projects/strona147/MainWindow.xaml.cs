using System.Windows;

namespace strona147
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int len = Talker.BlahBlahBlah(stringText.Text, int.Parse(intText.Text));
            MessageBox.Show($"Długość wiadomości to: {len}");
        }
    }
}
