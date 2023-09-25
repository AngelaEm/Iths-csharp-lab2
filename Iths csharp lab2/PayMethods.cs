using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal static class PayMethods
    {

        public static void PayMenu(Customer customer)
        {

            double discountPrice = 0;

            Console.Clear();

            Console.WriteLine($"\nWelcome to checkout {customer.UserName}!");
            Console.WriteLine($"\nTo pay: {Math.Round(customer.TotalPrice, 4)} SEK.\n");
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

                    //discountPrice = BonusDiscount(customer, MembershipLevel.Gold);
                    //Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                    //Currency();
                    break;

                case "2":

                    //discountPrice = BonusDiscount(customer, MembershipLevel.Silver);
                    //Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                    //Currency();
                    break;

                case "3":

                    //discountPrice = BonusDiscount(customer, MembershipLevel.Bronze);
                    //Console.WriteLine($"To pay with discount {100 - (int)customer.MembershipLevel}%: {discountPrice} SEK.");
                    //Currency();
                    break;

                case "4":

                    //discountPrice = customer.TotalPrice;
                    //Console.WriteLine($"No discount. Pay {discountPrice}");
                    //Currency();

                    break;

                default:

                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("\nPress enter to get currency options.");
            Console.ReadKey();





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


    }
}
