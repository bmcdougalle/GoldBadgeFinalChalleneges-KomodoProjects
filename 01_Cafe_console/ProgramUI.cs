using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_console
{
    public class ProgramUI
    {
        private readonly Cafe_Repo _cafe_Repo = new Cafe_Repo();

        public void Run()
        {
            SeedList();
            CafeMenu();
        }
        //menu

        private void CafeMenu()
        {
            bool showing = true;
            while (showing)
            {
                Console.WriteLine($"Welcome to Komodo Menu\n" +
                             $"**********************\n" +
                             $"**********************\n\n\n\n" +
                             $"1. Create Menu Item\n\n" +
                             $"2. View All Menu Items\n\n" +
                             $"3. Remove Menu Items\n\n" +
                             $"4. Update Existing Menu Item\n\n" +
                             $"5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        ViewAllItems();
                        break;
                    case "3":
                        RemoveItem();
                        break;
                    case "4":
                        UpdateMenuItems();
                        break;
                    case "5":
                        Console.WriteLine("Have Wonderful Day!");
                        showing = false;
                        break;
                    
                }
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void AddItemToMenu()
        {
            Console.Clear();
            MenuItem menuItem = new MenuItem();

            Console.WriteLine("Enter the Item Number");
            string intAsString = Console.ReadLine();
            menuItem.ItemNumber = int.Parse(intAsString);

            Console.WriteLine("Enter The Name for the Item");
            menuItem.ItemName = Console.ReadLine();

            Console.WriteLine("Enter The Description");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter The Price for the Item");
            string doubleAsString = Console.ReadLine();
            menuItem.Price = double.Parse(doubleAsString);

            Console.WriteLine("Enter The Ingredients");
            string listOfIngredients = Console.ReadLine();
            menuItem.Ingredients.Add(listOfIngredients);


            _cafe_Repo.CreateItem(menuItem);
        }
        private void ViewAllItems()
        {
            Console.Clear();
            List<MenuItem> menuItems = _cafe_Repo.GetMenuItems();
            foreach(MenuItem menuItem in menuItems)
            {
                Console.WriteLine($"Item Number: {menuItem.ItemNumber}\n\n" +
                                  $"Item Name:  {menuItem.ItemName}\n\n" +
                                  $"Item Decription: {menuItem.Description}\n\n" +
                                  $"Item Price: {menuItem.Price}\n\n" +
                                  $"Item Ingredients: {menuItem.Ingredients}\n" +
                                  $"***************************************\n" +
                                  $"***************************************");
            }
        }
        private void UpdateMenuItems()
        {
            ViewAllItems();
            Console.WriteLine("Enter the item number you wish to Update");
            int oldItem = int.Parse(Console.ReadLine());
            Console.Clear();

            MenuItem newItem = new MenuItem();

            Console.WriteLine("Enter The Item Name");
            newItem.ItemName = Console.ReadLine();

            Console.WriteLine("Enter a description of the item");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the Price of the item");
            newItem.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new ingredients");
            string usersInput = Console.ReadLine();
            newItem.Ingredients.Add(usersInput);

            bool itemUpdated = _cafe_Repo.UpdateMenuItems(oldItem, newItem);
            if (itemUpdated)
            {
                Console.WriteLine("Item Updated for the menu");
            }
            else
            {
                Console.WriteLine("Could not update item");
            }

            _cafe_Repo.UpdateMenuItems(oldItem, newItem);
        }
        private void RemoveItem()
        {
            ViewAllItems();
            Console.WriteLine("Enter The number Of the Item You want To Remove");
            int itemInput = int.Parse(Console.ReadLine());
            bool itemRemoved = _cafe_Repo.DeleteItems(itemInput);
            if (itemRemoved)
            {
                Console.WriteLine("Item Successfully Removed");
            }
            else
            {
                Console.WriteLine("Could Not Remove Item");
            }
        }

        private void SeedList()
        {
            MenuItem HotCoffee = new MenuItem(1, "Hot Coffee", "Medium Roast Coffee with your choice of creamer", 0.55,
                new List<string>() { "medium roast coffee grounds", "your choice of creamer"});
            MenuItem NachosNCheese = new MenuItem(2, "Nachos N Cheese", "Nacho chips, fresh Queso", 4.50,
                new List<string>() { "chips", "fresh", "queso with pepperJack cheese" });
            MenuItem CheeseBurger = new MenuItem(3, "Cheeseburger Deluxe", "Delicious Freshly made Cheeseburger with your choice of toppings.", 5.95, 
                new List<string>() { "Ground Chuck hamburger", "pepper", "meat tenderizer", "tomato", "lettuce", "onion", "your cheese of American, PepperJack, Colby Jack cheese" });

            _cafe_Repo.CreateItem(HotCoffee);
            _cafe_Repo.CreateItem(NachosNCheese);
            _cafe_Repo.CreateItem(CheeseBurger);
        }

    }
}
