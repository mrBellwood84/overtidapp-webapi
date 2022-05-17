using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    /// <summary>
    /// Model for app users, inherited by Identity users
    /// </summary>
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

    }
}
