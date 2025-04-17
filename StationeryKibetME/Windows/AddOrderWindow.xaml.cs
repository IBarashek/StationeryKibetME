using StationeryKibetME.Classes;
using StationeryKibetME.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StationeryKibetME.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            CmbProduct.ItemsSource = ConnectionClass.entities.Product.Select(x => x.Name).ToList();
            CmbSeller.ItemsSource = ConnectionClass.entities.Seller.Select(x => x.Name).ToList();
            this.DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string count = TxbCount.Text;
            string price = TxbPrice.Text;
            if (CmbProduct.SelectedItem != null && CmbSeller.SelectedItem != null
                && !String.IsNullOrEmpty(count) && !String.IsNullOrEmpty(price) && DapDate.SelectedDate != null)
            {
                AddEditClass.AddOrder(CmbProduct.SelectedIndex + 2 , CmbSeller.SelectedIndex + 2, Convert.ToInt32(count), Convert.ToInt32(price), (DateTime)DapDate.SelectedDate);
                MessageBox.Show("Заказ усппешно добавлен");
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
