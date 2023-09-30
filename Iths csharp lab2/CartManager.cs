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
            // Add products to members cart
            member.GetCart().Add(product);

            // Increase totalPrice
            member.TotalPrice += product.Price;

            Console.WriteLine($"\n\tAdded to cart.\tTotal price: {Math.Round(member.TotalPrice, 2)} SEK");
            Console.WriteLine("\tPress enter to continue.");
            Console.ReadKey();
            
            MenuManager.ProductMenu(member, MenuManager.MenuDesign(MenuManager.GetArrayWithProducts()));

        }


        /// <summary>
        /// Displays customers shopping cart with products, number of products, price and total price.
        /// </summary>
        /// <param name="customer">The logged in user</param>
        public static void PrintCart(Member member)
        {
            Console.Clear();
            Console.WriteLine("\n*********************************************************\n");
            Console.WriteLine("Your settings:\n");
            // Runs if cart is empty
            if (member.GetCart().Count == 0 )
            {
                Console.WriteLine(member.ToString());
                Console.WriteLine("\n**************************\n");
                Console.WriteLine("Yor cart is currently empty.");
                Console.WriteLine("\n**************************\n");
                Console.ReadKey();
                
                MenuManager.UserMenu(member, MenuManager.MenuDesign(MenuManager.userMenuChoices));
            }


            // Group the products in cart by name and price.
            var groupedCart = member.GetCart().GroupBy(product => new { product.ProductName, product.Price });
            int totalCount = 0;

            Console.WriteLine(member.ToString()); 

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

            Console.WriteLine("\n*********************************************************\n");
            Console.WriteLine($"\nTotal price: {Math.Round(member.TotalPrice, 2)} kr. Total number of products in cart {totalCount}");

        }

    }
}
