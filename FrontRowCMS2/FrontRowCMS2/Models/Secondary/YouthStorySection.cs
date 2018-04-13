using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrontRowCMS2.Models.Secondary
{
    public class YouthStorySection
    {
		public string Background { get; set; }
		public int ID { get; set; }
		public string Body { get; set; }
		public List<YouthStory> youthStories { get; set; }
    }
}
