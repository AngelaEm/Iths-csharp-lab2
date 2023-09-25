using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;


namespace Iths_csharp_lab2
{
   
    internal class Program
    {
        static List<Customer> ListWithCustomers;


        static void Main(string[] args)
        {
            string FileName = "C:\\Users\\Angela\\source\\repos\\Iths csharp lab2\\Iths csharp lab2\\SavedUsers.txt";
            ListWithCustomers = UploadCustomersFromTextFile(FileName);
            Start();
                
            MainMenuOptions.MainMenu();
        }


        /// <summary>
        /// Displays welcome message and initalizes three customers and four products at start.
        /// </summary>
        static void Start()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.WriteLine("********************************\n");
            Console.WriteLine("Welcome to this awesome webshop!");
            Console.WriteLine("\n********************************\n");
            Console.WriteLine("Press enter to get to the menu.");

            Console.ReadKey();
            Console.ResetColor();

            Customer kund1 = new Customer("Knatte", "123");
            Customer kund2 = new Customer("Fnatte", "321");
            Customer kund3 = new Customer("Tjatte", "213");

            Product redBull = new Product("Red Bull", 13.95);
            Product colaZero = new Product("Cola Zero", 9.95);
            Product afterEight = new Product("After Eight", 49);
            Product tuttiFrutti = new Product("Ice cream", 19.50);

        }

        /// <summary>
        /// Gets customers that are saved in textfile.
        /// </summary>
        /// <param name="fileName">Name of textfile to read from</param>
        /// <returns>A list of Customers saved in file</returns>
        static List<Customer> UploadCustomersFromTextFile(string fileName)
        {
            List<Customer> customersInFile = new List<Customer>();

            // Read all lines from textfile.
            string[] lines = File.ReadAllLines(fileName);

            // Iterates trough each line 
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // Where to split the userData
                    string[] userData = line.Split(',');

                    // To make sure there is both username and password
                    if (userData.Length == 2)
                    {
                        string userName = userData[0];
                        string password = userData[1];

                        // CreateComInterfaceFlags a customer and add to list.
                        Customer customer = new Customer(userName, password);
                        customersInFile.Add(customer);
                    }
                }
            }

            return customersInFile;

        }


    }
}

       

    
