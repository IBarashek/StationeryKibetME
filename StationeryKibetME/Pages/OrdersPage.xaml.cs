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
using StationeryKibetME.Pages;
using StationeryKibetME.Windows;
using StationeryKibetME.Classes;
using StationeryKibetME.DB;


namespace StationeryKibetME.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            CmbProduct.ItemsSource = ConnectionClass.entities.Product.Select(x => x.Name).ToList();
            CmbSeller.ItemsSource = ConnectionClass.entities.Seller.Select(x => x.Name).ToList();
            LstOrders.ItemsSource = ConnectionClass.entities.Order
                   .Where(x => x.IsDelete == false).ToList();
        }

        private void Arxiv_Click(object sender, RoutedEventArgs e)
        {
            var order = LstOrders.SelectedItem as Order;
            if (order != null)
            {
                MessageBoxResult messageResult = MessageBox.Show("Вы действительно хотите перенести в архив это заказ?", "Удаление", MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.Yes)
                {
                    Order DelOrder = ConnectionClass.entities.Order.Where(x => x.Id_Order == order.Id_Order).FirstOrDefault();
                    DelOrder.IsDelete = true;
                    ConnectionClass.entities.SaveChanges();
                    LstOrders.ItemsSource = ConnectionClass.entities.Order
                   .Where(x => x.IsDelete == false).ToList();
                }
            }
            else
            {
                MessageBox.Show("Для архивирования выберите заказ");
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            var order = LstOrders.SelectedItem as Order;
            if (order != null)
            {
                OrderInfoWindow window = new OrderInfoWindow(order);
                window.Show();
            }
            else
            {
                MessageBox.Show("Для просмотра информации выберите заказ");
            }
           
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MerchandisePage());
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow();
            window.Show();
        }

        private void SortProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            LstOrders.ItemsSource = ConnectionClass.entities.Order
                   .Where(x => x.IsDelete == false && x.Id_Product == CmbProduct.SelectedIndex + 2).ToList();
        }

        private void Date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstOrders.ItemsSource = ConnectionClass.entities.Order
                   .Where(x => x.IsDelete == false && x.DateOrder == DapDate.SelectedDate).ToList();
        }

        private void SortSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstOrders.ItemsSource = ConnectionClass.entities.Order
                   .Where(x => x.IsDelete == false && x.Id_Seller == CmbSeller.SelectedIndex + 2).ToList();
        }
    }
}
