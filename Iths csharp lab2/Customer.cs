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


        // Properties
        public string UserName { get { return _userName; } private set { _userName = value; } }

        public string Password { get { return _password; } private set { _password = value; } }

        public double TotalPrice { get; set; }

        // Lists
        private List<Product> Cart = new List<Product>();

        private static List<Customer> ListWithCustomers = new List<Customer>();  


        // Constructor
        public Customer(string userName, string password)
        { 
            if(IsNewCustomer(userName))
            {
                UserName = userName;
                Password = password;
                Cart = new List<Product>();
                ListWithCustomers.Add(this);

            }
            else
            {
                Console.WriteLine("\nThis customer already exists. Try different username or password.");
                Console.ReadKey();
            }

        }
        
        
        // Methods
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

        public static void PrintAllCustomers()
        {
            foreach (Customer customer in ListWithCustomers)
            {
                
                Console.WriteLine(customer.ToString()); 
                
            }
            Console.ReadKey();
        }

        public override string ToString()
        {
            string user = $"Username: {UserName}\nPassword: {Password}\nCart:\n";
            string inCart = string.Join("\n", Cart.Select(product => product.ToString()));
            return user + "\n" + inCart + "\n\n****************************\n";
        }

        public List<Product> GetCart()
        {
            return Cart;
        }
      
        public static Customer GetCustomer(string userName, string password)
        {
            foreach (Customer customer in ListWithCustomers)
            {
                if (customer.UserName == userName && customer.Password == password)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
