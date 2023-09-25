using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iths_csharp_lab2
{
    internal static class PayMethods
    {

        public static void CheckOut(Member member)
        {

            double discountPrice = 0;
            string[] currencyOption = { "SEK", "EUR", "USD" };

            Console.Clear();

            Console.WriteLine($"\nWelcome to checkout {member.UserName}!");
            Console.WriteLine($"\nTo pay: {Math.Round(member.TotalPrice, 4)} SEK.\n");

            discountPrice = member.BonusDiscount(member);

            Console.WriteLine($"To pay with discount: {discountPrice} SEK.\n");
            Console.WriteLine("Please choose currency 1-3\n");

            for (int i = 0; i < currencyOption.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currencyOption[i]}");
            }

            string currency = Console.ReadLine();
            

            switch (currency)
            {
                case "1":

                    Console.WriteLine(discountPrice);
                    
                    break;

                case "2":

                    Console.WriteLine(ConvertToEuro(discountPrice)); 
                    
                    break;

                case "3":

                    Console.WriteLine(ConvertToDollar(discountPrice)); 
                    
                    break;

                case "4":

                    

                    break;

                default:

                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            
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
