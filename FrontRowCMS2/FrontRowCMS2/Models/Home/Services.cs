using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Home
{
    public class Services
    {
        public int ID { get; set; }
        public string MainText { get; set; }
        public LinkSubContent Service1 { get; set; }
        public LinkSubContent Service2 { get; set; }
        public LinkSubContent Service3 { get; set; }
    }
}
