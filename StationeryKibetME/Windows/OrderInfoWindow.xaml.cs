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
using StationeryKibetME.Classes;

using StationeryKibetME.DB;

namespace StationeryKibetME.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderInfoPage.xaml
    /// </summary>
    public partial class OrderInfoWindow : Window
    {
        Order order;
        public OrderInfoWindow(Order ord)
        {
            InitializeComponent();
            order = ord;
            TxbId.Text = order.Id_Order.ToString();
            TxbCount.Text = order.Count.ToString();
            TxbDate.Text = order.DateOrder.ToString();
            TxbPrice.Text = order.Price.ToString();
            TxbProduct.Text = ConnectionClass.entities.Product.Where(x => x.Id_Product == order.Id_Product).FirstOrDefault().Name;
            TxbSeller.Text = ConnectionClass.entities.Seller.Where(x => x.Id_Seller == order.Id_Seller).FirstOrDefault().Name;


        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Производится печать для заказа под номером: " + order.Id_Order);
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
