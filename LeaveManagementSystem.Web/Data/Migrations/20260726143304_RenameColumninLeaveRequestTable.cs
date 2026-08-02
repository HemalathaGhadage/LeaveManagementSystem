using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumninLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestCommands",
                table: "LeaveRequests",
                newName: "RequestComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "719cec8a-5ebf-49a3-bd18-43a49ca74862", "AQAAAAIAAYagAAAAEDQSbIXop2yLtbvdFbxi2Eq3K0w41OZgy2U6RKlVoQ3DJo+um+PwQPv1kRP/fLGUaQ==", "591277bd-236f-4cc1-a038-56f8ef88189e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestComments",
                table: "LeaveRequests",
                newName: "RequestCommands");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700941ec-289e-41ba-ac2e-165a2d441f5a", "AQAAAAIAAYagAAAAEGGfvqQkkk+OpDj3F/PFHuhLdsz3HnvRrNYDtQK6K2RMaxHI5zAaYnMe+yiv1gnayQ==", "dd283ee8-ce7c-47bf-9007-df5ce36bc7b9" });
        }
    }
}
