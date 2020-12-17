using _03_Badges_Repo;
using System;
using System.Collections.Generic;

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
            Console.WriteLine("Please input a BadgeId");

            int inputBadgeId = int.Parse(Console.ReadLine());
            badge.BadgeID = inputBadgeId;

            AddDoorAccess(badge);
            badges_Repo.AddBadgesToDict(badge);
        }
        private void UpdateABadge()
        {
            Console.WriteLine("Enter The Badge ID you would Like To Edit.");
            string inputId = Console.ReadLine();
            Badges badge = null;
            bool validInput = true;
            while (validInput)
            {
                if (!int.TryParse(inputId, out int badgeId))
                {
                    Console.WriteLine("Please Enter a Valid ID Number");
                }
                else
                {
                    inputId = badgeId.ToString();
                    badge = badges_Repo.GetBadgeById(badgeId);
                    validInput = false;
                }
                ShowDoorAccess(badge);
            }
            bool RevealDoors = true;
            while (RevealDoors)
            {

                Console.WriteLine("What Would You Like To DO?\n\n" +
                              "1. Add Door\n" +
                              "2. Remove Door\n" +
                              "3. Exit");
                string choiceUser = Console.ReadLine();
                switch (choiceUser)
                {
                    case "1":
                        Console.Clear();
                        ShowDoorAccess(badge);
                        AddDoorAccess(badge);
                        break;
                    case "2":
                        Console.Clear();
                        ShowDoorAccess(badge);
                        RemoveDoorAccess();
                        validInput = false;
                        RevealDoors = false;
                        break;
                    case "3":
                        Console.Clear();
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


                if (isSuccessful)
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
            Console.WriteLine($"BadgeId : {badges.BadgeID}");
            foreach (var door in badges.Doors)
            {
                Console.WriteLine($"Door Name: {door}");
            }
        }
        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badges> _badges = badges_Repo.ShowAllBadges();
            foreach (var badge in _badges)
            {
                Console.WriteLine(badge.Key);
                ShowDoorAccess(badge.Value);

            }

        }
        private void SeedList()
        {

            Badges badge1 = new Badges(1, new List<string> { "A5", "C10" });
            Badges badge2 = new Badges(300, new List<string> { "A7", "C1" });
            Badges badge3 = new Badges(12, new List<string> { "A9", "C101" });


            badges_Repo.AddBadgesToDict(badge1);
            badges_Repo.AddBadgesToDict(badge2);
            badges_Repo.AddBadgesToDict(badge3);
        }
    }
}
