using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobbply__Final_Project.Models
{
    public class Candidates
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        //[Required]
        public IFormFile Photo { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }

    }
}
