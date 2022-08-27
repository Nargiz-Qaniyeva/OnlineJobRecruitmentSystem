using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobbply__Final_Project.Models
{
    public class ClientSlider
    {
        public int Id { get; set; }

        public string Image { get; set; }


        [NotMapped]
        //[Required]
        public IFormFile Photo { get; set; }


        //[Required]
        //[MaxLength(100, ErrorMessage = "100-den cox olmamalidir")]
        public string Desc { get; set; }


        //[Required(ErrorMessage = "don't empty")]
        //[MaxLength(15, ErrorMessage = "15-den cox olmamalidir")]
        public string Name { get; set; }


       // [Required(ErrorMessage = "don't empty")]
        //[MaxLength(20, ErrorMessage = "20-den cox olmamalidir")]
        public string Position { get; set; }
    }
}
