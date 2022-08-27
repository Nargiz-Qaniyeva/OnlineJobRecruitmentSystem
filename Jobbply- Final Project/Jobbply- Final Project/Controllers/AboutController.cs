using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class AboutController : Controller
    {
        private AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM();
            aboutVM.about=_context.Abouts.FirstOrDefault(x=>x.Id==1);
            aboutVM.welcome = _context.Welcomes.FirstOrDefault();
            aboutVM.jobStatistics = _context.JobStatistics.ToList();
            //aboutVM.testimonial_Sliders = _context.Testimonial_Sliders.ToList();
            aboutVM.clientSliders = _context.ClientSliders.ToList();

            return View(aboutVM);
        }
    }
}
