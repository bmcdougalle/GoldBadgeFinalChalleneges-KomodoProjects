using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public  class Badges
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();


        public Badges() { }
        public Badges(int badgeId, List<string> doors)
        {
            BadgeID = badgeId;
            Doors = doors;
        }

        public Badges(List<string> doors)
        {
            
            Doors = doors;
        }

    }
}
