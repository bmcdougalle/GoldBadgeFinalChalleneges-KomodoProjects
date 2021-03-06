﻿using _04_CompanyOutings_Repo;
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
            SeedList();
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
                        DisplayOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        Calculations();
                        break;
                    case "4":
                        Console.WriteLine("Have a Nice Day!");
                        ShowMenu = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayOutings()
        {
            Console.Clear();
            List<CompanyOutings> companyOutings = repo.ShowCompanyOutings();
            foreach(CompanyOutings outing in companyOutings)
            {
                Console.WriteLine($"Event Name: {outing.EventName}\n" +
                                  $"EventType: {outing.TypeOfEvent}\n" +
                                  $"Number of Attendees: {outing.NumberOfAttendees}\n" +
                                  $"Date of Event: {outing.EventDate}\n" +
                                  $"Total Cost Per Person: {outing.TotalCostPerPerson}\n" +
                                  $"Total Cost of Event: {outing.TotalCostOFEvent}\n" +           
                                  
                                  $"*************************************************");
            }
        }
        private void AddOuting()
        {
            Console.Clear();
            CompanyOutings outing = new CompanyOutings();

            Console.WriteLine("Please enter the Name of the Event");
            outing.EventName = Console.ReadLine();

            bool eventType = false;
            int choice = 0;
            while (!eventType)
            {
                Console.WriteLine("What type of event is this?\n\n" +
                              "1. Golf\n" +
                              "2. Bowling\n" +
                              "3. Amusement Park\n" +
                              "4. Concert");
               string userChoice = Console.ReadLine();
                if(!int.TryParse(userChoice, out choice))
                {
                    Console.WriteLine("Invalid Option, please try again");
                }
                else if (choice < 1 || choice > 4)
                {
                    
                    Console.WriteLine("Incorrect selection");
                }
                else
                {
                    eventType = true;
                }
            }
            outing.TypeOfEvent = (EventType)choice;

            bool employeesAttending = false;
            int input = 0;
            while (!employeesAttending)
            {
                Console.WriteLine("Enter How Many Employees Will be Attending");
                string userInput = Console.ReadLine();
                if(!int.TryParse(userInput, out input))
                {
                    Console.WriteLine("Not a valid input, please try again");
                }
                else
                {
                    employeesAttending = true;
                }
            }
            outing.NumberOfAttendees = input;

            bool validDate = false;
            while (validDate)
            {
                Console.WriteLine("Please enter the Date and Time of event ex.(yyyy / mm / dd  00:00)");
                string inputDate = Console.ReadLine();
                if(!DateTime.TryParse(inputDate, out DateTime mDate))
                {
                    Console.WriteLine("Not a Valid Input");
                }
                else
                {
                    outing.EventDate = mDate;
                    validDate = true;
                }
            }

            bool validCostPerPerson = false;
            while (!validCostPerPerson)
            {
                Console.WriteLine("Please enter The cost Per Person");
                string perPerson = Console.ReadLine();
                if(!decimal.TryParse(perPerson , out decimal cost))
                {
                    Console.WriteLine("Please enter a valid input");
                }
                else
                {
                    outing.TotalCostPerPerson = cost;
                    validCostPerPerson = true;
                }
            }

            bool eventCost = false;
            while (!eventCost)
            {
                Console.WriteLine("Please enter The cost of the Event");
                string mcost = Console.ReadLine();
                if(!decimal.TryParse(mcost , out decimal costOfEvent))
                {
                    Console.WriteLine("Please enter a Valid input");
                }
                else
                {
                    outing.TotalCostOFEvent = costOfEvent;
                    eventCost = true;
                }
            }
            repo.AddOuting(outing);
        }
        private void Calculations()
        {
            bool CMenu = true;
            while (CMenu)
            {
                Console.Clear();
                Console.WriteLine("What Would you like to see?\n\n" +
                              "1. Combined Cost for all Outings\n" +
                              "2. Outings Cost by Type\n" +
                              "3. Exit");
                string userOption = Console.ReadLine();
                switch (userOption)
                {
                    case "1":
                        CombinedCost();
                        break;
                    case "2":
                        //outings by type
                        break;
                    case "3":
                        CMenu = false;
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        }
        //needs work/doesn't Display
        private void CombinedCost()
        {
            DisplayOutings();

            CompanyOutings outings = new CompanyOutings();
            decimal cCost = outings.TotalCostOFEvent + outings.TotalCostOFEvent;
            Console.WriteLine(cCost);
        }
        private void SeedList()
        {
            CompanyOutings WorkPlaceJam = new CompanyOutings("WorkPlaceJam", EventType.Concert, 20, DateTime.Parse("2021 / 05 / 22"), 20, 1000);
            CompanyOutings AtKingsIsland = new CompanyOutings("Claims For Coasters", EventType.AmusementPark, 50, DateTime.Parse("2021 / 08 / 10"), 60, 5000);


            repo.AddOuting(WorkPlaceJam);
            repo.AddOuting(AtKingsIsland);

        }
   }
}
