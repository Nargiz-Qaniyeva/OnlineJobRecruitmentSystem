using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class CanditatesVM
    {
        public About about { get; set; }
        public IEnumerable<Worker> workers { get; set; }
        public Pagination<CanditatesVM> pagination { get; set; }
    }
}
