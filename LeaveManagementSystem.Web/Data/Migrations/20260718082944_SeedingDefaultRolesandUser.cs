using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4499ef20-d1b8-4321-a8bc-9c9d614f7c82", null, "Supervisor", "SUPERVISOR" },
                    { "54546861-8ad4-4e17-996e-685fddf5d136", null, "Employee", "EMPLOYEE" },
                    { "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6", null, "Administrator", "ADMINSTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "080ed4e0-86ed-4f80-b10c-f1d23925ceb8", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDIiYzeNCZzOXhgN+hPjZMcJZtRkxBn3Wn4cdqUrC9yv03Q9xuPWA2qEZqHyq21HKw==", null, false, "18004722-3433-4a71-8883-00dc1a19c497", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4499ef20-d1b8-4321-a8bc-9c9d614f7c82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54546861-8ad4-4e17-996e-685fddf5d136");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
