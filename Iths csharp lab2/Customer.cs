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
        private string _totalPrice;
        private List<Product> _shoppingCart;

        /// <summary>
        /// Initalize a new customer with username, password shoppingcart and add customer to list with customers..
        /// </summary>
        /// <param name="userName">Customers username</param>
        /// <param name="password">Customers password</param>
        public Customer(string userName, string password)
        {
            if (IsNewCustomer(userName))
            {
                _userName = userName;
                _password = password;
                _shoppingCart = new List<Product>();
                
            }
            else
            {
                Console.WriteLine("\nThis customer already exists. Try different username or password.");
                Console.ReadKey();
            }
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

        public double TotalPrice { get; set; }

        public List<Product> ShoppingCart
        {
            get { return _shoppingCart; }

        }

        public static List<Customer> ListWithMembers = new List<Customer>();

 
       // Methods
       
        /// <summary>
        /// Iterates trough list to see if customer is a new customer.
        /// </summary>
        /// <param name="userName">Username to control.</param>
        /// <returns>true if user is new user and false if username exists.</returns>
        private bool IsNewCustomer(string userName)
        {
            foreach (Customer customer in ListWithMembers)
            {
               if (customer.UserName == userName)
               {
                    return false;
               }                    
            }
            return true;
        }

        /// <summary>
        /// Returns a string with users username, password and cart.
        /// </summary>
        /// <returns>string with users username, password and cart.</returns>
        public override string ToString()
        {
            string user = $"Username: {UserName}\nPassword: {Password}\nCart:\n";
            string inCart = string.Join("\n", ShoppingCart.Select(product => product.ToString()));
            return user + "\n" + inCart + "\n\n****************************\n";
        }


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
