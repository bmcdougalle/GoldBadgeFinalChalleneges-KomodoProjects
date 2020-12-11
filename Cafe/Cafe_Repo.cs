using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Cafe_Repo
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();

        //create

        public void CreateItem(MenuItem item)
        {
            _menuItems.Add(item);
        }

        //read
        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        //update
        public bool UpdateMenuItems(int itemNumber, MenuItem newItem)
        {
            MenuItem oldItem = GetItem(itemNumber);
            if(oldItem != null)
            {
                oldItem.ItemNumber = newItem.ItemNumber;
                oldItem.ItemName = newItem.ItemName;
                oldItem.Description = newItem.Description;
                oldItem.Price = newItem.Price;
                oldItem.Ingredients = newItem.Ingredients;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteItems(int itemNumber)
        {
            MenuItem menuItem = GetItem(itemNumber);
            {
                if(menuItem == null)
                {
                    return false;
                }

                int intialCount = _menuItems.Count;
                _menuItems.Remove(menuItem);

                if(intialCount > _menuItems.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }



        //helpermethod
        public MenuItem GetItem(int idNumber)
        {
            foreach (var item in _menuItems)
            {
                if(item.ItemNumber == idNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public List<MenuItem> GetIngredients()
        {
            List<MenuItem> items = new List<MenuItem>();
            foreach (var item in _menuItems)
            {
                if(item.Ingredients == item.Ingredients)
                {
                    
                }
            }
        }
        

	}
}

