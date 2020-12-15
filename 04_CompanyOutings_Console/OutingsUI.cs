using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings_Console
{
   public class OutingsUI
   {
        public void Run()
        {

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
            }
        }
   }
}
