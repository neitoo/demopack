using DemoEasy.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace DemoEasy.View
{
    /// <summary>
    /// Логика взаимодействия для ListProductWindow.xaml
    /// </summary>
    public partial class ListProductWindow : Window
    {
        /// <summary>
        /// <param name="table">Список данных из БД</param>
        /// </summary>
        List<FEECHKI_VINKS> table;
        /// <summary>
        /// <param name="_AllDataCount">Счетчик всех страниц</param>
        /// </summary>
        private int _AllDataCount = 0;
        /// <summary>
        /// <param name="previousIndex">Сохранение предыдущего индекса в ComboBox</param>
        /// </summary>
        private int previousIndex = 0;
        public ListProductWindow()
        {
            InitializeComponent();
            table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.OrderBy(name => name.FullName).ToList();
            ListProd.ItemsSource = table;
            _AllDataCount = table.Count;

            countElem.Text = $"{table.Count} из {_AllDataCount}";
        }

        /// <summary>
        /// Метод кнопки фильтрации по возрастанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderBy(table => table.Price - (table.Price * table.Discount / 100)).ToList();
            ListProd.ItemsSource = table;
        }

        /// <summary>
        ///  Метод кнопки сброса фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Сбросить сортировку?", "Внимание", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                table = table.OrderBy(name => name.FullName).ToList();
                ListProd.ItemsSource = table;
            }

        }

        /// <summary>
        /// Метод нажатия кнопки фильтрации по убыванию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderByDescending(table => table.Price - (table.Price * table.Discount / 100)).ToList();
            ListProd.ItemsSource = table;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = shtro.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.OrderBy(name => name.FullName).ToList();
                        break;
                    }
                case 1:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 0 && name.Discount < 10).OrderBy(name => name.Discount).ToList();
                        break;
                    }
                case 2:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 10 && name.Discount < 15).OrderBy(name => name.Discount).ToList();
                        break;
                    }
                case 3:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 15).OrderBy(name => name.Discount).ToList();
                        break;
                    }
            }


            if(table.Count > 0)
            {
                ListProd.ItemsSource = table;
                previousIndex = selectedIndex;
                countElem.Text = $"{table.Count} из {_AllDataCount}";
            }
            else
            {
                MessageBox.Show("В данной категории нет данных.", "Предупреждение");
                shtro.SelectedIndex = previousIndex;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение действия", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            
        }
    }
}
