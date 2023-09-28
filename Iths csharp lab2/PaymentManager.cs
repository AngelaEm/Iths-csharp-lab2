using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Iths_csharp_lab2.Member;
using System.Reflection.Emit;

namespace Iths_csharp_lab2
{
    internal static class PaymentManager
    {

        public static void CheckOut(Member member)
        {

            double discountPrice = 0;
            string[] currencyOption = { "SEK", "EUR", "USD" };

            Console.Clear();

            Console.WriteLine($"\nWelcome to checkout {member.UserName}!");
            Console.WriteLine($"\nTo pay: {Math.Round(member.TotalPrice, 4)} SEK.\n");

            discountPrice = BonusDiscount(member);

            Console.WriteLine($"To pay as {member.Level}-member: {discountPrice} SEK.\n");
            Console.WriteLine("Please choose currency 1-3\n");

            for (int i = 0; i < currencyOption.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currencyOption[i]}");
            }

            string currency = Console.ReadLine();
            

            switch (currency)
            {
                case "1":

                    Console.WriteLine($"Pay {discountPrice} SEK.");
                    
                    break;

                case "2":

                    Console.WriteLine($"Pay {ConvertToEuro(discountPrice)} EUR."); 
                    
                    break;

                case "3":

                    Console.WriteLine($"Pay {ConvertToDollar(discountPrice)} USD.");

                    break;


                default:

                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            
            Console.ReadKey();

            PayAndRemove(member, member.GetCart());

        }


        public static double BonusDiscount(Member member)
        {

            double discountPrice = 0;

            switch (member.Level)
            {
                case MembershipLevel.Gold:

                    return Gold(member.TotalPrice);

                case MembershipLevel.Silver:

                    return Silver(member.TotalPrice);

                case MembershipLevel.Bronze:

                    return Bronze(member.TotalPrice);

                case MembershipLevel.None:
                    
                    return member.TotalPrice;

                default:

                    return discountPrice;
            }
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


        /// <summary>
        /// Convert price from SEK to USD
        /// </summary>
        /// <param name="customer">price to convert</param>
        /// <returns>Price (double) in USD</returns>
        private static double ConvertToDollar(double price)
        {
            double PriceInUSD = Math.Round((price / 11.03), 2);

            return PriceInUSD;
        }


        /// <summary>
        /// Convert price from SEK to EUR
        /// </summary>
        /// <param name="customer">double price</param>
        /// <returns>Price (double) in EUR</returns>
        private static double ConvertToEuro(double price)
        {
            double PriceInEuro = Math.Round((price / 11.9749), 2);

            return PriceInEuro;
        }

        private static void PayAndRemove(Member member, List<Product> shoppingCart)
        {
            Console.WriteLine("Do you want to pay or just log out?\n");           
            Console.WriteLine("1. Pay and remove products in cart.");
            Console.WriteLine("2. Log out");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":

                    member.ShoppingCart.Clear();
                    member.TotalPrice = 0;
                    Console.WriteLine("Successfull, welcome back!");
                    Console.ReadKey();

                    break;

                case "2":

                    break;

                default:

                    Console.WriteLine("\nInvalid input. Please press 1-2\n");

                    break;
            }
        }

    }
}
