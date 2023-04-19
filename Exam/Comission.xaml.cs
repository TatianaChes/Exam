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
    /// Логика взаимодействия для Comission.xaml
    /// </summary>
    public partial class Comission : Page
    {
        MedViewEntities medView = new MedViewEntities();
        public Comission()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var queryPre = from Сотрудник_предприятия in medView.Сотрудник_предприятия select new {
                Фамилия = Сотрудник_предприятия.Фамилия,
                Имя = Сотрудник_предприятия.Имя,
                Отчество = Сотрудник_предприятия.Отчество
            };
            var queryPost = from Сотрудник_предприятия in medView.Сотрудник_предприятия
                            join Мед_карта in medView.Мед_карта on Сотрудник_предприятия.Код_мед_карты equals Мед_карта.Код_мед_карты
                            join Мед_комиссия in medView.Мед_комиссия on Мед_карта.Код_мед_карты equals Мед_комиссия.Код_мед_карты
                            join Осмотр in medView.Осмотр on Мед_комиссия.Код_осмотра equals Осмотр.Код_осмотра
                            join Результат in medView.Результат on Осмотр.Код_результата equals Результат.Код_результата
                            join Сотрудники_поликлиники in medView.Сотрудники_поликлиники on Результат.Код_врача equals Сотрудники_поликлиники.Код_сотрудника_поликлиники
                            join Должность in medView.Должность on Сотрудники_поликлиники.Код_должности equals Должность.Код_должности
                            select new
                            {
                                Фамилия = Сотрудник_предприятия.Фамилия,
                                Имя = Сотрудник_предприятия.Имя,
                                Отчество = Сотрудник_предприятия.Отчество

                            };
            var queryGoal = queryPre.Except(queryPost);
            dataGrid2.ItemsSource = queryGoal.ToList();


            var query = from Сотрудник_предприятия in medView.Сотрудник_предприятия
                        join Мед_карта in medView.Мед_карта on Сотрудник_предприятия.Код_мед_карты equals Мед_карта.Код_мед_карты
                        join Мед_комиссия in medView.Мед_комиссия on Мед_карта.Код_мед_карты equals Мед_комиссия.Код_мед_карты
                        join Осмотр in medView.Осмотр on Мед_комиссия.Код_осмотра equals Осмотр.Код_осмотра
                        join Результат in medView.Результат on Осмотр.Код_результата equals Результат.Код_результата
                        join Сотрудники_поликлиники in medView.Сотрудники_поликлиники on Результат.Код_врача equals Сотрудники_поликлиники.Код_сотрудника_поликлиники
                        join Должность in medView.Должность on Сотрудники_поликлиники.Код_должности equals Должность.Код_должности
                        select new {
                            Сотрудник = Сотрудник_предприятия.Фамилия + " " + Сотрудник_предприятия.Имя + " " + Сотрудник_предприятия.Отчество,
                              Мед_карта = Мед_карта.Номер,
                              Дата_прохождения = Осмотр.Дата_прохождения,
                              Процедура = Результат.Наименование,
                              Результат = Результат.Допуск,
                              Врач = Сотрудники_поликлиники.Имя + " "+
                            Сотрудники_поликлиники.Фамилия + " "+
                            Сотрудники_поликлиники.Отчество,
                            Должность = Должность.Наименование

                        };
            dataGrid.ItemsSource = query.ToList();
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            var query = from Сотрудник_предприятия in medView.Сотрудник_предприятия
                        join Мед_карта in medView.Мед_карта on Сотрудник_предприятия.Код_мед_карты equals Мед_карта.Код_мед_карты
                        join Мед_комиссия in medView.Мед_комиссия on Мед_карта.Код_мед_карты equals Мед_комиссия.Код_мед_карты
                        join Осмотр in medView.Осмотр on Мед_комиссия.Код_осмотра equals Осмотр.Код_осмотра
                        join Результат in medView.Результат on Осмотр.Код_результата equals Результат.Код_результата
                        join Сотрудники_поликлиники in medView.Сотрудники_поликлиники on Результат.Код_врача equals Сотрудники_поликлиники.Код_сотрудника_поликлиники
                        join Должность in medView.Должность on Сотрудники_поликлиники.Код_должности equals Должность.Код_должности
                        where Осмотр.Дата_прохождения >= datapicker1.SelectedDate && Осмотр.Дата_прохождения <= datapicker2.SelectedDate
                        select new
                        {
                            Сотрудник = Сотрудник_предприятия.Фамилия + " " + Сотрудник_предприятия.Имя + " " + Сотрудник_предприятия.Отчество,
                            Мед_карта = Мед_карта.Номер,
                            Дата_прохождения = Осмотр.Дата_прохождения,
                            Процедура = Результат.Наименование,
                            Результат = Результат.Допуск,
                            Врач = Сотрудники_поликлиники.Имя + " " +
                            Сотрудники_поликлиники.Фамилия + " " +
                            Сотрудники_поликлиники.Отчество,
                            Должность = Должность.Наименование

                        };
            dataGrid.ItemsSource = query.ToList();
        }

       
    }
}
