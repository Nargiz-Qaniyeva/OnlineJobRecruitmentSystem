using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class BlogVM
    {
        public About about { get; set; }
        public IEnumerable<BlogPage> blogPages { get; set; }
        public Pagination<BlogVM> pagination { get; set; }
    }
}
