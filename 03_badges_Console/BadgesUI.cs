using _03_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_badges_Console
{
    public class BadgesUI
    {
        private readonly Badges_Repo badges_Repo = new Badges_Repo();
        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool revealMenu = true;
            while (revealMenu)
            {
                Console.WriteLine("Hello, Security Admin. What would you like to do?\n\n\n" +
                                  "1. Create Badge\n" +
                                  "2. Edit a Badge\n" +
                                  "3. View all Badges\n" +
                                  "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Createbadge
                        break;
                    case "2":
                        //Edit a Badge
                        break;
                    case "3":
                        //viewAllBadges
                        break;
                    case "4":
                        Console.WriteLine("Thank for using this service, Have a Nice Day");
                        revealMenu = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateBadge()
        {

        }
        private void UpdateABadge()
        {

        }
        private void ViewAllBadges()
        {

        }
        private void SeedList()
        {

        }
    }
}
