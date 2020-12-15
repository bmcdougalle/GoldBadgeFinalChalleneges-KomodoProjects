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
                        ViewAllBadges();
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
            AddDoorAccess(badge);
            badges_Repo.AddBadgesToDict( badge);
        }
        private void UpdateABadge()
        {
            Console.WriteLine("Enter The Badge ID you would Like To Edit.");
            string inputId = Console.ReadLine();
            Badges badge = null;
            bool validInput = true;
            while (validInput)
            {
                if(!int.TryParse(inputId, out int badgeId))
                {
                    Console.WriteLine("Please Enter a Valid ID Number");
                }
                else
                {
                    inputId = badgeId.ToString();
                    badge =badges_Repo.GetBadgeById(badgeId);
                    validInput = false;
                }
               ShowDoorAccess(badge);
            }
            bool RevealDoors = true;
            while(RevealDoors)
            {
               
                Console.WriteLine("What Would You Like To DO?\n\n" +
                              "1. Add Door\n" +
                              "2. Remove Door\n" +
                              "3. Exit");
                string choiceUser = Console.ReadLine();
               switch (choiceUser)
               {
                    case "1":
                        AddDoorAccess(badge);
                        break;
                    case "2":
                        
                        RemoveDoorAccess();
                        validInput = false;
                        RevealDoors = false;
                        break;
                    case "3":
                        Menu();
                        RevealDoors = false;
                        break;
                    
               }
            }
        }
        private void AddDoorAccess(Badges badges)
        {
            bool addDoor = true;
            while (addDoor)
            {
               
                Console.WriteLine("What Door Would You Like to add?");
                string usersInput = Console.ReadLine();
                badges.Doors.Add(usersInput);


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
            
           
            bool doorRemoval = true;
            while (doorRemoval)
            {
               
                Console.WriteLine("Please input a Badge Id");
                int inputDoor = int.Parse(Console.ReadLine());

                Badges badges = badges_Repo.GetBadgeById(inputDoor);

                Console.WriteLine("Please enter the name of the door.");
                string inputDoorName = Console.ReadLine();

                bool isSuccessful = badges_Repo.RemoveDoor(badges, inputDoorName);
               

                if(isSuccessful )
                {
                    Console.WriteLine("Door was Removed");
                    doorRemoval = false;
                }
                else
                {
                    Console.WriteLine("Could Not Remove");
                    doorRemoval = false;
                }
                

            }
        }
        

        private void ShowDoorAccess(Badges badges)
        {
            Console.WriteLine($"{badges.BadgeID}");
            foreach (var door in badges.Doors)
            {
                Console.WriteLine(door);
            }
        }
        private void ViewAllBadges()
        {
            Console.Clear();
           Dictionary<int, Badges> _badges = badges_Repo.ShowAllBadges();
            string[] headerColumns = { "Door Access", "BadgeId" };
            Console.WriteLine("{0,5} {1, 5}", headerColumns[0], headerColumns[1]);
            foreach(var badge in _badges)
            { 
                foreach (var door in badge.Value.Doors)
                {
                    Console.WriteLine( door);
                }

                Console.WriteLine("{0,15}", badge.Value.BadgeID);
            }


        }
        private void SeedList()
        {
            List<string> doors = new List<string>();
            doors.Add("A5");
            doors.Add("C10");

            List<string> doors1 = new List<string>();
            doors.Add("A5");
            doors.Add("C10");

            List<string> doors2 = new List<string>();
            doors.Add("A5");
            doors.Add("C10");
            Badges badge1 = new Badges( doors);
            Badges badge2 = new Badges( doors1);
            Badges badge3 = new Badges( doors2);

            badges_Repo.AddBadgesToDict( badge1);
            badges_Repo.AddBadgesToDict( badge2);
            badges_Repo.AddBadgesToDict( badge3);
        }
    }
}
