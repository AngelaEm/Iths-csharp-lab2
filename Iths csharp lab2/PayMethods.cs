using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class PayMethods
    {
        public static void Pay(Customer customer)
        {
            string[] currency = { "SEK", "EUR", "USD", "Exit" };
            bool IsRunning = true;

            while (IsRunning)
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

                        Console.WriteLine($"\nTotal price: {customer.TotalPrice} SEK.");
                        

                        break;

                    case "2":

                        Console.WriteLine($"\nTotal price: {ConvertToEuro(customer)} EUR.");
                       
                        break;

                    case "3":

                        Console.WriteLine(($"\nTotal price: {ConvertToDollar(customer)} USD."));
                        
                        break;

                    case "4":

                        Console.WriteLine("\nBye, bye, welcome back.");
                        Console.ResetColor();
                        IsRunning = false;
                        break;

                    default:

                        Console.WriteLine("\nInvalid choice, please input number 1-3.");
                        
                        break;
                }
                Console.ReadKey();
            }
        }

        private static object ConvertToDollar(Customer customer)
        {
            double TotalPriceInUSD = Math.Round((customer.TotalPrice / 11.9749), 2);

            return TotalPriceInUSD;
        }

        private static double ConvertToEuro(Customer customer)
        {
            double TotalPriceInEuro = Math.Round((customer.TotalPrice / 11.14),2);

            return TotalPriceInEuro;
        }
        
    }
}
