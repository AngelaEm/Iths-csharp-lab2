using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class MenuManager
    {
        // Arrays with mainmenu options and usermenu options
        public static string[] mainMenuChoices = { "Log in", "Register", "Admin Login", "Exit" };
        public static string[] userMenuChoices = { "Shop", "See cart", "Pay", "Log out" };


        /// <summary>
        /// Displays welcome message and initalizes three customers and four products at start.
        /// </summary>
        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("********************************\n");
            Console.WriteLine("Welcome to this awesome webshop!");
            Console.WriteLine("\n********************************\n");
            Console.WriteLine("Press enter to get to the menu.");

            Console.ReadKey();
            Console.ResetColor();
           
            Product redBull = new Product("Red Bull", 13.95);
            Product colaZero = new Product("Cola Zero", 9.95);
            Product afterEight = new Product("After Eight", 49);
            Product tuttiFrutti = new Product("Ice cream", 19.50);

        }


        /// <summary>
        /// Displays menu with options and returns index with selected option.
        /// </summary>
        /// <param name="menuChoices">An array with menu options.</param>
        /// <returns>Index of the selected option</returns>
        public static int MenuDesign(string[] menuChoices)
        {

            int menuSelected = 0;
            bool isRunning = true;

            // Variable holding the color to highligt with and an arrow
            string color = "\u001b[34m--->    ";

            // Let user navigate through menu using "up" and "down" and select with enter
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.CursorVisible = false;

                Console.WriteLine("\nUse up and down arrows to navigate and press enter to select.\n");

                // Iterates through array to display menuchoises
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine($"{(menuSelected == i ? color : "\t")}{menuChoices[i]}\u001b[0m");
                }

                // Naviagte with up and down-arrows
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoices.Length - 1)
                {
                    menuSelected++;
                }

                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected > 0)
                {
                    menuSelected--;
                }

                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return menuSelected;
        }


        /// <summary>
        /// Manage main menu options
        /// </summary>
        /// <param name="menuSelected">Index of selected option</param>
        public static void MainMenu(int menuSelected)
        {
            switch (menuSelected)
            {
                case 0:

                    Member.LogInMember();

                    break;

                case 1:

                    Member.Register();


                    break;

                case 2:
                    // Display all members, passwords and carts to admin. Password 123
                    Console.WriteLine("\n****************************\n");
                    Console.WriteLine("\nWrite password to see all customers, passwords and shoppingcarts.\n");
                    Console.CursorVisible = true;
                    string password = Console.ReadLine();

                    if (password == "123")
                    {
                        Console.Clear();
                        Console.WriteLine("\n****************************\n");
                        Member.PrintAllMembers();
                        Console.CursorVisible = false;
                        MenuManager.MainMenu(MenuManager.MenuDesign(mainMenuChoices));
                    }

                    Console.CursorVisible = false;
                    Console.WriteLine("Invalid password.");
                    Console.ReadKey();                   
                    MenuManager.MainMenu(MenuManager.MenuDesign(mainMenuChoices));                   

                    break;

                case 3:

                    Environment.Exit(0);

                    break;
            }
        }


        /// <summary>
        /// Manage User menu options.
        /// </summary>
        /// <param name="member">Logged in member</param>
        /// <param name="menuSelected">Index of selected option</param>
        public static void UserMenu(Member member, int menuSelected)
        {
            // Options for logged in member
            switch (menuSelected)
            {
                case 0:

                    Console.Clear();                   
                    Console.WriteLine("Shop");
                    Console.WriteLine("******************\n");
                    ProductMenu(member, MenuDesign(GetArrayWithProducts()));
                    
                    break;

                case 1:

                    CartManager.PrintCart(member);
                    Console.ReadKey();
                    MenuManager.UserMenu(member, MenuManager.MenuDesign(userMenuChoices));
                    
                    break;

                case 2:

                    PaymentManager.CheckOut(member);                 
                    MenuManager.UserMenu(member, MenuManager.MenuDesign(userMenuChoices));

                    break;

                case 3:
                   
                    MenuManager.MainMenu(MenuManager.MenuDesign(mainMenuChoices));

                    break;

            }
            
        }

     
        /// <summary>
        /// Makes an array with products from a list with products.
        /// </summary>
        /// <returns>the array with products</returns>
        public static string[] GetArrayWithProducts()
        {
            // Array with products
            string[] products = new string[Product.listWithProducts.Count+1];

            for (int i = 0; i < Product.listWithProducts.Count; i++)
            {
                products[i] = Product.listWithProducts[i].ToString();
            }

            products[Product.listWithProducts.Count] = "Exit";

            // Return array with products and exit
            return products;
        }


       /// <summary>
       /// Mamage product menu options
       /// </summary>
       /// <param name="member">Logged in member</param>
       /// <param name="menuSelected">Index of selected option</param>
        public static void ProductMenu(Member member, int menuSelected)
        {
           
            // Options for adding products to cart
            switch (menuSelected)
            {
                case 0:

                    CartManager.AddToCart(Product.listWithProducts[0], member);
                    
                    break;

                case 1:

                    CartManager.AddToCart(Product.listWithProducts[1], member);

                    break;

                case 2:

                    CartManager.AddToCart(Product.listWithProducts[2], member);                  

                    break;

                case 3:

                    CartManager.AddToCart(Product.listWithProducts[3], member);
                    
                    break;

                case 4:

                    Console.WriteLine("\nReturning to the logged in menu.");
                    Console.ReadKey();
                    
                    MenuManager.UserMenu(member, MenuManager.MenuDesign(userMenuChoices));

                    break;

            }
        }
    }

}

