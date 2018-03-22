using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class Outreach
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string TextArea1 { get; set; }
        public string TextArea2 { get; set; }
        public string TextArea3 { get; set; }
        public List<string> outreachTable { get; set; }
    }
}
