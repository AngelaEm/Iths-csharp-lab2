﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Iths_csharp_lab2
{
    internal class Member : Customer
    {
        // Enum membershiplevel
        public enum MembershipLevel
        {
            Gold = 85,
            Silver = 90,
            Bronze = 95,
            None = 0,
        }

        // Field
        private MembershipLevel _level;


        // Constructor
        public Member(string userName, string password, MembershipLevel level) : base(userName, password)
        {
            Level = level;
            ListWithCustomers.Add(this);
        }


        // Property
        public MembershipLevel Level
        {
            get { return _level; }
            private set { _level = value; }
        }
      

        // Methods
        /// <summary>
        /// Controls if username matches password and let customer log in if they match.
        /// </summary>
        /// <param name="userName">Name of the customer.</param>
        /// <param name="password">Password of the customer.</param>
        /// <returns>Customer if username and password match and null if they dont match.</returns>
        public static Member TestIfMemberExist(string userName, string password)
        {
            // Iterates through ListWithCustomer to see if customer is a member and return member if true
            foreach (Member member in ListWithCustomers)
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
        /// Allows customer members to log in
        /// </summary>
        public static void LogInMember()
        {
            Console.WriteLine();
            Console.CursorVisible = true;
            bool isRunning = true;          

            while (isRunning)
            {
                Console.Write("\nEnter userName: ");
                string userName = Console.ReadLine();

                Console.Write("\nEnter password: ");
                string password = Console.ReadLine();
              
                Member loggedInMember = Member.TestIfMemberExist(userName, password);

                // Log in if user exists
                if (loggedInMember != null)
                {           
                    
                    MenuManager.UserMenu(loggedInMember, MenuManager.MenuDesign(MenuManager.userMenuChoices));

                    break;
                }
                else
                {
                    isRunning = false;
                }

                // If user is not a member they get the option to register
                Console.WriteLine("Do you want to register? y/n\n");
                string answer = Console.ReadLine();
                answer = answer.ToLower();

                switch (answer)
                {
                    case "y":

                        Register();

                        break;

                    case "n":
                      
                        MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));

                        break;

                    default:

                        MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));
                        Console.WriteLine("\nInvalid input. Please write y for yes or n for no.\n");
  
                        break;
                }
            }
        }


        /// <summary>
        /// Allows new customers to register.
        /// </summary>
        public static void Register()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("New customer\n");
            Console.WriteLine("************************");
            Console.Write("\nEnter username: ");
            string userName = Console.ReadLine();
            

            foreach (Member member in Member.ListWithCustomers)
            {
                if (member.UserName == userName)
                {
                    Console.WriteLine("This customer already exists! Press enter to try again.");
                    Console.ReadKey();
                    Register();
                }
            }

            Console.Write("\nEnter password: ");

            string password = Console.ReadLine();
            Member.MembershipLevel level = Member.MembershipLevel.None;
            Console.WriteLine("\nEnter your memberpoints 0-1000.\n");

            try
            {
                int points = int.Parse(Console.ReadLine());
                if (points >= 0 && points < 100)
                {
                    level = Member.MembershipLevel.None;
                    Console.WriteLine("\nYou have no bonus yet. Keep shopping to get to the next level!\n");
                }
                else if (points >= 100 && points < 500)
                {
                    level = Member.MembershipLevel.Bronze;
                    Console.WriteLine($"\nYou are {Member.MembershipLevel.Bronze} member and get a discount of {100 - (int)Member.MembershipLevel.Bronze}%.");
                }
                else if (points >= 500 && points < 850)
                {
                    level = Member.MembershipLevel.Silver;
                    Console.WriteLine($"\nYou are {Member.MembershipLevel.Silver} member and get a discount of {100 - (int)Member.MembershipLevel.Silver}%.");
                }
                else if (points >= 850 && points <= 1000)
                {
                    level = Member.MembershipLevel.Gold;
                    Console.WriteLine($"\nYou are {Member.MembershipLevel.Gold} member and get a discount of {100 - (int)Member.MembershipLevel.Gold}%.");
                }
                else
                {
                    Console.WriteLine("\nPlease choose a number 0-1000.");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid choice, please write a number 0-1000");
            }

            Console.ReadKey();


            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Member newMember = new Member(userName, password, level);

                // Save customer to textfile
                string fileName = "textFile.txt";
                File.AppendAllText(fileName, $"{userName},{password},{level}\n");
                     
                
            }
            else
            {
                Console.WriteLine("\nInvalid username or password! Please try again.");
                Console.ReadKey();              
                
            }

                // Main menu
                MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));

        }


        /// <summary>
        /// Returns a string with users username, password and cart.
        /// </summary>
        /// <returns>string with users username, password and cart.</returns>
        public override string ToString()
        {
            string maskedString = new string('*', Password.Length);
            string user = $"Username: {UserName}\nPassword: {maskedString}\nMembershiplevel: {Level}\n\nShoppingcart:\n";
           
            return user;
               
        }
    }
}

