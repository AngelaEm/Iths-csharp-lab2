using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class MenuManager
    {
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



            Member Knatte = new Member("Knatte", "123", Member.MembershipLevel.Gold);
            Member Fratte = new Member("Fnatte", "321", Member.MembershipLevel.Silver);
            Member Tjatte = new Member("Tjatte", "213", Member.MembershipLevel.Bronze);

            Product redBull = new Product("Red Bull", 13.95);
            Product colaZero = new Product("Cola Zero", 9.95);
            Product afterEight = new Product("After Eight", 49);
            Product tuttiFrutti = new Product("Ice cream", 19.50);

        }

        public static int MenuDesign(string[] menuChoices)
        {

            int menuSelected = 0;
            bool isRunning = true;
            string color = "\u001b[34m--->    ";


            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.CursorVisible = false;

                Console.WriteLine("\nUse up and down to navigate and press enter to select.\n");

                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine($"{(menuSelected == i ? color : "\t")}{menuChoices[i]}\u001b[0m");
                }

                

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

                    Console.WriteLine("\n****************************\n");
                    Console.WriteLine("\nPress enter to see all customers, passwords and shoppingcarts.\n");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\n****************************\n");
                    Member.PrintAllMembers();                    
                    MenuManager.MainMenu(MenuManager.MenuDesign(mainMenuChoices));

                    break;


                case 3:
                    Environment.Exit(0);

                    break;
            }
        }

        public static void UserMenu(Member member, int menuSelected)
        {
           

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

     
        public static string[] GetArrayWithProducts()
        {
            string[] products = new string[Product.listWithProducts.Count+1];


            for (int i = 0; i < Product.listWithProducts.Count; i++)
            {
                products[i] = Product.listWithProducts[i].ToString();

            }

            products[Product.listWithProducts.Count] = "Exit";
            

            return products;
        }

        /// <summary>
        /// Displays options to buy different products 
        /// </summary>
        /// <param name="customer">The logged in customer.</param>
        public static void ProductMenu(Member member, int menuSelected)
        {
           
            // Options for adding products to cart
            switch (menuSelected)
            {
                case 0:

                    CartManager.AddToCart(Product.listWithProducts[0], member);
                    Console.WriteLine($"\n\tAdded {Product.listWithProducts[0].ProductName}\tTotal price: {Math.Round(member.TotalPrice,2)} SEK");
                    Console.WriteLine("\tPress enter to continue.");
                    Console.ReadKey();
                    MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));

                    break;

                case 1:

                    CartManager.AddToCart(Product.listWithProducts[1], member);
                    Console.WriteLine($"\n\tAdded: {Product.listWithProducts[1].ProductName}\tTotal price: {Math.Round(member.TotalPrice, 2)} SEK");
                    Console.WriteLine("\tPress enter to continue.");
                    Console.ReadKey();
                    MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));


                    break;


                case 2:

                    CartManager.AddToCart(Product.listWithProducts[2], member);
                    Console.WriteLine($"\n\tAdded:  {Product.listWithProducts[2].ProductName}\tTotal price: {Math.Round(member.TotalPrice, 2)} SEK");
                    Console.WriteLine("\tPress enter to continue.");
                    Console.ReadKey();
                    MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));


                    break;

                case 3:

                    CartManager.AddToCart(Product.listWithProducts[3], member);
                    Console.WriteLine($"\n\tAdded:  {Product.listWithProducts[3].ProductName}\tTotal price:  {Math.Round(member.TotalPrice, 2)} SEK");
                    Console.WriteLine("\tPress enter to continue.");
                    Console.ReadKey();
                    MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));

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

