using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal static class MenuManager
    {
        // Arrays with mainmenu options and usermenu options
        public static string[] mainMenuChoices = { "Log in", "Register", "Exit" };
        public static string[] userMenuChoices = { "Shop", "My settings and cart", "Checkout", "Log out" };


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

            Console.ReadKey(true);
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
                var keyPressed = Console.ReadKey(true);

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

                    member.PrintCart(member);
                    Console.ReadKey(true);
                    UserMenu(member, MenuDesign(userMenuChoices));
                    
                    break;

                case 2:

                    PaymentManager.CheckOut(member);                 
                    UserMenu(member, MenuDesign(userMenuChoices));

                    break;

                case 3:
                   
                    MainMenu(MenuDesign(mainMenuChoices));

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

                    Product.listWithProducts[0].AddToCart(member);
                    
                    break;

                case 1:

                    Product.listWithProducts[1].AddToCart(member);

                    break;

                case 2:

                    Product.listWithProducts[2].AddToCart(member);

                    break;

                case 3:

                    Product.listWithProducts[3].AddToCart(member);

                    break;

                case 4:

                    Console.WriteLine("\nPress enter to return to the logged in menu.");
                    Console.ReadKey(true);
                    
                    UserMenu(member, MenuDesign(userMenuChoices));

                    break;

            }
        }
    }
}

