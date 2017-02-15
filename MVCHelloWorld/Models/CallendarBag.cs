using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class CallendarBag
    {
        public static List<CalendarEvent> Eventos = new List<CalendarEvent>();


        public List<CalendarEvent> GetEventos()
        {
            return Eventos;
        }


    }
}