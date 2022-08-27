using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobbply__Final_Project.Models
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        //[Required]
        public IFormFile Photo { get; set; }

        //[Required (ErrorMessage ="don't empty")]
        //[MaxLength(20 , ErrorMessage ="20-den cox olmamalidir")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "don't empty")]
        //[MaxLength(100, ErrorMessage = "100-den cox olmamalidir")]
        public string Desc { get; set; }

        //[Required]
        //public int? TopCategoryId { get; set; }

        //public TopCategory TopCategory { get; set; }

        //public virtual IEnumerable<TopCategory>TopCategories { get; set; }

    }
}
