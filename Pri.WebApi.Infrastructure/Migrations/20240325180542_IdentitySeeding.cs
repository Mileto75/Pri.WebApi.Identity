using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.CleanArchitecture.Infrastructure.Migrations
{
    public partial class IdentitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "982e69b8-9523-427b-91e6-1beda58f91b0", new DateTime(2024, 3, 25, 19, 5, 41, 728, DateTimeKind.Local).AddTicks(998), "admin@food.com", false, "Bart", "Soete", false, null, "ADMIN@FOOD.COM", "ADMIN@FOOD.COM", "AQAAAAEAACcQAAAAEN/bEyfg+7x/QYKsVB3t9A8EfnJN6WHdt+xtKW6UcKuI6WonInJHnKNla/rD281yyw==", null, false, "ee8759f9-33b0-4ec5-85a9-95b041c0d6b1", false, "admin@food.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "67e2d4d2-026c-4f1f-a19e-6f19568a30f1", new DateTime(2024, 3, 25, 19, 5, 41, 728, DateTimeKind.Local).AddTicks(1090), "user@food.com", false, "Mileto", "Di Marco", false, null, "USER@FOOD.COM", "USER@FOOD.COM", "AQAAAAEAACcQAAAAEMRFiEU07gWppl78DDJNMjRVlDy+Fn7qDqbCmbHZPw3w1e2aIfY7moBpNcr/Xpqj8Q==", null, false, "0eb2c091-f0db-4e33-b336-030e78547016", false, "user@food.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
