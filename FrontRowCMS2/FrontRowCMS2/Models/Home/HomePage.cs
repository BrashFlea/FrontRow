using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Home
{
    public class HomePage
    {
        public int ID { get; set; }
        public Header Header { get; set; }
        public Purpose Purpose { get; set; }
        public Services Services { get; set; }
        public BottomHomePage BottomHomePage { get; set; }
    }
}
