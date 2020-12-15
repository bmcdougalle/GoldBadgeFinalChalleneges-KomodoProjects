using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings_Repo
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
     public class CompanyOutings
     {
        public EventType TypeOfEvent { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime EventDate { get; set; }
        public decimal TotalCostPerPerson { get; set; }
        public decimal TotalCostOFEvent { get; set; }


        public CompanyOutings() { }
        public CompanyOutings(EventType eventType, int numberOfAttendes, DateTime eventDate, decimal totalCostPerPerson, decimal totalCostOfEvent)
        {
            TypeOfEvent = eventType;
            NumberOfAttendees = numberOfAttendes;
            EventDate = eventDate;
            TotalCostPerPerson = totalCostOfEvent;

        }
     }
}
