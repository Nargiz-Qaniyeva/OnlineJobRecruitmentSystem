using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class JobSingleController : Controller
    {
        private AppDbContext _context;
        public JobSingleController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            JobSingleVM jobSingleVM = new JobSingleVM();
            jobSingleVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 5);
            jobSingleVM.getTouch = _context.GetTouches.FirstOrDefault();
            return View(jobSingleVM);
        }
    }
}
