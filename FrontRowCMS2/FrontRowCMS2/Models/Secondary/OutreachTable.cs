using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class OutreachTable
    {
        public int ID { get; set; }
        public int OutreachID { get; set; }
        public Outreach Outreach { get; set; }
        public string Location { get; set; }
    }
}
