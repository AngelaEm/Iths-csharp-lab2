using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

        private MembershipLevel _level;

        public MembershipLevel Level
        {
            get { return _level; }
            private set { _level = value; }
        }

        public Member(string userName, string password, MembershipLevel level)
            : base(userName, password)
        {
            
            Level = level;
            ListWithMembers.Add(this);
        }

        /// <summary>
        /// Controls if username matches password and let customer log in if they match.
        /// </summary>
        /// <param name="userName">Name of the customer.</param>
        /// <param name="password">Password of the customer.</param>
        /// <returns>Customer if username and password match and null if they dont match.</returns>
        public static Member LogIn(string userName, string password)
        {

            foreach (Member member in ListWithMembers)
            {
                if (member.UserName == userName && member.Password == password)
                {
                    Console.WriteLine($"\nWelcome {member.UserName}!");
                    Console.ReadKey();
                    return member;
                }
            }
            Console.WriteLine($"\nSorry {userName}. Username and password dont match.\n");
            return null;
        }


        /// <summary>
        /// Displays all customers, their passwords and their cart.
        /// </summary>
        public static void PrintAllMembers()
        {
            foreach (Member member in ListWithMembers)
            {

                Console.WriteLine(member.ToString());

            }
            Console.ReadKey();
        }


        
       



        

    }

}

