using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Helpers;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class WantJobsCategoryController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public WantJobsCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<TopCategory> topCategories = _context.topCategories.Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();

            Pagination<TopCategory> pagination = new Pagination<TopCategory>(
               ReturnPageCount(take),
               pageSize,
               topCategories
               );

            return View(pagination);
        }

        private int ReturnPageCount(int take)
        {
            int wantjobsCount = _context.topCategories.Count();
            return (int)Math.Ceiling(((decimal)wantjobsCount / take));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            TopCategory dbTopCategory = await _context.topCategories.FindAsync(id);
            if (dbTopCategory == null) return NotFound();
            return View(dbTopCategory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            TopCategory dbTopCategory = await _context.topCategories.FindAsync(id);
            if (dbTopCategory == null) return NotFound();

            _context.topCategories.Remove(dbTopCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopCategory topCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TopCategory newTopCategory = new TopCategory();
            newTopCategory.Name = topCategory.Name;
            newTopCategory.Number = topCategory.Number;
            await _context.topCategories.AddAsync(newTopCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            TopCategory dbTopCategory = await _context.topCategories.FindAsync(id);
            if (dbTopCategory == null) return NotFound();
            return View(dbTopCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, TopCategory topCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TopCategory dbTopCategory = await _context.topCategories.FindAsync(id);


            if (dbTopCategory == null) return NotFound();

            dbTopCategory.Name = topCategory.Name;
            dbTopCategory.Number = dbTopCategory.Number;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
