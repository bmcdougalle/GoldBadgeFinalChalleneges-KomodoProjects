using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badges_Repo
    {
        private readonly Dictionary<int, Badges> _Badges = new Dictionary<int, Badges>(); 

        public void AddBadgesToDict(int badgeId, Badges badge)
        {
            _Badges.Add(badgeId, badge);
        }
        public Dictionary<int, Badges> ShowAllBadges()
        {
            return _Badges;
        }
        public bool UpdateBadges(int badgeId, Badges newBadge)
        {
            Badges oldBadge = GetBadgeById(badgeId);
            if(oldBadge != null)
            {
                oldBadge.Doors = newBadge.Doors;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveBadge(int badgeId)
        {
            Badges badge = GetBadgeById(badgeId);
            {
                if(badge == null)
                {
                    return false;
                }

                int initialCount = _Badges.Count;
                _Badges.Remove(badgeId);

                if(initialCount > _Badges.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public Badges GetBadgeById(int badgeId)
        {
            foreach (var badge in _Badges)
            {
                if(badge.Key == badgeId)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }
}
