using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class CalendarMonths
    {
        public int ID { get; set; }
        public int CalenderID { get; set; }
        public Calendar Calendar { get; set; }
        public ICollection<CalendarEvents> Event { get; set; }
        public String Month { get; set; }
        public String Year { get; set; }
    }
}
