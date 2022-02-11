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

namespace ReceptiShitovaTarakanova.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddIngredient.xaml
    /// </summary>
    public partial class PageAddIngredient : Page
    {
        Ingredient currentIngredient;
        public PageAddIngredient()
        {
            InitializeComponent();
            BTNEdit.Visibility = Visibility.Collapsed;
            currentIngredient = new Ingredient();
            this.DataContext = currentIngredient;
            FillComboboxUnit();

        }
        public PageAddIngredient(Ingredient ingredient )
        {
            InitializeComponent();
            BTNAdd.Visibility = Visibility.Collapsed;
            currentIngredient = ingredient;
            this.DataContext = currentIngredient;
            Title = "Редактировать ингредиент";
            FillComboboxUnit();
        }
        public void FillComboboxUnit()
        {
            CBEdIzmer.ItemsSource = DB.db.Unit.ToList();
            CBEdIzmer.SelectedIndex = 0;
        }
        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            DB.db.Ingredient.Add(currentIngredient);
            DB.db.SaveChanges();
            NavigationService.Navigate(new Pages.PageIngredient());

        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            DB.db.SaveChanges();
            NavigationService.Navigate(new Pages.PageIngredient());

        }

        private void BTNOtmena_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // переход на предыдущую страницу

        }
    }
}
