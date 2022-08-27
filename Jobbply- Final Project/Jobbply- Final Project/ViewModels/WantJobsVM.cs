using Jobbply__Final_Project.Models;
using System.Collections;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class WantJobsVM
    {
        public About about { get; set; }
        public IEnumerable<Timers> timers { get; set; }
        public IEnumerable<Find> finds { get; set; }
       
        public IEnumerable<TopCategory> topCategories { get; set; }
    }
}
