using Jobbply__Final_Project.DAL;
using Jobbply__Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jobbply__Final_Project.Controllers
{
    public class BlogOtherController : Controller
    {
        private AppDbContext _context;
        public BlogOtherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BlogOtherVM blogOtherVM = new BlogOtherVM();
            blogOtherVM.blogOtherAbout = _context.BlogOtherAbouts.FirstOrDefault();
            blogOtherVM.blogOthers = _context.BlogOthers.ToList();
            blogOtherVM.authorBlog = _context.AuthorBlogs.FirstOrDefault();
            blogOtherVM.widgets = _context.Widgets.ToList();
            blogOtherVM.coomments = _context.Coomments.ToList();
            return View(blogOtherVM);
        }
    }
}
