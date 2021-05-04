using System.Collections.Generic;

namespace DavidFacts
{
    public class DavidData
    {
        public static IEnumerable<DavidData> All { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        static DavidData()
        {
            All = new List<DavidData>()
            {
                new DavidData() { Title = "Early Years", Description = "He was born in Milwaukee, but grew up in Brazil.", Image = "boy.png"},
                new DavidData() { Title = "Sports", Description = "Started playing tennis at 10 years old.", Image = "tennis.png"},
                new DavidData() { Title = "Getting into Technology", Description = "URL of the first website he made was pingpongdude.com.br", Image = "data-management.png"},
                new DavidData() { Title = "Kids", Description = "Has two beautiful kids, and another on the way!", Image = "children.png"},
                new DavidData() { Title = "Summer Camp", Description = "Worked at a summer camp in Wautoma, WI for five summers.", Image = "tent.png"},
                
            };
        }
    }
}