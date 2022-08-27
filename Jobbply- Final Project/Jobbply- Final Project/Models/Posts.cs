using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobbply__Final_Project.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Desc { get; set; }
        public List<PosterTimes>PosterTimes { get; set; }

        [NotMapped]
        public List<int> TimeIds { get; set; }
    }
}
