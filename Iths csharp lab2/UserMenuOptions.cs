using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class UserMenuOptions
    {
        /// <summary>
        /// Displays options for shopping, viewing cart and paying for user.
        /// </summary>
        /// <param name="customer">The logged in customer.</param>
        public static void UserMenu(Customer customer)
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
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoice.Length - 1)
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
                            ProductMenu(customer);

                            break;

                        case 1:


                            PrintCart(customer);
                            Console.ReadKey();

                            break;

                        case 2:

                            PayMethods.Pay(customer);
                            

                            break;

                        case 3:

                            isMenuRunning = false;

                            break;

                    }
                }
            }
        }


        /// <summary>
        /// Displays options to buy different products 
        /// </summary>
        /// <param name="customer">The logged in customer.</param>
        static void ProductMenu(Customer customer)
        {

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

                string menuSelected = Console.ReadLine();

                // Options for adding products to cart
                switch (menuSelected)
                {
                    case "1":

                        AddToCart(Product.listWithProducts[0], customer);

                        break;

                    case "2":

                        AddToCart(Product.listWithProducts[1], customer);


                        break;


                    case "3":

                        AddToCart(Product.listWithProducts[2], customer);


                        break;

                    case "4":

                        AddToCart(Product.listWithProducts[3], customer);


                        break;

                    case "5":

                        Console.WriteLine("\nReturning to the logged in menu.");
                        Console.ReadKey();
                        run = false;

                        break;

                    default:

                        Console.WriteLine("Invalid number. Please select 1-5.");
                        Console.ReadKey();

                        break;

                }
            }
        }


        /// <summary>
        /// Adds product to customers cart and updates totalPrice.
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <param name="customer">The logged in customer</param>
        static void AddToCart(Product product, Customer customer)
        {
            // Add product to cart
            customer.GetCart().Add(product);

            // Uppdates totalPrice
            customer.TotalPrice += product.Price;

            // Print what user bought
            Console.WriteLine($"You bought {product.ProductName}. Press enter to continue shopping.");
            Console.ReadKey();
        }


        /// <summary>
        /// Displays customers shopping cart with products, number of products, price and total price.
        /// </summary>
        /// <param name="customer">The logged in user</param>
        static void PrintCart(Customer customer)
        {

            Console.WriteLine("\n***************************\n");
            Console.WriteLine("This is currently in your cart:\n");

            // Group the products in cart by name and price.
            var groupedCart = customer.GetCart().GroupBy(product => new { product.ProductName, product.Price });
            int totalCount = 0;

            // Displays details about the grouped cart.
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
    }
}
