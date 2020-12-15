using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings_Repo
{
    public class companyOutings_Repo
    {
        private readonly List<CompanyOutings> _companyOutings = new List<CompanyOutings>();

        public void AddOuting(CompanyOutings outing)
        {
            _companyOutings.Add(outing);
        }

        public List<CompanyOutings> ShowCompanyOutings()
        {
            return _companyOutings;
        }


        public bool UpdateOutings(string eventName, CompanyOutings newOuting)
        {
            CompanyOutings oldOuting = GetOuting(eventName);
            if (oldOuting != null)
            {
                oldOuting.EventName = newOuting.EventName;
                oldOuting.TypeOfEvent = newOuting.TypeOfEvent;
                oldOuting.NumberOfAttendees = newOuting.NumberOfAttendees;
                oldOuting.EventDate = newOuting.EventDate;
                oldOuting.TotalCostPerPerson = newOuting.TotalCostPerPerson;
                oldOuting.TotalCostOFEvent = newOuting.TotalCostOFEvent;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteOuting(string eventName)
        {
            CompanyOutings outing = GetOuting(eventName);
            {
                if(outing == null)
                {
                    return false;
                }

                int initialCount = _companyOutings.Count;
                _companyOutings.Remove(outing);

                if(initialCount > _companyOutings.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }








        public CompanyOutings GetOuting(string eventName)
        {
            foreach (var outing in _companyOutings)
            {
                if(outing.EventName == eventName)
                {
                    return outing;
                }
            }
            return null;
        }
    }
}
