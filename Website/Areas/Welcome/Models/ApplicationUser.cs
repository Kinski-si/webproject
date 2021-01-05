using System;
using Microsoft.AspNetCore.Identity;

namespace Website.Areas.Welcome.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Password{ get; set; }
    }
}