using System.Windows;

namespace strona125
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

        private void changeText_Click(object sender, RoutedEventArgs e)
        {
            if (enableCheckBox.IsChecked == true)
            {
                if (labelToChange.HorizontalAlignment != HorizontalAlignment.Left)
                {
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Left;
                    labelToChange.Text = "Z lewej";
                }
                else if (labelToChange.HorizontalAlignment != HorizontalAlignment.Right)
                {
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Right;
                    labelToChange.Text = "Z prawej";
                }
            }
            else
            {
                labelToChange.Text = "Możliwość zmiany tekstu została wyłączona";
                labelToChange.HorizontalAlignment = HorizontalAlignment.Center;
            }
            
        }
    }
}
