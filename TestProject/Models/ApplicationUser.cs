using Microsoft.AspNetCore.Identity;

namespace SchoolSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Gender { get; set; }
        public string FullName { get; set; }
    }
}
