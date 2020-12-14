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
                        CreateBadge();
                        break;
                    case "2":
                        UpdateABadge();
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
            Console.Clear();
            Badges badge = new Badges();

            Console.WriteLine("Enter A New Badge ID");
            string userInput = Console.ReadLine();
            bool validInput = false;
            while (validInput)
            {
                if(!int.TryParse(userInput, out int userId))
                {
                    Console.WriteLine("Not a Valid ID");
                }
                else
                {
                    badge.BadgeID = userId;
                    validInput = true;
                }
            }

            AddDoorAccess();
            badges_Repo.AddBadgesToDict(badge.BadgeID, badge);
        }
        private void UpdateABadge()
        {
            Console.WriteLine("Enter The Badge ID you would Like To Edit.");
            string inputId = Console.ReadLine();
            bool validInput = false;
            while (validInput)
            {
                if(!int.TryParse(inputId, out int badgeId))
                {
                    Console.WriteLine("Please Enter a Valid ID Number");
                }
                else if (badgeId.Equals(0))
                {
                    Console.WriteLine("Id can not be 0");
                }
                else
                {
                  badges_Repo.GetBadgeById(badgeId);
                    validInput = true;
                }
            }

            bool RevealDoors = true;
            while(RevealDoors)
            {   Console.WriteLine("What Would You Like To DO?\n\n" +
                              "1. Add Door\n" +
                              "2. Remove Door\n" +
                              "3. Exit");
                string choiceUser = Console.ReadLine();
               switch (choiceUser)
               {
                    case "1":
                        AddDoorAccess();
                        break;
                    case "2":
                        RemoveDoorAccess();
                        break;
                    case "3":
                        Menu();
                        RevealDoors = false;
                        break;
                    
               }
            }
        }
        private void AddDoorAccess()
        {
            bool addDoor = true;
            while (addDoor)
            {
                Badges badge = new Badges();
                Console.WriteLine("What Door Would You Like to add?");
                string usersInput = Console.ReadLine();
                badge.Doors.Add(usersInput);


                Console.WriteLine("Would You Like To Add another Door?");
                string userChoice = Console.ReadLine();
                bool validChoice = true;
                while (validChoice)
                {
                    if (userChoice == "y" || userChoice == "Y")
                    {
                        validChoice = false;

                    }
                    else if (userChoice == "n" || userChoice == "N")
                    {
                        validChoice = false;
                        addDoor = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter y/n");
                    }
                }
            }
            

        }
        private void RemoveDoorAccess()
        {
            Badges badge = new Badges();
            bool doorRemoval = true;
            while (doorRemoval)
            {
                
                Console.WriteLine("Enter A Door you would like to remove?");
                string inputDoor = Console.ReadLine();

            }
        }
        private void ViewAllBadges()
        {

        }
        private void SeedList()
        {
            Badges badge1 = new Badges(123, List<Badges>)
        }
    }
}
