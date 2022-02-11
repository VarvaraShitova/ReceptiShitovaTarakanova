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
using ReceptiShitovaTarakanova.Classes;
using ReceptiShitovaTarakanova.Pages;


namespace ReceptiShitovaTarakanova.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageIngredient.xaml
    /// </summary>
    public partial class PageIngredient : Page
    {
        int _currentPage = 1, _countInPage = 5, _maxPages;
        public PageIngredient()
        {
            InitializeComponent();
            ObnovlDannih();
        }
        private void ObnovlDannih()
        {
            List<Ingredient> listIngredients =Classes.DB.db.Ingredient.ToList();
            _maxPages = (int)Math.Ceiling(listIngredients.Count * 1.0 / _countInPage);
            DGIngredients.ItemsSource = listIngredients.Skip((_currentPage - 1) * _countInPage).Take(_countInPage);
            LName.Content = $"{listIngredients.Count} наименований";
            LZapas.Content = $"Запасов в холодильнике на сумму (руб):{listIngredients.Sum(ingr => (double)ingr.Cost / ingr.CostForCount * ingr.AvailableCount):N2}";
            LSrtIzStr.Content = $"{_currentPage}/{_maxPages}";
            if (_currentPage == 1)
            {
                BTNPervStr.IsEnabled = false;
                BTNPredStr.IsEnabled = false;
            }
            else
            {
                BTNPervStr.IsEnabled = true;
                BTNPredStr.IsEnabled = true;
            }
            if (_currentPage == _maxPages)
            {
                BTNPoslStr.IsEnabled = false;
                BTNSledStr.IsEnabled = false;
            }
            else
            {
                BTNPoslStr.IsEnabled = true;
                BTNSledStr.IsEnabled = true;
            }

        }


        private void BTNPervStr_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            ObnovlDannih();

        }

        private void BTNPredStr_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            ObnovlDannih();

        }

        private void HLinkEdit_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedIngredient = (sender as Hyperlink).DataContext as Ingredient;
            NavigationService.Navigate(new PageAddIngredient(selectedIngredient));
        }

        private void HLinkDel_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedIngredient = (sender as Hyperlink).DataContext as Ingredient;
            DB.db.Ingredient.Remove(selectedIngredient);
            DB.db.SaveChanges();
            ObnovlDannih();
            MessageBox.Show("Ингредиент удален");
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddIngredient());
        }

        private void BTNSledStr_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            ObnovlDannih();

        }

        private void BTNPoslStr_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPages;
            ObnovlDannih();

        }
    }
}
