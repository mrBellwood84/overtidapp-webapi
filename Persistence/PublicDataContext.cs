using Domain.Agreements.CollectiveAgreement;
using Domain.Employment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    /// <summary>
    /// Data context for application
    /// Identity has a separate db context dedicated for that purpos only!
    /// </summary>
    public class PublicDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public PublicDataContext(DbContextOptions<PublicDataContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        // configure correct database for context
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_config.GetConnectionString("PublicData"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>()
                .HasOne<CollectiveAgreement>()
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<CollectiveAgreement> CollectiveAgreeements { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<EmployerEditRequest> EmployersEditRequests { get; set; }

    }
}
