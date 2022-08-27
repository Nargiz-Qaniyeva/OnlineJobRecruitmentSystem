using Microsoft.AspNetCore.Identity;
using System;

namespace Jobbply__Final_Project.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }

        
    }
}
