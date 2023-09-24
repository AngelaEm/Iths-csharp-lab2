using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    internal class MainMenuOptions
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

                // If user press down key and selected option is not equal the length of the array
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
                            Customer.PrintAllCustomers();

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


            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Customer newCustomer = new Customer(userName, password);

                Console.WriteLine("\nPlease press enter to get back to menu.");
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


                Customer loggedInCustomer = Customer.LogIn(userName, password);

                if (loggedInCustomer != null)
                {

                    UserMenuOptions.UserMenu(loggedInCustomer);
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
