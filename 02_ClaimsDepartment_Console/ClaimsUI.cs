using ClaimsDepartment;
using System;
using System.Collections.Generic;

namespace _02_ClaimsDepartment_Console
{
    public class ClaimsUI
    {
        private readonly Claims_repo claims_Repo = new Claims_repo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine($"Komodo Claims\n\n\n" +
                                  $"1. View All Claims\n\n" +
                                  $"2. Take Care of Next Claim\n\n" +
                                  $"3. Enter A New Claim\n\n" +
                                  $"4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Have a Nice Day");
                        showMenu = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claims> _claims = claims_Repo.ViewClaims();
            string[] headerColumns = { "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date Of Incident", "Date Of Claim", "Is This A Valid Claim?" };
            Console.WriteLine("{0,10} {1, 20} {2,30}  {3, 10} {4, 25} {5, 25} {6, 35}", headerColumns[0], headerColumns[1], headerColumns[2], headerColumns[3], headerColumns[4], headerColumns[5], headerColumns[6]);

            foreach (var claim in _claims)
            {
                int id = claim.ClaimID;
                ClaimType type = claim.TypeOfClaim;
                string description = claim.Description;
                decimal amount = claim.ClaimAmount;
                DateTime dateOfIncident = claim.DateOfIncident;
                DateTime dateOfClaim = claim.DateOfClaim;
                bool isValid = claim.IsValid;


                Console.WriteLine($"{id,10} { type,20}  { description,30} { amount,10} { dateOfIncident,30} { dateOfClaim,30} { isValid,15}");


            }

        }
        private void TakeCareOfNextClaim()
        {
            Queue<Claims> claims = claims_Repo.ViewClaims();
            Claims claim = claims.Peek();
            Console.WriteLine($"Claim Id: {claim.ClaimID} \n" +
                              $"Claim Type: {claim.TypeOfClaim}\n" +
                              $"Claim Description: {claim.Description}\n" +
                              $"Claim Amount: {claim.ClaimAmount}\n" +
                              $"Date Of Incident: {claim.DateOfIncident}\n" +
                              $"Date Of Claim: {claim.DateOfClaim}\n" +
                              $"Is This Claim Valid?: {claim.IsValid}");
            Console.WriteLine("Would you like to take care of this claim?");
            string inputChoice = Console.ReadLine();
            if (inputChoice == "y" || inputChoice == "Y")
            {
                claims.Dequeue();
                Menu();
            }
            else if (inputChoice == "n" || inputChoice == "N")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Please Enter a valid Response");
            }

        }
        private void EnterANewClaim()
        {
            Console.Clear();
            Claims claim = new Claims();

            Console.WriteLine("Enter The Claim ID");
            string userInput = Console.ReadLine();
            int claimId;
            if (!int.TryParse(userInput, out claimId))
            {
                Console.WriteLine("Please Try Again");
            }
            else
            {
                claim.ClaimID = claimId;
            }
            


            bool validInput = false;
            int validSelection = 0;
            while (!validInput)
            {
                Console.WriteLine("Enter The Number for the type of claim it is\n\n" +
                              "1. Car\n" +
                              "2. Home\n" +
                              "3. Theft");
                string inputFromUser = Console.ReadLine();
                if (!int.TryParse(inputFromUser, out validSelection))
                {
                    Console.WriteLine("Input was not a valid selection");
                }
                else if (validSelection < 1 || validSelection > 3)
                {
                    Console.WriteLine("Please enter a valid selection");
                }
                else
                {
                    validInput = true;
                }
            }
            claim.TypeOfClaim = (ClaimType)validSelection;

            Console.WriteLine("Please Enter A Description");
            claim.Description = Console.ReadLine();

            bool validAmount = false;
            while (!validAmount)
            {
                Console.WriteLine("Please Enter the amount of the Claim");
                string clAmount = Console.ReadLine();
                if (!decimal.TryParse(clAmount, out decimal amount))
                {
                    Console.WriteLine("Please enter a Valid Amount");
                }
                else
                {
                    claim.ClaimAmount = amount;
                    validAmount = true;
                }
            }

            bool validDate = false;
            while (!validDate)
            {
                Console.WriteLine("Please enter the Date and Time of incident (yyyy/mm/dd)");
                string mDateTime = Console.ReadLine();
                if (!DateTime.TryParse(mDateTime, out DateTime incidentDate))
                {
                    Console.WriteLine("Not a Valid input");
                }
                else
                {
                    claim.DateOfIncident = incidentDate;
                    validDate = true;
                }
            }

            bool validDateOfClaim = false;
            while (!validDateOfClaim)
            {
                Console.WriteLine("Please enter the Date of The Claim ex.(yyyy/mm/dd");
                string inputDateOfClaim = Console.ReadLine();
                if (!DateTime.TryParse(inputDateOfClaim, out DateTime dateofClaim))
                {
                    Console.WriteLine("Not a Valid Input");
                }
                else
                {
                    claim.DateOfClaim = dateofClaim;
                    validDateOfClaim = true;
                }
            }
            bool isValidNow = false;
            while (!isValidNow)
            {
                bool isvalid = true;
                bool isNotValid = false;
                var timeSpan2 = 30;
                var validClaim = claim.DateOfClaim - claim.DateOfIncident;
                var timeSpan = validClaim.TotalDays;
                if (timeSpan > timeSpan2)
                {
                    claim.IsValid = isNotValid;
                    isValidNow = true;
                }
                else
                {
                    claim.IsValid = isvalid;
                    isValidNow = true;

                }
            }
            claims_Repo.AddAClaim(claim);





        }

        private void SeedList()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Collision: font end damage", 5000.00m, DateTime.Parse("2020 / 02 / 05"), DateTime.Parse("2020 / 02 / 27"), true);
            Claims claim2 = new Claims(2, ClaimType.Theft, "Car Broken into stolen Radio", 600.00m, DateTime.Parse("2019 /05 / 05"), DateTime.Parse("2019 /05 / 31"), true);
            Claims claim3 = new Claims(3, ClaimType.Home, "Basement Flooded", 10000.00m, DateTime.Parse("2020 / 08 / 10"), DateTime.Parse("2020 / 08 / 15"), true);
            Claims claim4 = new Claims(4, ClaimType.Car, "simple fender bender", 600.00m, DateTime.Parse("2020 / 09/ 01"), DateTime.Parse("2020 / 10 / 02"), false);

            claims_Repo.AddAClaim(claim1);
            claims_Repo.AddAClaim(claim2);
            claims_Repo.AddAClaim(claim3);
            claims_Repo.AddAClaim(claim4);
        }
    }
}
