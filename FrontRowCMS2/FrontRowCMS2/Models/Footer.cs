using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models
{
    public class Footer
    {
        public int ID { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string ShelterAddressLine1 { get; set; }
        public string ShelterAddressLine2 { get; set; }
        public string HomeImage { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string TumblrLink { get; set; }
        public string FacebookLink { get; set; }

    }
}
