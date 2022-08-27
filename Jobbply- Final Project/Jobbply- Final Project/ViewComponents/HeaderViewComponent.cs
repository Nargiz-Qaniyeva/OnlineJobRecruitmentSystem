using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            int totalCount = 0;
            if (Request.Cookies["basket"] != null)
            {
                List<BasketAvailable> basketAvailables = JsonConvert.DeserializeObject<List<BasketAvailable>>(
               Request.Cookies["basket"]);

                foreach (var item in basketAvailables)
                {
                    totalCount += item.Count;
                }
            }
            ViewBag.BasketLength = totalCount;

            //ViewBag.BasketLength = basketAvailables.Count();
            Bio bio = _context.Bios.FirstOrDefault();

            if (User.Identity.IsAuthenticated)
            {
                AppUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = currentUser.Fullname;
            }
            return View(await Task.FromResult(bio));
        }
    }
}
