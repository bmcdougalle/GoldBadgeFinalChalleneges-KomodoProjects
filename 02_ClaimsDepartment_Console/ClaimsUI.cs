using ClaimsDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsDepartment_Console
{
   public class ClaimsUI
   {
        private readonly Claims_repo claims_Repo = new Claims_repo();

        public void Run()
        {
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
                        //TakeCareOfNExtClaim
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
            Queue<Claims> claims = claims_Repo.ViewClaims();
            var header = string.Format("{ 0, 8} { 1, 8} { 2, 35}  { 3, 10} { 4, 20} {5, 20} {6, 15}", "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date Of Incident", "Date Of Claim", "Is this A Valid Claim?");
            Console.WriteLine(header);
            foreach (var claim in claims)
            {
                var claimData = string.Format("{ 0, 8} { 1, 8}  { 2, 35} { 3, 10} { 4, 20} { 5, 20}    { 6, 15} ", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmount, claim.DateOfIncident.Date.ToString("d"), claim.DateOfClaim.Date.ToString("d"), claim.IsValid);
                Console.WriteLine(claimData);
               
            }
            
        }
        private void TakeCareOfNextClaim()
        {
            Queue<Claims> claims = new Queue<Claims>();
            while (true)
            {

            }
            Claims claimsToTakeOF = claims.Dequeue();
        }
        private void EnterANewClaim()
        {
            Console.Clear();
            Claims claim = new Claims();
            Queue<Claims> _Claims= new Queue<Claims>();

            Console.WriteLine("Enter The Claim ID");
            string userInput = Console.ReadLine();
            int claimId;
            if(int.TryParse(userInput, out claimId)) 
            {
                if(claimId < 1 || claimId > 100)
                {
                    Console.WriteLine("Sorry idNumber was out of range");
                }
                else
                {
                    Console.WriteLine("That was not a recognized number");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry was not a valid Input");
            }
            claim.ClaimID = claimId;

            bool validInput = false;
            int validSelection = 0;
            while (!validInput)
            {
                Console.WriteLine("Enter The Number for the type of claim it is\n\n" +
                              "1. Car\n" +
                              "2. Home\n" +
                              "3. Theft");
                string inputFromUser = Console.ReadLine();
                if(!int.TryParse(inputFromUser, out validSelection))
                {
                    Console.WriteLine("Input was not a valid selection");
                }
                else if (validSelection.Equals(0))
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
            decimal amount;
            while (!validAmount)
            {
                Console.WriteLine("Please Enter the amount of the Claim");
                string clAmount = Console.ReadLine();
                if(!decimal.TryParse(clAmount, out amount))
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
            DateTime incidentDate;
            while (!validDate)
            {
                Console.WriteLine("Please enter the Date and Time of incident (yyyy/mm/dd 00:00)");
                string mDateTime = Console.ReadLine();
                if(!DateTime.TryParse(mDateTime, out incidentDate))
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
            DateTime dateofClaim;
            while (!validDateOfClaim)
            {
                Console.WriteLine("Please enter the Date of The Claim ex.(yyyy/mm/dd");
                string inputDateOfClaim = Console.ReadLine();
                if(!DateTime.TryParse(inputDateOfClaim, out dateofClaim))
                {
                    Console.WriteLine("Not a Valid Input");
                }
                else
                {
                    claim.DateOfClaim = dateofClaim;
                    validDateOfClaim = true;
                }
            }

            DateTime current = DateTime.Now;
            bool isValidNow = false;
            while (!isValidNow)
            {
                bool isvalid = true;
                bool isNotValid = true;
                var timeSpan2 = 30;
                var validClaim = DateTime.Now - claim.DateOfClaim;
                var timeSpan = validClaim.TotalDays;
                if(timeSpan > timeSpan2)
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
            _Claims.Enqueue(claim);
            
            
            


        }
   }
}
