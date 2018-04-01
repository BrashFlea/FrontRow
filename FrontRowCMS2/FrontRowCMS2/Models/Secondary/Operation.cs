using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public class Operation
    {
        public int ID { get; set; }
        public string TextArea1 { get; set; }
        public string TextArea2 { get; set; }
        public TextSubContent Operation1 { get; set; }
        public TextSubContent Operation2 { get; set; }
        public TextSubContent Operation3 { get; set; }
    }
}
