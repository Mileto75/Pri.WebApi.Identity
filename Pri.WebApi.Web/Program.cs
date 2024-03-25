using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.CleanArchitecture.Core.Interfaces.Repositories;
using Pri.CleanArchitecture.Core.Interfaces.Services;
using Pri.CleanArchitecture.Core.Services;
using Pri.CleanArchitecture.Infrastructure.Data;
using Pri.CleanArchitecture.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IPropertyRepository,PropertyRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
//Register database service
builder.Services.AddDbContext<ApplicationDbContext>(options
    => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")).EnableSensitiveDataLogging());
//Add Identity service
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        //in production code
        options.SignIn.RequireConfirmedEmail = true;
        options.User.RequireUniqueEmail = true;
        //password testing rules only for testing purposes!!!
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 4;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
    
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();