using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Jobbply__Final_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        //private UserManager<SendMessage> _userManager;
        //private SignInManager<SendMessage> _signInManager;
        public ContactController(AppDbContext context
            //UserManager<SendMessage> userManager
            /*SignInManager<SendMessage> signInManager*/)
        {
            _context = context;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }
       

        public IActionResult Index()
        {
            ViewBag.About = _context.Abouts.FirstOrDefault(x => x.Id == 5);
            ViewBag.contact = _context.Contacts.FirstOrDefault();
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SendMessage sendMessage)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.About = _context.Abouts.FirstOrDefault();
           ViewBag.contact = _context.Contacts.FirstOrDefault();

          
            SendMessage db = new SendMessage();

            db.Name = sendMessage.Name;
            db.Subject = sendMessage.Subject;
            db.Message = sendMessage.Message;
            db.Email = sendMessage.Email;

            _context.sendMessages.Add(db);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
