using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.CleanArchitecture.Infrastructure.Migrations
{
    public partial class changeRolesToClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user", "2" },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "22/04/2024", "1" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "22/04/2024", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a392e2d3-7fe1-43e4-b427-672319977105", new DateTime(2024, 4, 22, 20, 56, 28, 683, DateTimeKind.Local).AddTicks(1234), "AQAAAAEAACcQAAAAEO/9IUSWter5IZaW96B5uhA9u+NXn9t2esTpblZs5jA8lJoa7fkyXgPCCVb1XfT4xw==", "bc72194e-f397-4ff2-9be0-dce2add9b396" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d16d7bb9-4e08-4795-8038-eb5036850fa6", new DateTime(2024, 4, 22, 20, 56, 28, 683, DateTimeKind.Local).AddTicks(1344), "AQAAAAEAACcQAAAAEEg5VjV13V2hJEVuYICE1M34CYGPgXO/QCpNyXEHZPdxWrYuKaykxKWwcArRKfcf2Q==", "635b74d7-a806-483a-9d32-19c765dba920" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
