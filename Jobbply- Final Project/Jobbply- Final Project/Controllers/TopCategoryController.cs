using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Controllers
{
    public class TopCategoryController : Controller
    {
        private AppDbContext _context;
        public TopCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            JobInfoVM jobInfoVM = new JobInfoVM();
            ViewBag.JobInfoCount = _context.jobInfos.Count();
            jobInfoVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 3);
            jobInfoVM.jobInfos = _context.jobInfos.ToList();
            return View(jobInfoVM);
        }
        public IActionResult LoadMore(int skip)
        {
            JobInfoVM jobInfoVM = new JobInfoVM();
            jobInfoVM.jobInfos = _context.jobInfos.Include(j => j).Skip(skip).Take(4).ToList();
            return PartialView("_TopCategoryPartial", jobInfoVM);
        }

        public IActionResult SearchProduct(string search)
        {
            //List<Category> categories = _context.Categories.Where(x => x.Title.ToLower()
            //.Contains(search.ToLower())).Take(3).ToList();
            //return PartialView("_Search", categories);
            List<TopCategory> topCategories = _context.topCategories.Where(p => p.Name.ToLower()
            .Contains(search.ToLower())).Take(10).ToList();
            return PartialView("_Search", topCategories);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            JobInfo dbJobInfo = await _context.jobInfos.FindAsync(id);
            if (dbJobInfo == null) return NotFound();
            return View(dbJobInfo);
        }
    }
}
