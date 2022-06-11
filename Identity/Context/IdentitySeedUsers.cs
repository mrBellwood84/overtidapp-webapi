using Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Identity.Context
{
    /// <summary>
    /// Seeding app users for development purposes
    /// </summary>
    public class IdentitySeedUsers
    {
        public static async Task Seed(IdentityDataContext context, UserManager<AppUser> userManager)
        {
            // return if users exist
            if (context.Users.Any()) return;

            // create list of users
            var users = new List<AppUser> 
            {
                new AppUser 
                {
                    FirstName = "App",
                    LastName = "Admin",
                    UserName = $"user-{Guid.NewGuid()}",
                    Email = "admin@app.com", 
                    Role = "admin" 
                },
                new AppUser 
                {
                    FirstName = "John", 
                    LastName = "Doe", 
                    UserName = $"user-{Guid.NewGuid()}", 
                    Email = "john@app.com", 
                    Role = "user" 
                },
                new AppUser
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    UserName = $"user-{Guid.NewGuid()}",
                    Email = "jane@app.com",
                    Role= "user"

                }
            };

            // add all users in list of users
            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password123");
            }

        }
    }
}
