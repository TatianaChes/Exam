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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MedViewEntities medView = new MedViewEntities();
        public Registration()
        {
            InitializeComponent();
           

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            medView.Уведомление.Add(new Уведомление()
            {
                Код_уведомления = medView.Уведомление.Count() + 1,
                 Дата_уведомления = (DateTime)date.SelectedDate,
                Код_сотрудника_поликлиники = employee.SelectedIndex + 1,
                Код_сотрудника_предприятия = secretar.SelectedIndex + 1
            }) ;
            medView.SaveChanges();
            MessageBox.Show("Создано!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employee.ItemsSource = medView.Сотрудник_предприятия.ToList();
            secretar.ItemsSource = medView.Сотрудники_поликлиники.ToList();
        }
    }
}
