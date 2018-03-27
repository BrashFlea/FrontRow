using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontRowCMS2.Models.Secondary
{
    public enum DonorType
    {
        Platinum, Gold, Silver, Bronze
    }
    public class Donor
    {
        public int ID { get; set; }
        public DonorType Level { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
    }
}
