using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class ContactController : Controller
    {
        private AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
           
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<SendMessage> sendMessages = _context.sendMessages.Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();

            Pagination<SendMessage> pagination = new Pagination<SendMessage>(
               ReturnPageCount(take),
               pageSize,
               sendMessages
               );
            return View(pagination);
        }
        private int ReturnPageCount(int take)
        {
            int messageCount = _context.sendMessages.Count();
            return (int)Math.Ceiling(((decimal)messageCount / take));
        }

        public IActionResult Create()
        {
            ViewBag.About = _context.Abouts.FirstOrDefault();
            ViewBag.contact = _context.Contacts.FirstOrDefault();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SendMessage sendMessage)
        {
            ViewBag.About = _context.Abouts.FirstOrDefault(x => x.Id == 3);
            ViewBag.contact = _context.Contacts.FirstOrDefault();
            SendMessage db = new SendMessage();
            db.Subject = sendMessage.Subject;
            db.Email = sendMessage.Email;
            db.Message = sendMessage.Message;
            db.Name = sendMessage.Name;

            _context.sendMessages.Add(db);
            _context.SaveChanges();

            return RedirectToAction(nameof(Create));
        }

        [Authorize]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            SendMessage db = await _context.sendMessages.FindAsync(id);
            if (db == null) return NotFound();
            return View(db);
        }
    }
}
