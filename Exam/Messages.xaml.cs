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
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Messages : Page
    {
        MedViewEntities medView = new MedViewEntities();
        public Messages()
        {
            InitializeComponent();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid1_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
         

            var query = from Уведомление in medView.Уведомление
                        join Сотрудник_предприятия in  medView.Сотрудник_предприятия on Уведомление.Код_сотрудника_предприятия equals Сотрудник_предприятия.Код_сотрудника
                        join Предприятие in medView.Предприятие on Сотрудник_предприятия.Код_предприятия equals Предприятие.Код_предприятия
                        join Поликлиника in medView.Поликлиника on Предприятие.Код_поликлиники equals Поликлиника.Код_поликлиники
                        join Сотрудники_поликлиники in medView.Сотрудники_поликлиники on Уведомление.Код_сотрудника_поликлиники equals Сотрудники_поликлиники.Код_сотрудника_поликлиники
                        
                        select new
                         {
                             Отправитель = Сотрудники_поликлиники.Фамилия + " " + Сотрудники_поликлиники.Имя + " " + Сотрудники_поликлиники.Отчество,
                             Получатель = Сотрудник_предприятия.Фамилия + " " + Сотрудник_предприятия.Имя + " " + Сотрудник_предприятия.Отчество,
                             ДатаОтправки = Уведомление.Дата_уведомления,
                             АдресДом = Сотрудник_предприятия.Домашний_адрес,
                             Адрес = Поликлиника.Адрес,
                             Телефон = Поликлиника.Телефон
                        };
        
            dataGrid1.ItemsSource = query.ToList();
            var query2 = from Перечень_кабинетов in medView.Перечень_кабинетов select new { Наименование = Перечень_кабинетов.Наименование, Номер = Перечень_кабинетов.Номер };
            datacabinets.ItemsSource = query2.ToList();

        }

      
    }
}
