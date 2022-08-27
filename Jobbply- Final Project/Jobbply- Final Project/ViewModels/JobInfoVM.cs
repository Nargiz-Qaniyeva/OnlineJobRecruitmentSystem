using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class JobInfoVM
    {
        public About about { get; set; }
        public IEnumerable<JobInfo> jobInfos { get; set; }
        public Pagination<JobInfoVM> pagination{ get; set; }

    }
}
