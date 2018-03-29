using FrontRowCMS2.Models.Home;
using FrontRowCMS2.Models.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models
{
    public class Page
    {
        public int ID { get; set; }

        public SecondaryPage SecondaryPage { get; set; }
        public HomePage HomePage { get; set; }
        public Footer Footer { get; set; }
    }
}
