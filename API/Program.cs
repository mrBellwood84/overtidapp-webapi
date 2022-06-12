using API.Extentions;
using Identity.Context;
using Identity.Data;
using Identity.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.SeedData;

// create builder
var builder = WebApplication.CreateBuilder(args);


// add services from extentions
builder.Services.AddAppServices(builder.Configuration);

// add identity services from extention
builder.Services.AddIdentityServices(builder.Configuration);

// build app
var app = builder.Build();


// check database, create and seed if needed

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

// try seeding data
var identityContext = service.GetRequiredService<IdentityDataContext>();
var publicDataContext = service.GetRequiredService<PublicDataContext>();
var userDataContext = service.GetRequiredService<UserDataContext>();

var userManager = service.GetRequiredService<UserManager<AppUser>>();
identityContext.Database.Migrate();
await IdentitySeedUsers.Seed(identityContext, userManager);

publicDataContext.Database.Migrate();
await SeedAppData.SeedData(publicDataContext);

userDataContext.Database.Migrate();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
