using Microsoft.AspNetCore.Identity;

namespace FrontToBackend.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName{ get; set; }
    }
}
