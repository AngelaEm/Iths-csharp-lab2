using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iths_csharp_lab2
{
    internal static class MainMenuOptions
    {
        /// <summary>
        /// Displays options for user to log in, register or exit and option for admin to log in 
        /// </summary>
        public static void MainMenu()
        {

            int menuSelected = 0;
            bool isRunning = true;
            (int left, int top) = Console.GetCursorPosition();
            string color = "\u001b[34m--->    ";


            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.CursorVisible = false;

                // Menu choises

                string[] menuChoices = { "Log in", "Register", "Admin Login", "Exit" };

                Console.WriteLine("\nUse up and down to navigate and press enter to select.\n");
                Console.WriteLine($"{(menuSelected == 0 ? color : "\t")}{menuChoices[0]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 1 ? color : "\t")}{menuChoices[1]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 2 ? color : "\t")}{menuChoices[2]}\u001b[0m");
                Console.WriteLine($"{(menuSelected == 3 ? color : "\t")}{menuChoices[3]}\u001b[0m");

                // Variable holding enter
                var keyPressed = Console.ReadKey();

                // If user press down key and selected option is not equal the length of the array -1
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoices.Length - 1)
                {

                    menuSelected++;
                }

                // If user press up key and selected option is more than 0
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected > 0)
                {

                    menuSelected--;
                }

                // If user press enter, check menuoption and run method 
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:

                            CustomerLogIn();

                            break;

                        case 1:

                            Register();


                            break;

                        case 2:

                            Console.WriteLine("\n****************************\n");
                            Console.WriteLine("\nPress enter to see all customers, passwords and shoppingcarts.\n");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("\n****************************\n");
                            Member.PrintAllMembers();

                            break;


                        case 3:

                            isRunning = false;

                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Allows new customers to register.
        /// </summary>
        static void Register()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("New customer\n");
            Console.WriteLine("************************");
            Console.Write("\nEnter username: ");
            string userName = Console.ReadLine();
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
                    level = Member.MembershipLevel.Silver;
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
                Member newCustomer = new Member(userName, password, level);

                // Save customer to textfile
                string fileName = "C:\\Users\\Angela\\source\\repos\\Iths csharp lab2\\Iths csharp lab2\\SavedUsers.txt";
                File.AppendAllText(fileName, $"{userName}, {password}\n");
                Console.Clear();
                Console.WriteLine("\n**************************************************************************\n");
                Console.WriteLine($"You are now registered. {userName}! Please press enter to get back to menu.");
                Console.WriteLine("\n**************************************************************************\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nInvalid username or password! Please try again.");
                Console.ReadKey();
            }

            
        }


        /// <summary>
        /// Allows customer members to log in
        /// </summary>
        static void CustomerLogIn()
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


                Member loggedInMember = Member.LogIn(userName, password);

                if (loggedInMember != null)
                {

                    UserMenuOptions.UserMenu(loggedInMember);
                    MainMenu();
                    break;
                }
                else
                {
                    isRunning = false;
                }

                Console.WriteLine("Do you want to register? y/n\n");
                string answer = Console.ReadLine();
                answer = answer.ToLower();

                switch (answer)
                {
                    case "y":

                        Register();

                        break;

                    case "n":

                        break;

                    default:

                        Console.WriteLine("\nInvalid input. Please write y for yes or n for no.\n");

                        break;
                }
            }
        }
    }
}
