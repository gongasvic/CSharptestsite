using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class CalendarEvent
    {
        public int ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string location { get; set; }
        public string nome { get; set; }
        public string content { get; set; }
       

        public override string ToString()
        {
            return "Event"+ nome +" at " + startDate.ToString() +" at: "+ location;
        }

    }
}