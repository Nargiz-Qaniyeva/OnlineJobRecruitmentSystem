using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class PostJobController : Controller
    {
        private AppDbContext _context;

        public PostJobController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id == 6);
            ViewBag.Categories = _context.Timers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Posts post)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.categories = _context.Timers.ToList();

            post.PosterTimes = new List<PosterTimes>();
            if (post.TimeIds != null)
            {
                foreach (var categoryId in post.TimeIds)
                {
                    PosterTimes pCategory = new PosterTimes
                    {
                        Posts = post,
                        TimersId = categoryId
                    };
                    _context.PosterTimes.Add(pCategory);
                }
            }

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
