using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class PayMethods
    {
        /// <summary>
        /// Displays total price before and after discout depending on user membership. Displays Total price in SEK, EUR and USD.
        /// </summary>
        /// <param name="customer">The logged in customer.</param>
        public static void Pay(Customer customer)
        {
            
            string[] currency = { "SEK", "EUR", "USD", "Exit" };
            bool IsRunning1 = true;
            bool IsRunning2 = true;
            double discountPrice = 0;

            while (IsRunning1)
            {

                Console.Clear();

                Console.WriteLine($"\nWelcome to checkout {customer.UserName}!");
                Console.WriteLine($"\nTo pay: {Math.Round(customer.TotalPrice,4)} SEK.\n");
                Console.WriteLine($"Please select membershiplevel: Gold, Silver, Bronze or No level.\n"); 

                Console.WriteLine($"1. {MembershipLevel.Gold}");
                Console.WriteLine($"2. {MembershipLevel.Silver}");
                Console.WriteLine($"3. {MembershipLevel.Bronze}");
                Console.WriteLine($"4. No Level");
                Console.WriteLine("\n*******************\n");

                string membershipLevel = Console.ReadLine();

                switch (membershipLevel)
                {
                    case "1":
                        
                        customer.MembershipLevel = MembershipLevel.Gold;
                        discountPrice = Gold(customer.TotalPrice);
                        Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                        IsRunning1 = false;
                        break;

                    case "2":
                        
                        customer.MembershipLevel = MembershipLevel.Silver;
                        discountPrice = Silver(customer.TotalPrice);
                        Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                        IsRunning1 = false;
                        break;

                    case "3":

                        customer.MembershipLevel = MembershipLevel.Bronze;
                        discountPrice = Bronze(customer.TotalPrice);
                        Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                        IsRunning1 = false;
                        break;

                    case "4":

                        Console.WriteLine($"No discount.");
                        discountPrice = customer.TotalPrice;
                        IsRunning1 = false;
                        break;

                    default:

                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("\nPress enter to get currency options.");
                Console.ReadKey();
            }

            while (IsRunning2)
            {
                Console.Clear();

                Console.WriteLine("\nChoose currency 1 - 3 from menu. Chooce 4 to Exit.\n");
                        

                for (int i = 0; i < currency.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {currency[i]}");
                }
                Console.WriteLine();
                Console.CursorVisible = true;
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                      
                        Console.WriteLine($"\nTotal price in {currency[0]} with discount {100-(int)customer.MembershipLevel}%: {discountPrice} SEK.");                        

                        break;

                    case "2":
                        
                        Console.WriteLine($"\nTotal price in {currency[1]} with discount {100-(int)customer.MembershipLevel}%: {ConvertToEuro(discountPrice)} EUR.");

                        break;

                    case "3":
                      
                        Console.WriteLine($"\nTotal price in {currency[2]} with discount  {100 - (int)customer.MembershipLevel}%: {ConvertToDollar(discountPrice)} USD.");

                        break;

                    case "4":

                        Console.WriteLine("\nBye, bye, welcome back.");
                        Console.ResetColor();
                        IsRunning2 = false;
                        break;

                    default:

                        Console.WriteLine("\nInvalid choice, please input number 1-3.");
                        
                        break;
                }
                Console.ReadKey();
            }
        }


        /// <summary>
        /// Convert price from SEK to USD
        /// </summary>
        /// <param name="customer">price to convert</param>
        /// <returns>Price (double) in USD</returns>
        private static double ConvertToDollar(double price)
        {
            double PriceInUSD = Math.Round((price / 11.9749), 2);

            return PriceInUSD;
        }


        /// <summary>
        /// Convert price from SEK to EUR
        /// </summary>
        /// <param name="customer">double price</param>
        /// <returns>Price (double) in EUR</returns>
        private static double ConvertToEuro(double price)
        {
            double PriceInEuro = Math.Round((price / 11.14),2);

            return PriceInEuro;
        }


        /// <summary>
        /// Calculates new Total price after discount with Gold membership
        /// </summary>
        /// <param name="totalPrice">Total price</param>
        /// <returns>Total price after discount in SEK</returns>
        private static double Gold(double totalPrice)
        {
            double discount = (int)MembershipLevel.Gold / 100.0;
            double discountPrice = totalPrice * discount;
            return Math.Round(discountPrice, 2);
        }


        /// <summary>
        /// Calculates new Total price after discount with Silver membership
        /// </summary>
        /// <param name="totalPrice">Total price</param>
        /// <returns>Total price after discount in SEK</returns>
        private static double Silver(double totalPrice)
        {
            double discount = (int)MembershipLevel.Silver / 100.0;
            double discountPrice = totalPrice * discount;
            return Math.Round(discountPrice, 2);
            
           
        }


        /// <summary>
        /// Calculates new Total price after discount with Bronze membership
        /// </summary>
        /// <param name="totalPrice">Total price</param>
        /// <returns>Total price after discount in SEK</returns>
        private static double Bronze(double totalPrice)
        {
            double discount = (int)MembershipLevel.Bronze / 100.0;
            double discountPrice = totalPrice * discount;
            return Math.Round(discountPrice, 2);

        }

    }
}
