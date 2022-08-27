using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.ViewComponents
{
    public class SubscribeViewComponent: ViewComponent
    {
        private AppDbContext _context;
        public SubscribeViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Subscribe subscribe = _context.Subscribes.FirstOrDefault();
            return View(await Task.FromResult(subscribe));
        }
    }
}
