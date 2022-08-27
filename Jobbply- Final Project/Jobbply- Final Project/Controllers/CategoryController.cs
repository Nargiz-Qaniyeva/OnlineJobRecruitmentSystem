using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 3);
            categoryVM.categories = _context.Categories.ToList();
            return View(categoryVM);
        }
    }
}
