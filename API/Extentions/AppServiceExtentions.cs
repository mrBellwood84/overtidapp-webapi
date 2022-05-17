using Application.PublicDataService;
using Identity.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extentions
{
    public static class AppServiceExtentions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            // adding controllers
            services.AddControllers(opts =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opts.Filters.Add(new AuthorizeFilter(policy));
            });

            // adding data context services
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlite(config.GetConnectionString("Identity")));
            services.AddDbContext<UserDataContext>(options => options.UseSqlite(config.GetConnectionString("UserData")));
            services.AddDbContext<PublicDataContext>(options => options.UseSqlite(config.GetConnectionString("PublicData")));

            // add memory cache
            services.AddMemoryCache();

            // add cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(config["FrontEndApp"]);
                });
            });


            // Adding authentication is added with the IdentityServiceExtention


            // Adding data handler services
            services.AddTransient<IPublicDataService, PublicDataService>();

            return services;
        }
    }
}
