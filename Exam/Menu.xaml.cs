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
using System.Windows.Shapes;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Оповещение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Messages());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Comission());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new MainInfo());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Reporter());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
