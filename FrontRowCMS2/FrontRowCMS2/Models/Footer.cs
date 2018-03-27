using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models
{
    public class Footer
    {
        public int ID { get; set; }
        [EmailAddress]
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }
        [DisplayName("Mailing Address Line:1")]
        public string MailingAddressLine1 { get; set; }
        [DisplayName("Mailing Address Line:2")]
        public string MailingAddressLine2 { get; set; }
        [DisplayName("Shelter Address Line:1")]
        public string ShelterAddressLine1 { get; set; }
        [DisplayName("Shelter Address Line:2")]
        public string ShelterAddressLine2 { get; set; }
        [DisplayName("Footer Image")]
        public string HomeImage { get; set; }
        [DisplayName("Instagram Link")]
        public string InstagramLink { get; set; }
        [DisplayName("Twitter Link")]
        public string TwitterLink { get; set; }
        [DisplayName("Tumblr Link")]
        public string TumblrLink { get; set; }
        [DisplayName("Facebook Link")]
        public string FacebookLink { get; set; }

    }
}
