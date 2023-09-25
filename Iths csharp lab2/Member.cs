using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class Member : Customer
    {
        public enum MembershipLevel
        {
            Gold = 85,
            Silver = 90,
            Bronze = 95,
            None = 0,
        }

        public MembershipLevel Level { get; set;}

        public Member(string userName, string password, MembershipLevel level)
            : base(userName, password)
        {
            
            Level = level;
        }

        private static double BonusDiscount(Customer customer, MembershipLevel membershipLevel)
        {

            double discountPrice = 0;

            

            if (membershipLevel == MembershipLevel.Gold)
            {
                discountPrice = Gold(customer.TotalPrice);
            }
            else if (membershipLevel == MembershipLevel.Silver)
            {
                discountPrice = Silver(customer.TotalPrice);
            }
            else if (membershipLevel == MembershipLevel.Bronze)
            {
                discountPrice = Bronze(customer.TotalPrice);
            }


            return discountPrice;
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

