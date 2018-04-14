using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class ContactInfo
    {
        public int ID { get; set; }
        public string Header1 { get; set; }
        public string PhoneNumber { get; set; }
        public string Header2 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
}