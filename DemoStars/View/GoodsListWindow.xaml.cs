using DemoStars.Data;
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

namespace DemoStars.View
{
    /// <summary>
    /// Логика взаимодействия для GoodsListWindow.xaml
    /// </summary>
    public partial class GoodsListWindow : Window
    {

        List<ShopStars> table;
        private int allDataCount = 0;
        private int previousIndex = 0;
        public GoodsListWindow()
        {
            InitializeComponent();

            table = DataEntity.dataEntity.starsEntities.ShopStars.OrderBy(name => name.fullName).ToList();
            listBrawler.ItemsSource = table;

            allDataCount = table.Count;

            countElem.Text = $"{table.Count} из {allDataCount}";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение действия", MessageBoxButton.YesNo);
            if(message == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderBy(table => table.price - (table.price * table.discount / 100)).ToList();
            listBrawler.ItemsSource = table;
        }

        private void resBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Cбросить сортировку?", "Внимание", MessageBoxButton.YesNo);
            if(message == MessageBoxResult.Yes)
            {
                table = table.OrderBy(table => table.fullName).ToList();
                listBrawler.ItemsSource = table;
            }
        }

        private void downBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderByDescending(table => table.price - (table.price * table.discount / 100)).ToList();
            listBrawler.ItemsSource = table;
        }

        private void discountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = discountComboBox.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    {
                        table = DataEntity.dataEntity.starsEntities.ShopStars.OrderBy(name => name.fullName).ToList();
                        break;
                    }
                case 1:
                    {
                        table = DataEntity.dataEntity.starsEntities.ShopStars
                            .Where(price => price.discount >= 0 && price.discount < 10)
                            .OrderBy(price => price.discount)
                            .ToList();
                        break;
                    }
                case 2:
                    {
                        table = DataEntity.dataEntity.starsEntities.ShopStars
                            .Where(price => price.discount >= 10 && price.discount < 15)
                            .OrderBy(price => price.discount)
                            .ToList();
                        break;
                    }
                case 3:
                    {
                        table = DataEntity.dataEntity.starsEntities.ShopStars
                            .Where(price => price.discount >= 15)
                            .OrderBy(price => price.discount)
                            .ToList();
                        break;
                    }
            }

            if(table.Count > 0)
            {
                listBrawler.ItemsSource = table;
                previousIndex = selectedIndex;
                countElem.Text = $"{table.Count} из {allDataCount}";
            }
            else
            {
                MessageBox.Show("В данной категории нет данных.", "Предупреждение");
                discountComboBox.SelectedIndex = previousIndex;
            }
        }
    }
}
