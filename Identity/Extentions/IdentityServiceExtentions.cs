using Identity.Context;
using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.Extentions
{
    /// <summary>
    /// Extentions for all identity services, incluing token service.
    /// </summary>
    public static class IdentityServiceExtentions
    {
        /// <summary>
        /// Add identity services to application
        /// </summary>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            // add identity core as service
            services.AddIdentityCore<AppUser>(opts =>
            {
                opts.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));

            // add authentication service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            // adding token service
            services.AddScoped<TokenService>();

            return services;
        }
    }
}
