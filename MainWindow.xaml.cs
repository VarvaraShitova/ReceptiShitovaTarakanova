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

namespace ReceptiShitovaTarakanova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MoyaRamka.Navigate(new Pages.PageBluda());
        }

        private void BVihod_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BBluda_Click(object sender, RoutedEventArgs e)
        {
            MoyaRamka.Navigate(new Pages.PageBluda());
        }

        private void BIngredients_Click(object sender, RoutedEventArgs e)
        {
            MoyaRamka.Navigate(new Pages.PageIngredient());
        }
    }
}
