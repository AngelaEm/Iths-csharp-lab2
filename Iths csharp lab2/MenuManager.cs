using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class MenuManager
    {

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
                Console.WriteLine($"{(menuSelected == 0 ? color : "\t")}{menuChoices[0]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 1 ? color : "\t")}{menuChoices[1]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 2 ? color : "\t")}{menuChoices[2]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 3 ? color : "\t")}{menuChoices[3]}\u001b[0m");


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

        public static void Menu(int menuSelected)
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

                    break;


                case 3:

                    break;
            }
        }

        public static void UserMenu(Member member, int menuSelected)
        {
            string[] menuChoice = { "Shop", "See cart", "Pay", "Back to menu" };

            switch (menuSelected)
            {
                case 0:

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Shop");
                    Console.WriteLine("******************\n");
                    ProductMenu(member);
                    Console.ResetColor();

                    break;

                case 1:


                    CartManager.PrintCart(member);
                    Console.ReadKey();
                    MenuManager.UserMenu(member, MenuManager.MenuDesign(menuChoice));
                    

                    break;

                case 2:

                    PaymentManager.CheckOut(member);                 
                    MenuManager.UserMenu(member, MenuManager.MenuDesign(menuChoice));

                    break;

                case 3:

                    string[] menuChoices = { "Log in", "Register", "Admin Login", "Exit" };
                    MenuManager.Menu(MenuManager.MenuDesign(menuChoices));

                    break;

            }
           
            
        }

     

        /// <summary>
        /// Displays options to buy different products 
        /// </summary>
        /// <param name="customer">The logged in customer.</param>
        static void ProductMenu(Member member)
        {

            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine();

                Console.CursorVisible = true;

                Console.WriteLine("\n*************************\n");
                Console.WriteLine("PRODUCTS");
                Console.WriteLine("\n*************************\n");

                // Print list with products
                for (int i = 0; i < Product.listWithProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{Product.listWithProducts[i].ToString()}");

                }

                Console.WriteLine("\n*************************\n");
                Console.WriteLine("Press 1-4 to add product to cart.");
                Console.WriteLine("Press 5 to get back to menu");
                Console.WriteLine("Press enter to continue shopping.\n");

                string menuSelected = Console.ReadLine();

                // Options for adding products to cart
                switch (menuSelected)
                {
                    case "1":

                        CartManager.AddToCart(Product.listWithProducts[0], member);

                        break;

                    case "2":

                        CartManager.AddToCart(Product.listWithProducts[1], member);


                        break;


                    case "3":

                        CartManager.AddToCart(Product.listWithProducts[2], member);


                        break;

                    case "4":

                        CartManager.AddToCart(Product.listWithProducts[3], member);


                        break;

                    case "5":

                        Console.WriteLine("\nReturning to the logged in menu.");
                        Console.ReadKey();
                        run = false;
                        string[] menuChoice = { "Shop", "See cart", "Pay", "Back to menu" };

                        MenuManager.UserMenu(member, MenuManager.MenuDesign(menuChoice));

                        break;

                    default:

                        Console.WriteLine("Invalid number. Please select 1-5.");
                        Console.ReadKey();

                        break;

                }
            }
        }




    }
}
