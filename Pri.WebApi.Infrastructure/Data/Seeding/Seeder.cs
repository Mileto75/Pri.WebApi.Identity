using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.CleanArchitecture.Core.Entities;
using Pri.WebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var categories = new Category[]
            {
                new Category{Id = 1, Name = "Asian" },
                new Category{Id = 2, Name = "Italian" },
                new Category{Id = 3, Name = "Belgian" },
                new Category{Id = 4, Name = "Greek" },
            };
            var properties = new Property[]
            {
                new Property{Id = 1,Name="Spicy" },
                new Property{Id = 2,Name="Sweet" },
                new Property{Id = 3,Name="Hot" },
                new Property{Id = 4,Name="Cold" },
            };
            var products = new Product[]
            {
                new Product{Id = 1,Name="Sushi",CategoryId=1,Price=8.90M,Description="Fresh fish"},
                new Product{Id = 2,Name="Spaghetti aglio e olio",CategoryId=2,Price=8.90M,Description="Garlic and oil"},
                new Product{Id = 3,Name="Frieten met stoverijsaus",CategoryId=3,Price=8.90M,Description="A classic!"},
                new Product{Id = 4,Name="Moussaka",CategoryId=4,Price=8.90M,Description="A classic!"},
            };
            var productsProperties = new[]
            {
                new {ProductsId=1,PropertiesId=1 },
                new {ProductsId=1,PropertiesId=2 },
                new {ProductsId=2,PropertiesId=3 },
                new {ProductsId=2,PropertiesId=4 },
                new {ProductsId=3,PropertiesId=1 },
                new {ProductsId=3,PropertiesId=2 },
                new {ProductsId=4,PropertiesId=3 },
                new {ProductsId=4,PropertiesId=4 },
            };

            //Identity seeding
            //admin seeding
            var admin = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@food.com",
                Email = "admin@food.com",
                NormalizedEmail = "ADMIN@FOOD.COM",
                NormalizedUserName = "ADMIN@FOOD.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Firstname = "Bart",
                Lastname = "Soete",
                DateOfBirth = DateTime.Now,
            };
            //user seeding
            var user = new ApplicationUser
            {
                Id = "2",
                UserName = "user@food.com",
                Email = "user@food.com",
                NormalizedEmail = "USER@FOOD.COM",
                NormalizedUserName = "USER@FOOD.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Firstname = "Mileto",
                Lastname = "Di Marco",
                DateOfBirth = DateTime.Now,
            };
            //password hash
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Test123");
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123");
            //add claims
            var userClaims = new IdentityUserClaim<string>[]
            {
                new IdentityUserClaim<string>{
                Id = 1,
                UserId = "1",
                ClaimType = ClaimTypes.Role,
                ClaimValue = "admin"
                },
                new IdentityUserClaim<string>{
                Id = 2,
                UserId = "2",
                ClaimType = ClaimTypes.Role,
                ClaimValue = "user"
                },
                new IdentityUserClaim<string>{
                Id = 3,
                UserId = "1",
                ClaimType = ClaimTypes.DateOfBirth,
                ClaimValue = admin.DateOfBirth.ToShortDateString()
                },
                new IdentityUserClaim<string>{
                Id = 4,
                UserId = "2",
                ClaimType = ClaimTypes.DateOfBirth,
                ClaimValue = user.DateOfBirth.ToShortDateString()
                },
            };
            //add classic roles
            //var roles = new IdentityRole[]
            //{
            //    new IdentityRole { Id = "1",Name = "Admin",NormalizedName="ADMIN"},
            //    new IdentityRole { Id = "2",Name = "User",NormalizedName="USER"}
            //};
            ////add users to roles
            //var userRoles = new IdentityUserRole<string>[]
            //{
            //    new IdentityUserRole<string>{RoleId = "1",UserId="1"},//admin
            //    new IdentityUserRole<string>{RoleId = "2",UserId="2"},//user
            //};
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Property>().HasData(properties);
            modelBuilder.Entity($"{nameof(Product)}{nameof(Property)}").HasData(productsProperties);
            modelBuilder.Entity<ApplicationUser>().HasData(admin, user);
            //add classic userroles to database
            //modelBuilder.Entity<IdentityRole>().HasData(roles);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            //add user claims to database
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
        }
    }
}
