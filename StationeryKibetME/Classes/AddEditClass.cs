using StationeryKibetME.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryKibetME.Classes
{
    class AddEditClass
    {
        public static void AddProduct(string name, string count, int idStorage)
        {
            Product product = new Product()
            {
                Name = name,
                Id_Storage = idStorage,
                Remains = Convert.ToInt32(count),
                IsDelete = false
            };
            ConnectionClass.entities.Product.Add(product);
            ConnectionClass.entities.SaveChanges();
            

        }
        public static void AddOrder(int idProduct, int idSeller, int count, int price, DateTime date)
        {
            Order order = new Order()
            {
                Id_Product = idProduct,
                Id_Seller = idSeller,
                Price = price,
                Count = count,
                DateOrder = date,
                IsDelete = false
            };
            ConnectionClass.entities.Order.Add(order);
            ConnectionClass.entities.SaveChanges();


        }
    }
}
