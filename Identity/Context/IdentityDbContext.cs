using Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Context
{
    /// <summary>
    /// Data context dedicated to identity only.
    /// </summary>
    public class IdentityDataContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _config;
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_config.GetConnectionString("Identity"));
        }
    }
}
