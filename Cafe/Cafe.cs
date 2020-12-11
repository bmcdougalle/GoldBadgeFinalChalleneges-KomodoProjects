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
        public List<string> Ingredients { get; set; } = new List<string>();

        public MenuItem() { }

        public MenuItem(int itemNumber, string itemName, string description, double price, List<string> ingredients)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
