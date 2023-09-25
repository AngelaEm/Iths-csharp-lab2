using Iths_csharp_lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class Customer
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
                ListWithCustomers.Add(this);

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

        private static List<Customer> ListWithCustomers = new List<Customer>();

 
       
        
        
        /// <summary>
        /// Iterates trough list to see if customer is a new customer.
        /// </summary>
        /// <param name="userName">Username to control.</param>
        /// <returns>true if user is new user and false if username exists.</returns>
        private bool IsNewCustomer(string userName)
        {
            foreach (Customer customer in ListWithCustomers)
            {
               if (customer.UserName == userName)
               {
                    return false;
               }                    
            }
            return true;
        }


        /// <summary>
        /// Controls if username matches password and let customer log in if they match.
        /// </summary>
        /// <param name="userName">Name of the customer.</param>
        /// <param name="password">Password of the customer.</param>
        /// <returns>Customer if username and password match and null if they dont match.</returns>
        public static Customer LogIn(string userName, string password)
        {
            
            foreach (Customer customer in ListWithCustomers)
            {
                if (customer.UserName == userName && customer.Password == password)
                {
                    Console.WriteLine($"\nWelcome {customer.UserName}!");
                    Console.ReadKey();
                    return customer;
                }
            }
            Console.WriteLine($"\nSorry {userName}. Username and password dont match.\n");
            return null;
        }


       


        /// <summary>
        /// Displays all customers, their passwords and their cart.
        /// </summary>
        public static void PrintAllCustomers()
        {
            foreach (Customer customer in ListWithCustomers)
            {
                
                Console.WriteLine(customer.ToString()); 
                
            }
            Console.ReadKey();
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
