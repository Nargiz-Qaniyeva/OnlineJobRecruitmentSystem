using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class ShortlistController : Controller
    {
        private AppDbContext _context;
        public ShortlistController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShortlistVM shortlistVM = new ShortlistVM();
            shortlistVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 2);
            shortlistVM.shortlists = _context.shortlists.ToList();
            return View(shortlistVM);
        }
    }
}
