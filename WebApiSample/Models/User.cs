using Microsoft.AspNetCore.Identity;

namespace WebApiSample.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; } = "customer";
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
