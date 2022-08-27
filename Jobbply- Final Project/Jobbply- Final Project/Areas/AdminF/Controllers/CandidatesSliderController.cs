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
    public class CandidatesSliderController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public CandidatesSliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<Candidates> candidates = _context.Candidates
                .Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();

            Pagination<Candidates> pagination = new Pagination<Candidates>(
                ReturnPageCount(take),
                pageSize,
                candidates
                );
            return View(pagination);
        }
        private int ReturnPageCount(int take)
        {
            int candidatesCount = _context.Candidates.Count();
            return (int)Math.Ceiling(((decimal)candidatesCount / take));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            Candidates dbCandidates = await _context.Candidates.FindAsync(id);
            if (dbCandidates == null) return NotFound();
            return View(dbCandidates);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            Candidates dbCandidates = await _context.Candidates.FindAsync(id);
            if (dbCandidates == null) return NotFound();

            Helper.DeleteFile(_env, "assets", "image", "home", dbCandidates.Image);
            _context.Candidates.Remove(dbCandidates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidates candidates)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!candidates.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Accept Only image");
                return View();
            }

            if (candidates.Photo.Length / 1024 > 1024)
            {
                ModelState.AddModelError("Photo", "1mb-dan yuxari ola bilmez");
                return View();
            }
            // string path = @"C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\wwwroot\assets\image\home\";

            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + candidates.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await candidates.Photo.CopyToAsync(stream);
            };
            Candidates newCandidates = new Candidates();
            newCandidates.Image = fileName;
            newCandidates.Title = candidates.Title;
            newCandidates.Subtitle = candidates.Subtitle;
            await _context.Candidates.AddAsync(newCandidates);
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

            Candidates dbCandidates = await _context.Candidates.FindAsync(id);
            if (dbCandidates == null) return NotFound();
            return View(dbCandidates);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Candidates candidates)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Candidates dbCandidates = await _context.Candidates.FindAsync(id);

            Candidates existNameCandidates = _context.Candidates.FirstOrDefault(c => c.Title.ToLower() == candidates.Title.ToLower());

            if (existNameCandidates != null)
            {
                if (dbCandidates != existNameCandidates)
                {
                    ModelState.AddModelError("Title", "Title already exist");
                }
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + candidates.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await candidates.Photo.CopyToAsync(stream);
            };

            if (dbCandidates == null) return NotFound();
            dbCandidates.Image = fileName;
            dbCandidates.Title = candidates.Title;
            dbCandidates.Subtitle = candidates.Subtitle;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
