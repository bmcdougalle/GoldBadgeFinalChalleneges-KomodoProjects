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
                        //CreateNewClaim
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

        }
   }
}
