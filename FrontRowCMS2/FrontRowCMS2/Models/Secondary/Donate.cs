using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class Donate
    {
        public int ID { get; set; }
        public string TextArea1 { get; set; }
        public string TextArea2 { get; set; }
        public TextSubContent Donate1 { get; set; }
        public TextSubContent Donate2 { get; set; }
        public TextSubContent Donate3 { get; set; }
    }
}
