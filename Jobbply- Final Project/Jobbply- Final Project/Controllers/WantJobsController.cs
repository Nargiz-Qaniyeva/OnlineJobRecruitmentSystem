using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class WantJobsController : Controller
    {
        private AppDbContext _context;
        public WantJobsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            WantJobsVM wantJobsVM = new WantJobsVM();
            wantJobsVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 7);
            //wantJobsVM.timecategory = _context.Time.ToList();
            wantJobsVM.finds = _context.Finds.ToList();
            wantJobsVM.topCategories = _context.topCategories.ToList();
            return View(wantJobsVM);
        }

       
    }
}
