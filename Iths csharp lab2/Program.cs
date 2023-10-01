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
        static void Main(string[] args)
        {
          
            // Displays welcomemessage and initializes four products
            MenuManager.Start();
            
            // Variable holding my textfile with logged in members
            string fileName = "textFile.txt";
            
            // Upload members from textfile to listWithCustomers
            UploadCustomersFromTextFile(fileName);

            // Display mainmenu
            MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));
          
        }
    

        /// <summary>
        /// Initializes customers that are saved in textfile.
        /// </summary>
        /// <param name="fileName">Name of textfile to read from</param>
        
        public static void UploadCustomersFromTextFile(string fileName)
        {

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
                       

                        // Set member to correct level
                        switch (level)
                        {
                            case "Gold":

                                Member member = new Member(userName, password, Member.MembershipLevel.Gold);
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
                    }
                }
            }
        }
    }
}

       

    
