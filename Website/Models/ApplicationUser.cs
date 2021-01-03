using System;
using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Password{ get; set; }
    }
}