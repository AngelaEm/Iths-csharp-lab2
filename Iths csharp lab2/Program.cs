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

        public static List<Member> ListWithMembers;


        static void Main(string[] args)
        {
          
            MenuManager.Start();

            string fileName = "textFile.txt";
            
            ListWithMembers = UploadMembersFromTextFile(fileName);

            MenuManager.MainMenu(MenuManager.MenuDesign(MenuManager.mainMenuChoices));
          
        }
    

        /// <summary>
        /// Gets customers that are saved in textfile.
        /// </summary>
        /// <param name="fileName">Name of textfile to read from</param>
        /// <returns>A list of Customers saved in file</returns>
        public static List<Member> UploadMembersFromTextFile(string fileName)
        {
            List<Member> membersInFile = new List<Member>();

            // Read all lines from textfile.
            string[] lines = File.ReadAllLines(fileName);

            // Iterates trough each line 
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // Where to split the userData
                    string[] userData = line.Split(',');

                    
                    // To make sure there is both username and password
                    if (userData.Length == 3)
                    {
                        string userName = userData[0];
                        string password = userData[1];
                        string level = userData[2];
                        Member member = new Member(userName, password, Member.MembershipLevel.None);

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

                        membersInFile.Add(member);
                    }
                }
            }

            return membersInFile;

        }
    }
}

       

    
