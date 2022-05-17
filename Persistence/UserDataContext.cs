using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class UserDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public UserDataContext(DbContextOptions<UserDataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        // configure correct database for context
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_config.GetConnectionString("UserData"));
        }
    }
}
