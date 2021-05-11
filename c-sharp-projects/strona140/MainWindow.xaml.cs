using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Media.Brush;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace strona140
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool start = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            start = !start;
            while(start && appWindow.IsActive)
            {
                for (int c = 0; c <= 254 && start; c++)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        appGrid.Background = new SolidColorBrush(Color.FromRgb((byte)c, (byte)(255 - c), (byte)c));
                        
                    }), DispatcherPriority.Background);
                    System.Threading.Thread.Sleep(3);
                }

                for (int c = 254; c >= 0 && start; c--)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        appGrid.Background = new SolidColorBrush(Color.FromRgb((byte)c, (byte)(255 - c), (byte)c));
                        
                    }), DispatcherPriority.Background);
                    System.Threading.Thread.Sleep(3);
                }
            }


        }
        
    }
}
