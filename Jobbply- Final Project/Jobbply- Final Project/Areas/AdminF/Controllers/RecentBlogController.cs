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
    public class RecentBlogController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public RecentBlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<Blog> blogs = _context.Blogs.Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();

            Pagination<Blog> pagination = new Pagination<Blog>(
               ReturnPageCount(take),
               pageSize,
               blogs
               );
            return View(pagination);
        }

        private int ReturnPageCount(int take)
        {
            int bloglistCount = _context.Blogs.Count();
            return (int)Math.Ceiling(((decimal)bloglistCount / take));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            Blog dbBlog = await _context.Blogs.FindAsync(id);
            if (dbBlog == null) return NotFound();
            return View(dbBlog);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            Blog dbBlog = await _context.Blogs.FindAsync(id);
            if (dbBlog == null) return NotFound();

            Helper.DeleteFile(_env, "assets", "image", "home", dbBlog.Image);
            _context.Blogs.Remove(dbBlog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!blog.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Accept Only image");
                return View();
            }

            if (blog.Photo.Length / 1024 > 1024)
            {
                ModelState.AddModelError("Photo", "1mb-dan yuxari ola bilmez");
                return View();
            }
            // string path = @"C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\wwwroot\assets\image\home\";

            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + blog.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await blog.Photo.CopyToAsync(stream);
            };
            Blog newBlog = new Blog();
            newBlog.Image = fileName;
            newBlog.Date = blog.Date;
            newBlog.Admin = blog.Admin;
            newBlog.Commit = blog.Commit;
            newBlog.Desc = blog.Desc;
            await _context.Blogs.AddAsync(newBlog);
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

            Blog dbBlog = await _context.Blogs.FindAsync(id);
            if (dbBlog == null) return NotFound();
            return View(dbBlog);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Blog dbBlog = await _context.Blogs.FindAsync(id);

            Blog existAdminBlog = _context.Blogs.FirstOrDefault(b => b.Admin.ToLower() == blog.Admin.ToLower());

            if (existAdminBlog != null)
            {
                if (dbBlog != existAdminBlog)
                {
                    ModelState.AddModelError("Admin", "Admin already exist");
                }
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + blog.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await blog.Photo.CopyToAsync(stream);
            };

            if (dbBlog == null) return NotFound();
            dbBlog.Image = fileName;
            dbBlog.Date = blog.Date;
            dbBlog.Admin = blog.Admin;
            dbBlog.Commit = blog.Commit;
            dbBlog.Desc = blog.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
