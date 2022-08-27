using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class AboutVM
    {
        public About about { get; set; }
        public Welcome welcome { get; set; }
        public IEnumerable<JobStatistics> jobStatistics { get; set; }
        //public IEnumerable<Testimonial_Slider> testimonial_Sliders { get; set; }
        public IEnumerable<ClientSlider> clientSliders { get; set; }
    }
}
