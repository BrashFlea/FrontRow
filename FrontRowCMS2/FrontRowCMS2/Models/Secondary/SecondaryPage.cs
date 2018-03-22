using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class SecondaryPage
    {
        public int ID { get; set; }
        //public SecondaryHeader secondaryHeader { get; set; }
        public History History { get; set; }
        public Operation Operation { get; set; }
        //public Outreach Outreach { get; set; }
        public Person Directors { get; set; }
        public Person Staff { get; set; }
        //public Media Media { get; set; }
        public Donors Donors { get; set; }
        public Donate Donate { get; set; }
        //public ListOfNeeds ListOfNeeds { get; set; }
        //public Calendar Calendar { get; set; }
        //public ContactInfo ContactInfo { get; set; }
        public Footer Footer { get; set; }

    }
}
