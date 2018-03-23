using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class Calendar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<CalendarMonths> Month { get; set; }
    }
}
