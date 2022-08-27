using Jobbply__Final_Project.Models;
using System.Collections;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class HomeVM
    {
        //public IEnumerable<Testimonial_Slider> testimonial_Sliders { get; set; }
        public IEnumerable<ClientSlider> clientSliders { get; set; }
        public IEnumerable<Services> services { get; set; }
        public PageIntro pageIntro { get; set; }
        public Specializm specializm { get; set; }
        public IEnumerable<JobStatistics>jobStatistics { get; set; }
        public IEnumerable<Candidates> candidates { get; set; }
        public BlogTitle blogTitle { get; set; }
        public IEnumerable<Blog> blogs { get; set; }
        public IEnumerable<Posts> Posts { get; set; }

        public Subscribe subscribe { get; set; }
        public IEnumerable<AvailableJob> availableJobs { get; set; }
        public IEnumerable<RecruitmentAgencies> recruitmentAgencies { get; set; }
    }
}
