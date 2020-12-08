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
        public bool DeleteItems(string name)
        {
            MenuItem menuItem = GetItem(name);
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
        public MenuItem GetItem(string name)
        {
            foreach (var item in _menuItems)
            {
                if(item.ItemName == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
