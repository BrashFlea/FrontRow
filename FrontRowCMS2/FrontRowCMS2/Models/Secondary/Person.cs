using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public enum PersonType
    {
        Director,Staff,Both
    }

    public class Person
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Email { get; set; }
        public PersonType Type { get; set; }
        
    }
}
