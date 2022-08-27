using System.Collections;
using System.Collections.Generic;

namespace Jobbply__Final_Project.Models
{
    public class Find
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Timers> timers { get; set; }
    }
}
