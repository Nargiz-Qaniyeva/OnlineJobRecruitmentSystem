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
    public class ClientSliderController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public ClientSliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int take = 5, int pageSize = 1)
        {
            List<ClientSlider> clientSliders = _context.ClientSliders.Skip((pageSize - 1) * take)
                .Take(take)
                .ToList();

            Pagination<ClientSlider> pagination = new Pagination<ClientSlider>(
               ReturnPageCount(take),
               pageSize,
               clientSliders
               );
            return View(pagination);
        }
        private int ReturnPageCount(int take)
        {
            int sliderCount = _context.ClientSliders.Count();
            return (int)Math.Ceiling(((decimal)sliderCount / take));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            ClientSlider dbClientSlider = await _context.ClientSliders.FindAsync(id);
            if (dbClientSlider == null) return NotFound();
            return View(dbClientSlider);
        }

        
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            ClientSlider dbClientSlider = await _context.ClientSliders.FindAsync(id);
            if (dbClientSlider == null) return NotFound();

            Helper.DeleteFile(_env, "assets","image","home", dbClientSlider.Image);
            _context.ClientSliders.Remove(dbClientSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientSlider clientSlider)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!clientSlider.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Accept Only image");
                return View();
            }

            if (clientSlider.Photo.Length/1024>1024)
            {
                ModelState.AddModelError("Photo", "1mb-dan yuxari ola bilmez");
                return View();
            }
            // string path = @"C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\wwwroot\assets\image\home\";
           
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + clientSlider.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream=new FileStream (result,FileMode.Create))
            {
                await clientSlider.Photo.CopyToAsync(stream);
            };
            ClientSlider newClientSlider = new ClientSlider();
            newClientSlider.Image = fileName;
            newClientSlider.Desc = clientSlider.Desc;
            newClientSlider.Name = clientSlider.Name;
            newClientSlider.Position = clientSlider.Position;
            await _context.ClientSliders.AddAsync(newClientSlider);
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

            ClientSlider dbClientSlider = await _context.ClientSliders.FindAsync(id);
            if (dbClientSlider == null) return NotFound();
            return View(dbClientSlider);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, ClientSlider clientSlider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ClientSlider dbClientSlider = await _context.ClientSliders.FindAsync(id);

            ClientSlider existNameClientSlider = _context.ClientSliders.FirstOrDefault(c => c.Name.ToLower() == clientSlider.Name.ToLower());

            if (existNameClientSlider != null)
            {
                if (dbClientSlider != existNameClientSlider)
                {
                    ModelState.AddModelError("Name", "Title already exist");
                }
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + clientSlider.Photo.FileName;
            string result = Path.Combine(path, "assets", "image", "home", fileName);

            using (FileStream stream = new FileStream(result, FileMode.Create))
            {
                await clientSlider.Photo.CopyToAsync(stream);
            };

            if (dbClientSlider == null) return NotFound();
            dbClientSlider.Image = fileName;
            dbClientSlider.Desc = dbClientSlider.Desc;
            dbClientSlider.Name = dbClientSlider.Name;
            dbClientSlider.Position = dbClientSlider.Position;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
