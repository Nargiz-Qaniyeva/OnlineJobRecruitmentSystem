using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class TimeController : Controller
    {

        private AppDbContext _context;

        public TimeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //List<Times> Time = _context.Time.ToList();
            //return View(Time);
            return View();
        }




        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Timers Times)
        {




            Timers db = new Timers();

            db.Name = Times.Name;

            _context.Timers.Add(db);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Timers Times = _context.Timers.Find(id);
            if (Times == null)
            {
                return NotFound();
            }
            return View(Times);
        }


        //[HttpPost]
        //public async Task<IActionResult> Update(int? id, Timers timers)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }


        //    Timers db = _context.Timers.Find(id);
        //    if (db == null)
        //    {
        //        return NotFound();
        //    }
        //    Timers existName = _context.Timers.FirstOrDefault(x => x.Name.ToLower() == Times.Name.ToLower());

        //    if (existName != null)
        //    {
        //        if (db != existName)
        //        {
        //            ModelState.AddModelError("Name", "Name Already Exist");
        //            return View();
        //        }
        //    }

        //    db.Name = Timers.Name;

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(int id)
        {
            Timers category = _context.Timers.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            _context.Timers.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); ;

        }


        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Timers timers = _context.Timers.Find(id);
            if (timers == null)
            {
                return NotFound();
            }
            return View(timers);
        }
    }
}
