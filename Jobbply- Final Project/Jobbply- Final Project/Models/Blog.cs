using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobbply__Final_Project.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        //[Required]
        public IFormFile Photo { get; set; }
        public string Date { get; set; }
        public string Admin { get; set; }
        public int Commit { get; set; }
        public string Desc { get; set; }
    }
}
