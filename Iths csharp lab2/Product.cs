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


        // Constructor
        public Product(string productName, double price)
        {
            ProductName = productName;
            Price = price;
            listWithProducts.Add(this);         
        }

        // Methods
        public override string ToString()
        {
            return ProductName + "     " + Price;
        }

        
    }
}
