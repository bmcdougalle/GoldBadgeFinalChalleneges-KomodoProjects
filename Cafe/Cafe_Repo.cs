using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Cafe_Repo
    {
        private readonly List<MenuItem> _MenuItems = new List<MenuItem>();

        //create

        public void CreateItem(MenuItem item)
        {
            _MenuItems.Add(item);
        }
    }
}
