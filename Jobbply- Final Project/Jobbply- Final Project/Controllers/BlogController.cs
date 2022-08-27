using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class BlogController : Controller
    {
        private AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int take = 4, int pageSize = 1)
        {
            //BlogVM blogVM = new BlogVM();
            //blogVM.about = _context.Abouts.FirstOrDefault(x => x.Id == 4);
            //blogVM.blogPages = _context.BlogPages.ToList();
            ViewBag.About = _context.Abouts.FirstOrDefault(x => x.Id == 4);
            List<BlogPage> blogPages = _context.BlogPages.Skip((pageSize - 1) * take).Take(take).ToList();
            Paginat<BlogPage> pagination = new Paginat<BlogPage>(

                 ReturnPageCount(take),
                 pageSize,
                 blogPages
            );
            return View(pagination);
        }
        private int ReturnPageCount(int take)
        {
            int blogCount = _context.BlogPages.Count();
            return (int)Math.Ceiling(((decimal)blogCount / take));
        }
    }
}
