using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class BlogOtherVM
    {
        public BlogOtherAbout blogOtherAbout { get; set; }
        public IEnumerable<BlogOther> blogOthers { get; set; }
        public AuthorBlog authorBlog { get; set; }
        public IEnumerable<Widget> widgets { get; set; }
        public IEnumerable<Coomments> coomments { get; set; }
    }
}
