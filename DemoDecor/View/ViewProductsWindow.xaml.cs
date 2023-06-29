using DemoDecor.Data;
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

namespace DemoDecor.View
{
    /// <summary>
    /// Логика взаимодействия для ViewProductsWindow.xaml
    /// </summary>
    public partial class ViewProductsWindow : Window
    {
        List<ProductTable> table;
        private int allDataCount = 0;
        private int previousIndex = 0;
        public ViewProductsWindow()
        {
            InitializeComponent();
        }

        private void LoadTable()
        {
            try
            {
                table = DataEntity.entity.baseEntities.ProductTable.OrderBy(name => name.Category).ToList();
                allDataCount = table.Count;
                countList.Text = $"{table.Count} из {allDataCount}";
                listDecor.ItemsSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных из базы данных: " + ex.Message, "Ошибка");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Вы действительно хотите выйти?", "Подтвердите действие", MessageBoxButton.YesNo);
            if(message == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderBy(table => table.Price - (table.Price * table.Discount / 100)).ToList();
            listDecor.ItemsSource = table;
        }

        private void resBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Сбросить сортировку?", "Подтвердите действие", MessageBoxButton.YesNo);
            if(message == MessageBoxResult.Yes)
            {
                table = table.OrderBy(table => table.Category).ToList();
                listDecor.ItemsSource = table;
            }
        }

        private void downBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderByDescending(table => table.Price - (table.Price * table.Discount / 100)).ToList();
            listDecor.ItemsSource = table;
        }

        private void categoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = categoryBox.SelectedIndex;

            if(table != null)
            {
                switch (selectedIndex)
                {
                    case 0:
                        table = DataEntity.entity.baseEntities.ProductTable.OrderBy(table => table.Category).ToList();
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        ComboBoxItem item = (ComboBoxItem)categoryBox.SelectedItem;
                        table = DataEntity.entity.baseEntities.ProductTable
                            .Where(table => table.Category == item.Content.ToString())
                            .OrderBy(table => table.Category)
                            .ToList();
                        break;
                }

                if (table.Count > 0)
                {
                    listDecor.ItemsSource = table;
                    previousIndex = selectedIndex;
                    countList.Text = $"{table.Count} из {allDataCount}";
                }
                else
                {
                    MessageBox.Show("В данной категории нет товаров.", "Предупреждение");
                    categoryBox.SelectedItem = previousIndex;
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }
    }
}
