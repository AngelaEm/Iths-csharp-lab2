using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class Product
    {
        // Fields
        private string _productName;
        private double _price;
        

        // Properties
        public string ProductName { get { return _productName; } private set { _productName = value; } }
        public double Price { get { return _price; } private set { _price = value; } }


        // List
        public static List<Product> listWithProducts = new List<Product>();


        /// <summary>
        /// Initalize a new product with productname and price and add product to list.
        /// </summary>
        /// <param name="productName">Name of the product</param>
        /// <param name="price">Price of the product</param>
        public Product(string productName, double price)
        {
            ProductName = productName;
            Price = price;
            listWithProducts.Add(this);         
        }


        /// <summary>
        /// Adds product to customers cart and updates totalPrice.
        /// </summary>
        /// <param name="member">The logged in member</param>
        public void AddToCart(Member member)
        {
            // Add products to members cart
            member.GetCart().Add(this);

            // Increase totalPrice
            member.TotalPrice += Price;

            Console.WriteLine($"\n\tAdded to cart.\tTotal price: {Math.Round(member.TotalPrice, 2)} SEK");
            Console.WriteLine("\tPress enter to continue.");
            Console.ReadKey();

            MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));

        }


        /// <summary>
        /// Displays information about product
        /// </summary>
        /// <returns>Product name and price</returns>
        public override string ToString()
        {
            return ProductName + "     " + Price;
        }      
    }
}
