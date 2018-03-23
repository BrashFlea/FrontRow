using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class CalendarEvents
    {
        public int ID { get; set; }
        public int MonthID { get; set; }
        public CalendarMonths Month { get; set; }
        public string Day { get; set; }
        public string What { get; set; }
        public string When { get; set; }
        public string Where { get; set; }
        public string Info { get; set; }
    }
}
