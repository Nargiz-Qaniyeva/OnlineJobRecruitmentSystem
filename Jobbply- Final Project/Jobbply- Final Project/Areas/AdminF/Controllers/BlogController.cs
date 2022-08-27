using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Helpers;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class BlogController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<BlogPage> blogPages = _context.BlogPages.Skip((pageSize - 1) * take)
                .Take(take).ToList();

            Pagination<BlogPage> pagination = new Pagination<BlogPage>(
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



        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            BlogPage dbBlogPage = await _context.BlogPages.FindAsync(id);
            if (dbBlogPage == null) return NotFound();
            return View(dbBlogPage);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            BlogPage dbBlogPage = await _context.BlogPages.FindAsync(id);
            if (dbBlogPage == null) return NotFound();

            Helper.DeleteFile(_env, "assets", "image", "blog", dbBlogPage.Image);
            _context.BlogPages.Remove(dbBlogPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPage blogPage)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!blogPage.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Accept Only image");
                return View();
            }

            if (blogPage.Photo.Length / 1024 > 1024)
            {
                ModelState.AddModelError("Photo", "1mb-dan yuxari ola bilmez");
                return View();
            }
            // string path = @"C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\wwwroot\assets\image\home\";

            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + blogPage.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "blog", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await blogPage.Photo.CopyToAsync(stream);
            };
            BlogPage newBlogPage = new BlogPage();
            newBlogPage.Image = fileName;
            newBlogPage.Date = blogPage.Date;
            newBlogPage.Admin = blogPage.Admin;
            newBlogPage.Commit = blogPage.Commit;
            newBlogPage.Desc = blogPage.Desc;
            await _context.BlogPages.AddAsync(newBlogPage);
            await _context.SaveChangesAsync();

            //bool isExistName = _context.ClientSliders.Any(c => c.Name.ToLower() == clientSlider.Name.ToLower());
            //if (isExistName)
            //{
            //    ModelState.AddModelError("Name", "Eyni adli Client movcuddur");
            //    return View();
            //}

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            BlogPage dbBlogPage = await _context.BlogPages.FindAsync(id);
            if (dbBlogPage == null) return NotFound();
            return View(dbBlogPage);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, BlogPage blogPage)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            BlogPage dbBlogPage = await _context.BlogPages.FindAsync(id);

            BlogPage existAdminBlog = _context.BlogPages.FirstOrDefault(b => b.Admin.ToLower() == blogPage.Admin.ToLower());

            if (existAdminBlog != null)
            {
                if (dbBlogPage != existAdminBlog)
                {
                    ModelState.AddModelError("Admin", "Admin already exist");
                }
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + blogPage.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "blog", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await blogPage.Photo.CopyToAsync(stream);
            };

            if (dbBlogPage == null) return NotFound();
            dbBlogPage.Image = fileName;
            dbBlogPage.Date = blogPage.Date;
            dbBlogPage.Admin = blogPage.Admin;
            dbBlogPage.Commit = blogPage.Commit;
            dbBlogPage.Desc = blogPage.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
