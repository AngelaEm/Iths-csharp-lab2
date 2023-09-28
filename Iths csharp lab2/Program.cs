using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.IO;


namespace Iths_csharp_lab2
{

   
    internal class Program
    {

        public static List<Customer> ListWithCustomers;


        static void Main(string[] args)
        {
          
            // Displays welcomemessage and initializes three members and four products
            MenuManager.Start();
            
            // Variable holding my textfile with logged in members
            string fileName = "textFile.txt";
            
            // Upload members from textfile to listWithCustomers
            ListWithCustomers = UploadCustomersFromTextFile(fileName);

            // Display mainmenu
            MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));
          
        }
    

        /// <summary>
        /// Gets customers that are saved in textfile.
        /// </summary>
        /// <param name="fileName">Name of textfile to read from</param>
        /// <returns>A list of Customers saved in file</returns>
        public static List<Customer> UploadCustomersFromTextFile(string fileName)
        {

            List<Customer> membersInFile = new List<Customer>();

            // Read all lines from textfile.
            string[] lines = File.ReadAllLines(fileName);

            // Iterates trough each line 
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // Where to split the userData
                    string[] userData = line.Split(',');

                    
                    // To make sure there is username, password and level
                    if (userData.Length == 3)
                    {
                        string userName = userData[0];
                        string password = userData[1];
                        string level = userData[2];

                        // Initialize new member
                        Member member = new Member(userName, password, Member.MembershipLevel.None);

                        // Set member to correct level
                        switch (level)
                        {
                            case "Gold":

                                member = new Member(userName, password, Member.MembershipLevel.Gold);
                                break;

                            case "Silver":

                                member = new Member(userName, password, Member.MembershipLevel.Silver);
                                break;

                            case "Bronze":
                                member = new Member(userName, password, Member.MembershipLevel.Bronze);
                                break;

                            case "None":
                                member = new Member(userName, password, Member.MembershipLevel.None);                
                                break;

                               
                        }

                        // Add member to list
                        membersInFile.Add(member);
                    }
                }
            }

            return membersInFile;

        }
    }
}

       

    
