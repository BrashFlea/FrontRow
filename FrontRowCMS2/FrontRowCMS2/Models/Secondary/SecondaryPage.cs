using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class SecondaryPage
    {
        public int ID { get; set; }
        public SecondaryHeader SecondaryHeader { get; set; }
        public History History { get; set; }
        public Operation Operation { get; set; }
        public Outreach Outreach { get; set; }
        public List<Person> Directors { get; set; }
        public List<Person> Staff { get; set; }
        public MediaEvent MediaEvent { get; set; }
        public List<Donor> PlatinumDonors { get; set; }
        public List<Donor> GoldDonors { get; set; }
        public List<Donor> SilverDonors { get; set; }
        public List<Donor> BronzeDonors { get; set; }
        public Donate Donate { get; set; }
        public Needs ListOfNeeds { get; set; }
        public Calendar Calendar { get; set; }
        //public ContactInfo ContactInfo { get; set; }
        public Footer Footer { get; set; }
    }
}
