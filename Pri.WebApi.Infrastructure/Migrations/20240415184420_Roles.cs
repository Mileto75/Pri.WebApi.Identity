using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.CleanArchitecture.Infrastructure.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "af489854-c86f-417a-8207-cd2ad525a6e7", "Admin", "ADMIN" },
                    { "2", "37132190-ecc6-4d04-9695-d34ba979c37e", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e65ce489-4b2b-4d96-93c1-6034ca4e2804", new DateTime(2024, 4, 15, 20, 44, 19, 980, DateTimeKind.Local).AddTicks(6878), "AQAAAAEAACcQAAAAEEUIO5Hykve0YVAwdYAM1HG1KY8+SL6Ail4Hc2YMfeNm2mWCCfeIxmEivGO/ZqYGBg==", "2801da29-7f72-4f83-9d6c-d5e9452d7d5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f5ed9df-f748-4260-acfb-0265c9fbe84b", new DateTime(2024, 4, 15, 20, 44, 19, 980, DateTimeKind.Local).AddTicks(6929), "AQAAAAEAACcQAAAAEDdfz4VZa7I+W7lh3sm8YXMJ4cNyxULKPDfaCxRYa+9rc1okGi7WaotrgfBEaX4cGg==", "05a241d4-38f1-49a4-acb0-1d1f5a80125a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "982e69b8-9523-427b-91e6-1beda58f91b0", new DateTime(2024, 3, 25, 19, 5, 41, 728, DateTimeKind.Local).AddTicks(998), "AQAAAAEAACcQAAAAEN/bEyfg+7x/QYKsVB3t9A8EfnJN6WHdt+xtKW6UcKuI6WonInJHnKNla/rD281yyw==", "ee8759f9-33b0-4ec5-85a9-95b041c0d6b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67e2d4d2-026c-4f1f-a19e-6f19568a30f1", new DateTime(2024, 3, 25, 19, 5, 41, 728, DateTimeKind.Local).AddTicks(1090), "AQAAAAEAACcQAAAAEMRFiEU07gWppl78DDJNMjRVlDy+Fn7qDqbCmbHZPw3w1e2aIfY7moBpNcr/Xpqj8Q==", "0eb2c091-f0db-4e33-b336-030e78547016" });
        }
    }
}
