using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Controllers
{
    public class BasketController : Controller
    {
        private AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       

        public async Task<IActionResult> AddBasket(int? id)
        {
            // HttpContext.Session.SetString("project", "jobpply");
            //Response.Cookies.Append("name", "Roger", new CookieOptions { MaxAge = TimeSpan
            //    .FromHours(3) });

            if (id == null) return NotFound();
            AvailableJob dbavailableJob = await _context.AvailableJobs.FindAsync(id);

            if (dbavailableJob == null) return NotFound();
            List<BasketAvailable> basketAvailables;

            string existBasket = Request.Cookies["basket"];

            if (existBasket == null)
            {
                basketAvailables = new List<BasketAvailable>();

            }
            else
            {
                basketAvailables = JsonConvert.DeserializeObject<List<BasketAvailable>>(Request
                .Cookies["basket"]);
            }
            var existBasketavailable = basketAvailables.FirstOrDefault(b => b.Id == dbavailableJob.Id);
            if (existBasketavailable == null)
            {
                BasketAvailable basketAvailable = new BasketAvailable();

                basketAvailable.Id = dbavailableJob.Id;
                basketAvailable.Location = dbavailableJob.Location;
                basketAvailable.Social = dbavailableJob.Social;
                basketAvailable.Title = dbavailableJob.Title;
                basketAvailable.WorkTime = dbavailableJob.WorkTime;
                basketAvailable.Count = 1;

                basketAvailables.Add(basketAvailable);
            }
            else
            {
                existBasketavailable.Count++;
            }


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketAvailables),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(50) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Basket()
        {
            //string project = HttpContext.Session.GetString("project");
            //string name=Request.Cookies["name"];

            List<BasketAvailable> basketAvailables = JsonConvert.DeserializeObject<List<BasketAvailable>>(Request
                .Cookies["basket"]);

            

            List<BasketAvailable> updatedAvailableJobs = new List<BasketAvailable>();

            foreach (var item in basketAvailables)
            {
                AvailableJob dbAvailableJob = _context.AvailableJobs.FirstOrDefault(b => b.Id == item.Id);
                BasketAvailable basketAvailable = new BasketAvailable()
                {
                    Id = dbAvailableJob.Id,
                    Location = dbAvailableJob.Location,
                    Social = dbAvailableJob.Social,
                    WorkTime = dbAvailableJob.WorkTime,
                    Count = item.Count
                };
                updatedAvailableJobs.Add(basketAvailable);
            }

            return View(updatedAvailableJobs);

        }

        public IActionResult RemoveItem(int? id)
        {
            if (id == null) return NotFound();
            string basket = Request.Cookies["basket"];

            List<BasketAvailable> basketAvailables = JsonConvert.DeserializeObject
                <List<BasketAvailable>>(basket);

            BasketAvailable existJob = basketAvailables.FirstOrDefault(b => b.Id == id);
            if (existJob == null) return NotFound();

            basketAvailables.Remove(existJob);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketAvailables),
               new CookieOptions { MaxAge = TimeSpan.FromDays(2) });

            return RedirectToAction(nameof(Basket));
        }
    }
}
;