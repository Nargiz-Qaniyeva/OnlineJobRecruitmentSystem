using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class CategoryVM
    {
        public About about { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
