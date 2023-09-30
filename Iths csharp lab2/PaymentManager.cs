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

        /// <summary>
        /// Handels checkout process for logged in customer
        /// </summary>
        /// <param name="member">Logged in member</param>
        public static void CheckOut(Member member)
        {
            // Runs if member has nothing to pay
            if(member.TotalPrice == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n*********************************************************\n");
                Console.WriteLine("You have nothing to pay yet. Press enter to get back to menu.");
                Console.WriteLine("\n*********************************************************\n");
                Console.ReadKey();
                Console.ResetColor();
                MenuManager.UserMenu(member, MenuManager.MenuDesign(MenuManager.userMenuChoices));
                
            }
            else
            {
                // Variable holding price after discount
                double discountPrice = 0;

                // Array with currecy-options
                string[] currencyOption = { "Pay in SEK", "Pay in EUR", "Pay in USD" };

                Console.Clear();

                Console.WriteLine("\n*************************************\n");
                Console.WriteLine($"Welcome to checkout {member.UserName}!");
                Console.WriteLine($"\nTo pay: {Math.Round(member.TotalPrice, 4)} SEK.\n");

                // Calculate members discountprice
                discountPrice = BonusDiscount(member);

                // Display discountprice
                Console.WriteLine($"To pay as {member.Level}-member: {discountPrice} SEK.\n");
                Console.WriteLine("*************************************\n");
                Console.WriteLine("\nPress enter to continue.");

                Console.ReadKey();

                // Currencyoptions
                switch (MenuManager.MenuDesign(currencyOption))
                {
                    case 0:

                        Console.WriteLine($"\nPay {discountPrice} SEK.\n");

                        break;

                    case 1:

                        Console.WriteLine($"\nPay {ConvertToEuro(discountPrice)} EUR.\n");

                        break;

                    case 2:

                        Console.WriteLine($"\nPay {ConvertToDollar(discountPrice)} USD.\n");

                        break;


                    default:

                        Console.WriteLine("\nInvalid choice, please try again.\n");
                        break;
                }

                Console.WriteLine("\nPress enter to continue.");

                Console.ReadKey();

                PayAndRemove(member, member.GetCart());
            }         
        }

        /// <summary>
        /// Calculates discount depending on membershiplevel
        /// </summary>
        /// <param name="member">Logged in member</param>
        /// <returns>Total proce after discount</returns>
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


        /// <summary>
        /// Handles payment and removal of products.
        /// </summary>
        /// <param name="member">Logged in member</param>
        /// <param name="shoppingCart">Members shoppingcart</param>
        private static void PayAndRemove(Member member, List<Product> shoppingCart)
        {
            // String holding options pay or get back
            string[] pay = new string[] { "Pay and remove products in cart.", "Get back to usermenu." };
                   
            Console.WriteLine();
            
            // Options to pay or get back to menu
            switch (MenuManager.MenuDesign(pay))
            {
                case 0:

                    member.ShoppingCart.Clear();
                    member.TotalPrice = 0;
                    Console.WriteLine("\nSuccessfull, welcome back!");
                    Console.ReadKey();

                    break;

                case 1:

                    break;

                default:

                    Console.WriteLine("\nInvalid input. Please press 1-2\n");

                    break;
            }
        }
    }
}
