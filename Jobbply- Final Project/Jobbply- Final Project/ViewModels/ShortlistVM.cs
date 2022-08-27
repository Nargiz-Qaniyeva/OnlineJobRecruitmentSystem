using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class ShortlistVM
    {
        public About about { get; set; }
        public IEnumerable<Shortlist> shortlists { get; set; }
    }
}
