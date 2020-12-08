using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuItem

    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }


        public MenuItem() { }

        public MenuItem(int itemNumber, string itemName, string description, double price, string ingredients)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
