using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context= context;  
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            //homeVM.testimonial_Sliders = _context.Testimonial_Sliders.ToList();
            homeVM.pageIntro = _context.PageIntros.FirstOrDefault();
            homeVM.specializm = _context.Specializms.FirstOrDefault();
            homeVM.jobStatistics = _context.JobStatistics.ToList();
            homeVM.candidates = _context.Candidates.ToList();
            homeVM.blogTitle = _context.BlogTitles.FirstOrDefault();
            homeVM.blogs = _context.Blogs.ToList();
            homeVM.services = _context.Services.ToList();
            homeVM.subscribe = _context.Subscribes.FirstOrDefault();
            homeVM.availableJobs = _context.AvailableJobs.ToList();
            homeVM.recruitmentAgencies = _context.RecruitmentAgencies.ToList();
            homeVM.clientSliders = _context.ClientSliders.ToList();
            homeVM.Posts = _context.Posts.Include(p => p.PosterTimes).ThenInclude(x => x.Timers).ToList();
            return View(homeVM);
        }
    }
}
