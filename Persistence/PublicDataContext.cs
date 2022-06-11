using Domain.Agreements.Aml;
using Domain.Agreements.CollectiveAgreement;
using Domain.Employer;
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

        /// <summary>
        /// Dataset for Working Environment Act
        /// </summary>
        public DbSet<AmlEntity> Aml { get; set; }

        /// <summary>
        /// Db set for collective agreements
        /// </summary>
        public DbSet<CollectiveAgreementEntity> CollectiveAgreeements { get; set; }

        /// <summary>
        /// Db set for employer
        /// </summary>
        public DbSet<EmployerEntity> Employers { get; set; }

        /// <summary>
        /// Db set for employers edit requests
        /// </summary>
        public DbSet<EmployerEditSuggestionEntity> EmployerEditSuggestions { get; set; }

    }
}
