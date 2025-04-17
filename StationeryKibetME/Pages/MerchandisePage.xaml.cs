using StationeryKibetME.Classes;
using StationeryKibetME.DB;
using StationeryKibetME.Windows;
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

namespace StationeryKibetME.Pages
{
    /// <summary>
    /// Логика взаимодействия для MerchandisePage.xaml
    /// </summary>
    public partial class MerchandisePage : Page
    {
        Product product;
        public MerchandisePage()
        {
            InitializeComponent();
            LstProducts.ItemsSource = ConnectionClass.entities.Product
                    .Where(x => x.IsDelete == false).ToList();
            CmbStorage.ItemsSource = ConnectionClass.entities.Storage.Select(x => x.Name).ToList();

        }

        private void Add_Click(object sender, RoutedEventArgs e)

        {
            product = new Product();
            AddAndEditMerchandiseWindow window = new AddAndEditMerchandiseWindow(-1);
            window.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            product = LstProducts.SelectedItem as Product;
            if (product != null)
            {
                AddAndEditMerchandiseWindow window = new AddAndEditMerchandiseWindow(product.Id_Product);
                window.Show();
            }
            else
            {
                MessageBox.Show("Для обновления выберите товар");
            }
            
        }

        private void Arxiv_Click(object sender, RoutedEventArgs e)
        {
            var product = LstProducts.SelectedItem as Product;
            if (product != null)
            {
                MessageBoxResult messageResult = MessageBox.Show("Вы действительно хотите перенести в архив это товар?", "Удаление", MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.Yes)
                {
                    Product DelProduct = ConnectionClass.entities.Product.Where(x => x.Id_Product == product.Id_Product).FirstOrDefault();
                    DelProduct.IsDelete = true;
                    ConnectionClass.entities.SaveChanges();
                    LstProducts.ItemsSource = ConnectionClass.entities.Product
                   .Where(x => x.IsDelete == false).ToList();
                }
            }
            else
            {
                MessageBox.Show("Для архивирования выберите товар");
            }
        }

        private void BackToOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersPage());
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstProducts.ItemsSource = ConnectionClass.entities.Product
                  .Where(x => x.IsDelete == false && x.Name.Contains(TxbNameSearch.Text)).ToList();
        }

        private void StoragePick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstProducts.ItemsSource = ConnectionClass.entities.Product
                 .Where(x => x.IsDelete == false && CmbStorage.SelectedIndex + 1 == x.Id_Storage).ToList();
        }
    }
}
