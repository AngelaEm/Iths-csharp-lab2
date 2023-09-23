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
        static void Main(string[] args)
        {
            Start();
            MainMenu();
        }

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
            Product tuttiFrutti = new Product("Tutti Frutti", 19.50);

        }

        static void MainMenu()
        {

            int menuSelected = 0;
            bool isRunning = true;
            (int left, int top) = Console.GetCursorPosition();
            string color = "\u001b[34m--->    ";


            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.CursorVisible = false;

                // Menu choises

                string[] menuChoices = { "Log in", "Register", "Admin Login", "Exit" };

                Console.WriteLine("\nUse up and down to navigate and press enter to select.\n");
                Console.WriteLine($"{(menuSelected == 0 ? color : "\t")}{menuChoices[0]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 1 ? color : "\t")}{menuChoices[1]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 2 ? color : "\t")}{menuChoices[2]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 3 ? color : "\t")}{menuChoices[3]}\u001b[0m");

                // Variable holding enter
                var keyPressed = Console.ReadKey();

                // If user press down key and selected option is not equal the length of the array
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoices.Length-1)
                {

                    menuSelected++;
                }

                // If user press up key and selected option is more than 0
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected > 0)
                {

                    menuSelected--;
                }

                // If user press enter, check menuoption and run method 
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:

                            LoggingIn();

                            break;

                        case 1:

                            Register();


                            break;

                        case 2:

                            Console.WriteLine("\nPress enter to see all customers, passwords and shoppingcarts.\n");
                            Console.ReadKey();
                            Console.Clear();
                            Customer.PrintAllCustomers();

                            break;


                        case 3:

                            
                          
                            isRunning = false;


                            break;

                    }
                }
            }
        }

        static void UserMenu(int ID)
        {
            int menuSelected = 0;
            bool isMenuRunning = true;
            (int left, int top) = Console.GetCursorPosition();
            string color = "\u001b[34m--->  ";

            while (isMenuRunning)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome\n");
                Console.WriteLine("*************************\n");

                Console.CursorVisible = false;

                //Menuoptions for shopping

                string[] menuChoice = { "Shop", "See cart", "Pay", "Back to menu" };

                Console.WriteLine($"{(menuSelected == 0 ? color : "      ")}{menuChoice[0]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 1 ? color : "      ")}{menuChoice[1]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 2 ? color : "      ")}{menuChoice[2]} \u001b[0m");
                Console.WriteLine($"{(menuSelected == 3 ? color : "      ")}{menuChoice[3]} \u001b[0m");

                // Variable holding enter
                var keyPressed = Console.ReadKey();

                // If user press down key and selected option is not equal the length of the array
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoice.Length-1)
                {
                    menuSelected++;
                }

                // If user press up key and selected option is more than 0
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected > 0)
                {
                    menuSelected--;
                }

                // If user press enter, check menuoption and run method 
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Shop");
                            Console.WriteLine("******************\n");
                            BuyProducts(ID);

                            break;

                        case 1:


                            PrintCart(ID);
                            Console.ReadKey();

                            break;

                        case 2:

                            Pay(ID);
                            Console.WriteLine("pay");

                            break;

                        case 3:

                            isMenuRunning = false;

                            break;


                    }
                }
            }
        }

       
        static void Register()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("New customer\n");
            Console.WriteLine("************************");
            Console.Write("\nEnter username: ");
            string userName = Console.ReadLine();
            Console.Write("\nEnter password: ");
            string password = Console.ReadLine();


            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Customer newCustomer = new Customer(userName, password);

                Console.WriteLine("\nPlease press enter to get back to menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nInvalid username or password! Please try again.");
                Console.ReadKey();
            }
        }

        static void LoggingIn()
        {
            Console.WriteLine();
            Console.CursorVisible = true;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("\nEnter userName: ");
                string userName = Console.ReadLine();

                Console.Write("\nEnter password: ");
                string password = Console.ReadLine();


                Customer loggedInCustomer = Customer.LogIn(userName, password);

                if (loggedInCustomer != null)
                {
                    
                    
                    UserMenu(loggedInCustomer.ID);
                    MainMenu();
                    break;
                }
                else
                {
                    
                    isRunning = false;
                }


                Console.WriteLine("Do you want to register? y/n\n");
                string answer = Console.ReadLine();
                answer = answer.ToLower();

                switch (answer)
                {
                    case "y":

                        Register();

                        break;

                    case "n":

                        break;

                    default:

                        Console.WriteLine("\nInvalid input. Please write y for yes or n for no.\n");

                        break;
                }

            }
        }
       
        static void BuyProducts(int ID)
        {
            Customer customer = Customer.GetCustomerByID(ID);
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine();

                Console.CursorVisible = true;

                Console.WriteLine("Add to cart. Press 5 to get back to menu.\n");

                // Print list with products
                for (int i = 0; i < Product.listWithProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{Product.listWithProducts[i].ToString()}");

                }

                Console.WriteLine("\n*************************\n");

                try
                {
                    int menuSelected = Convert.ToInt32(Console.ReadLine());

                    switch (menuSelected)
                    {
                        case 1:

                            
                            AddToCart(Product.listWithProducts[0], customer.ID);

                            break;

                        case 2:

                            AddToCart(Product.listWithProducts[1], customer.ID);


                            break;


                        case 3:

                            AddToCart(Product.listWithProducts[2], customer.ID);


                            break;

                        case 4:

                            AddToCart(Product.listWithProducts[3], customer.ID);


                            break;

                        case 5:

                            run = false;

                            break;

                        default:

                            Console.WriteLine("Invalid number. Please select 1-5.");
                            Console.ReadKey();

                            break;

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                }

            }
        }

        static void AddToCart(Product product, int ID)
        {        

            Customer customer = Customer.GetCustomerByID(ID);

            
                customer.GetCart().Add(product);
                customer.TotalPrice += product.Price;
                Console.WriteLine($"You bought {product.ProductName}. Press enter to continue shopping.");
                Console.ReadKey();            
        }

        static void PrintCart(int ID)
        {
            Customer customer = Customer.GetCustomerByID(ID);
            
            Console.WriteLine("\n***************************\n");
            Console.WriteLine("This is currently in your cart:\n");

            var groupedCart = customer.GetCart().GroupBy(product => new { product.ProductName, product.Price });
            int totalCount = 0;

            foreach (var group in groupedCart)
            {
                string productName = group.Key.ProductName;
                double price = group.Key.Price;
                int count = group.Count();
                double total = price * count;
                total = Math.Round(total, 4);
                totalCount += count;

                Console.WriteLine($"{productName}\tat {price} SEK\tQuantity: {count}\ttotal: {total} SEK");

            }

            Console.WriteLine($"\nTotal price: {customer.TotalPrice} kr. Total number of products in cart {totalCount}");

        }

        private static void Pay(int ID)
        {
            Customer customer = Customer.GetCustomerByID(ID);

            Console.WriteLine($"\nTo pay: {customer.TotalPrice} SEK.\n");

            string[] currency = { "SEK", "USD", "EUR" };

            for (int i = 0; i < currency.Length; i++)
            {
                Console.WriteLine($"{i+1}. {currency[i]}");
            }
            Console.ReadKey();
        }


    }
}

       

    
