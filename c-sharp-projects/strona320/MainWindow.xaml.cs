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

namespace strona320
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queen queen;
        public MainWindow()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" }, 175);
            workers[1] = new Worker(new string[] { "Pielęgnacja jaj", "Nauczanie pszczółek" }, 114);
            workers[2] = new Worker(new string[] { "Utrzymywanie ula", "Patrol z żądłami" }, 149);
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymywanie ula", "Patrol z żądłami" }, 155);
            queen = new Queen(workers, 275);
        }

        private void assignButton_Click(object sender, RoutedEventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, int.Parse(shifts.Text)) == true)
                MessageBox.Show($"Nie ma dostępnych robotnic do wykonania zadania '{workerBeeJob.Text}'", "Królowa pszczół mówi...");
            else
                MessageBox.Show($"Zadanie '{workerBeeJob.Text}' będzie ukończone za {shifts.Text} zmiany", "Królowa pszczół mówi...");
        }

        private void nextShift_Click(object sender, RoutedEventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
