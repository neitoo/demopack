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
using DemoEasy.Data;


namespace DemoEasy.View
{
    /// <summary>
    /// Логика взаимодействия для ListProductWindow.xaml
    /// </summary>
    public partial class ListProductWindow : Window
    {
        List<FEECHKI_VINKS> table;
        private int _AllDataCount = 0;
        public ListProductWindow()
        {
            InitializeComponent();
            table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.OrderBy(name => name.FullName).ToList();
            ListProd.ItemsSource = table;
            _AllDataCount = table.Count;

            countElem.Text = $"{table.Count} из {_AllDataCount}";
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderBy(table => table.Price).ToList();
            ListProd.ItemsSource = table;
        }

        private void resBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderBy(name => name.FullName).ToList();
            ListProd.ItemsSource = table;

        }

        private void downBtn_Click(object sender, RoutedEventArgs e)
        {
            table = table.OrderByDescending(table => table.Price).ToList();
            ListProd.ItemsSource = table;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (shtro.SelectedIndex)
            {
                case 0:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.OrderBy(name => name.FullName).ToList();
                        ListProd.ItemsSource = table;
                        countElem.Text = $"{table.Count} из {_AllDataCount}";
                        break;
                    }
                case 1:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 0 && name.Discount < 10).OrderBy(name => name.Discount).ToList();
                        ListProd.ItemsSource = table;
                        countElem.Text = $"{table.Count} из {_AllDataCount}";
                        break;
                    }
                case 2:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 10 && name.Discount < 15).OrderBy(name => name.Discount).ToList();
                        ListProd.ItemsSource = table;
                        countElem.Text = $"{table.Count} из {_AllDataCount}";
                        break;
                    }
                case 3:
                    {
                        table = DatabaseEntity.DBEntity.WinxEnt.FEECHKI_VINKS.Where(name => name.Discount >= 15).OrderBy(name => name.Discount).ToList();
                        ListProd.ItemsSource = table;
                        countElem.Text = $"{table.Count} из {_AllDataCount}";
                        break;
                    }
            }
        }
    }
}
