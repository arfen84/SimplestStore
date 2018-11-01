using Microsoft.AspNet.Identity.EntityFramework;

namespace loudclothes.net.Models
{
    public class AppUser 
    {
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}