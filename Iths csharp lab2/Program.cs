using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;


namespace Iths_csharp_lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Angela\source\repos\Iths csharp lab2\Iths csharp lab2\SavedUsers.txt");
            Console.WriteLine(text);
            Console.ReadKey();
            Start();
            MainMenuOptions.MainMenu();
        }


        /// <summary>
        /// Displays welcome message and initalizes three customers and four products at start.
        /// </summary>
        static void Start()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.WriteLine("********************************\n");
            Console.WriteLine("Welcome to this awesome webshop!");
            Console.WriteLine("\n********************************\n");
            Console.WriteLine("Press enter to get to the menu.");

            Console.ReadKey();
            Console.ResetColor();

            Customer kund1 = new Customer("Knatte", "123");
            Customer kund2 = new Customer("Fnatte", "321");
            Customer kund3 = new Customer("Tjatte", "213");

            Product redBull = new Product("Red Bull", 13.95);
            Product colaZero = new Product("Cola Zero", 9.95);
            Product afterEight = new Product("After Eight", 49);
            Product tuttiFrutti = new Product("Ice cream", 19.50);

        }

    }
}

       

    
