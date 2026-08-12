using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "604529ac-cd5e-4918-a232-b1504b12a31d", "AQAAAAIAAYagAAAAEGrIpDAHt5SDlbmBR6CLi1Mk5tWAThbmH2no1GkD3HXDVJQlU1Bd4V1+wLr9DpSgRw==", "93853497-f8e3-4743-b4ae-5c528fb7155a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "719cec8a-5ebf-49a3-bd18-43a49ca74862", "AQAAAAIAAYagAAAAEDQSbIXop2yLtbvdFbxi2Eq3K0w41OZgy2U6RKlVoQ3DJo+um+PwQPv1kRP/fLGUaQ==", "591277bd-236f-4cc1-a038-56f8ef88189e" });
        }
    }
}
