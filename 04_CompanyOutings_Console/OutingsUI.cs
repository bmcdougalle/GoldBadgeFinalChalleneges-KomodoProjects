using _04_CompanyOutings_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings_Console
{
   public class OutingsUI
   {
    
        private readonly companyOutings_Repo repo = new companyOutings_Repo();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool ShowMenu = true;
            while (ShowMenu)
            {
                Console.WriteLine($"Company Outings Manager\n\n" +
                                  $"1. Display Outings\n" +
                                  $"2. Add Outing\n" +
                                  $"3. Calculations\n" +
                                  $"4. exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        //displayoutings
                        break;
                    case "2":
                        //addouting
                        break;
                    case "3":
                        //calculations
                        break;
                    case "4":
                        Console.WriteLine("Have a Nice Day!");
                        ShowMenu = false;
                        break;
                }
            }
        }
        private void DisplayOutings()
        {
            Console.Clear();
            List<CompanyOutings> companyOutings = repo.ShowCompanyOutings();
            foreach(CompanyOutings outing in companyOutings)
            {
                Console.WriteLine($"");
            }
        }
   }
}
