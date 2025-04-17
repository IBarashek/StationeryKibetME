using StationeryKibetME.DB;
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
using StationeryKibetME.Pages;
using StationeryKibetME.Windows;
using StationeryKibetME.Classes;

namespace StationeryKibetME.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditMerchandiseWindow.xaml
    /// </summary>
    public partial class AddAndEditMerchandiseWindow : Window
    {
        Product product;
        public AddAndEditMerchandiseWindow(int idProduct)
        {
           
            InitializeComponent(); 
            CmbStorage.ItemsSource = ConnectionClass.entities.Storage.Select(x => x.Name).ToList();
            product = ConnectionClass.entities.Product.Where(x => x.Id_Product == idProduct).FirstOrDefault();
            if (product != null)
            {
                TxbName.Text = product.Name;
                TxbCount.Text = product.Remains.ToString();
                CmbStorage.SelectedIndex = product.Id_Storage - 1;
            }
            
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string name = TxbName.Text;
            string count = TxbCount.Text;
            if (CmbStorage.SelectedItem != null && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(count))
            {
                if(product != null)
                {
                    product.Name = name;
                    product.Remains = Convert.ToInt32(count);
                    product.Id_Storage = CmbStorage.SelectedIndex + 1;
                    ConnectionClass.entities.SaveChanges();
                    MessageBox.Show("Успешно изменен");
                }
                else
                {
                    AddEditClass.AddProduct(name, count, CmbStorage.SelectedIndex + 1);
                    MessageBox.Show("Успешно добавлен");
                }
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
