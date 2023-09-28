using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class CartManager
    {
        /// <summary>
        /// Adds product to customers cart and updates totalPrice.
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <param name="customer">The logged in customer</param>
        public static void AddToCart(Product product, Member member)
        {          
            member.GetCart().Add(product);

            member.TotalPrice += product.Price;           
            
        }


        /// <summary>
        /// Displays customers shopping cart with products, number of products, price and total price.
        /// </summary>
        /// <param name="customer">The logged in user</param>
        public static void PrintCart(Member member)
        {
            // Runs if cart is empty
            if (member.GetCart().Count == 0 )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n**************************\n");
                Console.WriteLine("Yor cart is currently empty.");
                Console.WriteLine("\n**************************\n");
                Console.ReadKey();
                Console.ResetColor();
                MenuManager.UserMenu(member, MenuManager.MenuDesign(MenuManager.userMenuChoices));
            }

            Console.Clear();
            Console.WriteLine("\n***************************\n");
            Console.WriteLine("This is currently in your cart:\n");

            // Group the products in cart by name and price.
            var groupedCart = member.GetCart().GroupBy(product => new { product.ProductName, product.Price });
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

            Console.WriteLine($"\nTotal price: {member.TotalPrice} kr. Total number of products in cart {totalCount}");

        }

    }
}
