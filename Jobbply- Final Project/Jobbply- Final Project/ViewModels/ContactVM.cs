using Jobbply__Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Jobbply__Final_Project.ViewModels
{
    public class ContactVM
    {
        public About about { get; set; }
        public Contact contact { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }


        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required, StringLength(200)]
        public string Subject { get; set; }


        [Required, StringLength(600)]
        public string Message { get; set; }

    }
}
