using System.Collections.Generic;

namespace Jobbply__Final_Project.Models
{
    public class Timers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int FindId { get; set; }
        //public Find find { get; set; }
        public List<PosterTimes> PostTimes { get; set; }
    }
}
