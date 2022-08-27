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
    public class TopCategoryController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public TopCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take=5,int pageSize=1)
        {
            List<JobInfo> jobInfos = _context.jobInfos
                .Skip((pageSize-1)*take)
                .Take(take)
                .ToList();

            Pagination<JobInfo> pagination = new Pagination<JobInfo>(
                ReturnPageCount(take),
                pageSize,
                jobInfos
                );

            return View(pagination);
        }

        private int ReturnPageCount(int take)
        {
            int jobInfoCount = _context.jobInfos.Count();
           return (int)Math.Ceiling(((decimal)jobInfoCount/take));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            JobInfo dbJobInfo = await _context.jobInfos.FindAsync(id);
            if (dbJobInfo == null) return NotFound();
            return View(dbJobInfo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            JobInfo dbJobInfo = await _context.jobInfos.FindAsync(id);
            if (dbJobInfo == null) return NotFound();

            Helper.DeleteFile(_env, "assets", "image", "category", dbJobInfo.Image);
            _context.jobInfos.Remove(dbJobInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobInfo jobInfo)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!jobInfo.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Accept Only image");
                return View();
            }

            if (jobInfo.Photo.Length / 1024 > 1024)
            {
                ModelState.AddModelError("Photo", "1mb-dan yuxari ola bilmez");
                return View();
            }
            // string path = @"C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\wwwroot\assets\image\home\";

            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + jobInfo.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "category", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await jobInfo.Photo.CopyToAsync(stream);
            };
            JobInfo newJobInfo = new JobInfo();
            newJobInfo.Image = fileName;
            newJobInfo.Title = jobInfo.Title;
            newJobInfo.Desc = jobInfo.Desc;
            await _context.jobInfos.AddAsync(newJobInfo);
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

            JobInfo dbJobInfo = await _context.jobInfos.FindAsync(id);
            if (dbJobInfo == null) return NotFound();
            return View(dbJobInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, JobInfo jobInfo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            JobInfo dbJobInfo = await _context.jobInfos.FindAsync(id);

            JobInfo existTitleJobInfo = _context.jobInfos.FirstOrDefault(c => c.Title.ToLower() == jobInfo.Title.ToLower());

            if (existTitleJobInfo != null)
            {
                if (dbJobInfo != existTitleJobInfo)
                {
                    ModelState.AddModelError("Title", "Title already exist");
                }
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + jobInfo.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "category", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await jobInfo.Photo.CopyToAsync(stream);
            };

            if (dbJobInfo == null) return NotFound();
            dbJobInfo.Image = fileName;
            dbJobInfo.Title = jobInfo.Title;
            dbJobInfo.Desc = jobInfo.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
