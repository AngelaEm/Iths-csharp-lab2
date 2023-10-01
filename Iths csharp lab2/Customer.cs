using Iths_csharp_lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iths_csharp_lab2
{
    internal abstract class Customer
    {
        // Fields
        private string _userName;
        private string _password;
        private double _totalPrice = 0;
        private List<Product> _shoppingCart;


        // Constructor
        public Customer(string userName, string password)
        {
            _userName = userName;
            _password = password;
            _shoppingCart = new List<Product>();

        }

        // Properties
        public string UserName
        {
            get { return _userName; }
            private set { _userName = value; }
        }
        
        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public List<Product> ShoppingCart
        {
            get { return _shoppingCart; }

        }

        // List with customers
        public static List<Customer> ListWithCustomers = new List<Customer>();


        
        /// <summary>
        /// Get the customers shopping cart.
        /// </summary>
        /// <returns>A list with products.</returns>
        public List<Product> GetCart()
        {
            return ShoppingCart;
        }             
    }
}
