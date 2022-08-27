using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class CanditatesController : Controller
    {
        private AppDbContext _context;
        public CanditatesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int take = 8, int pageSize = 1)
        {
         
           ViewBag.About = _context.Abouts.FirstOrDefault(x => x.Id == 2);
            List<Worker> products = _context.Workers.Skip((pageSize - 1) * take).Take(take).ToList();
            Paginat<Worker> pagination = new Paginat<Worker>(

                 ReturnPageCount(take),
                 pageSize,
                 products
            );
            return View(pagination);
        } 
        private int ReturnPageCount(int take)
        {
            int workerCount = _context.Workers.Count();
            return (int)Math.Ceiling(((decimal)workerCount / take));
        }
    }
}
