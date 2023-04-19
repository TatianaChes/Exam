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

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (textLogin.Text.Equals("Пользователь") && textPassword.Password.Equals("пароль123"))
            {
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
            else {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
