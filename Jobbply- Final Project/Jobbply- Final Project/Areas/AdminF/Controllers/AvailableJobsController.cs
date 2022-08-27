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
    public class AvailableJobsController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public AvailableJobsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<AvailableJob> availableJobs = _context.AvailableJobs.Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();


            Pagination<AvailableJob> pagination = new Pagination<AvailableJob>(
                ReturnPageCount(take),
                pageSize,
                availableJobs
                );
            return View(pagination);
        }
        private int ReturnPageCount(int take)
        {
            int availableJobCount = _context.AvailableJobs.Count();
            return (int)Math.Ceiling(((decimal)availableJobCount / take));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            AvailableJob dbAvailableJob = await _context.AvailableJobs.FindAsync(id);
            if (dbAvailableJob == null) return NotFound();
            return View(dbAvailableJob);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            AvailableJob dbAvailableJob = await _context.AvailableJobs.FindAsync(id);
            if (dbAvailableJob == null) return NotFound();

            //Helper.DeleteFile(_env, "assets", "image", "home", dbAvailableJob.Image);
            _context.AvailableJobs.Remove(dbAvailableJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailableJob availableJob)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AvailableJob newAvailableJob = new AvailableJob();
            newAvailableJob.Title = availableJob.Title;
            newAvailableJob.WorkTime = availableJob.WorkTime;
            newAvailableJob.Social = availableJob.Social;
            newAvailableJob.Location = availableJob.Location;
            await _context.AvailableJobs.AddAsync(newAvailableJob);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            AvailableJob dbAvailableJob = await _context.AvailableJobs.FindAsync(id);
            if (dbAvailableJob == null) return NotFound();
            return View(dbAvailableJob);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, AvailableJob availableJob)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AvailableJob dbAvailableJob = await _context.AvailableJobs.FindAsync(id);

            //AvailableJob existTitleJobInfo = _context.JobInfos.FirstOrDefault(j => j.Title.ToLower() == jobInfo.Title.ToLower());

            //if (existTitleJobInfo != null)
            //{
            //    if (dbJobinfo != existTitleJobInfo)
            //    {
            //        ModelState.AddModelError("Title", "Title already exist");
            //    }
            //}


            if (dbAvailableJob == null) return NotFound();

            dbAvailableJob.Title = availableJob.Title;
            dbAvailableJob.WorkTime = availableJob.WorkTime;
            dbAvailableJob.Social = availableJob.Social;
            dbAvailableJob.Location = availableJob.Location;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
