using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddCustomAdminAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("6a347f29-0054-40ec-9f7a-1099d214430e"), "+359888888887", new Guid("50c9caf6-b29d-40bb-805b-60b2239c658d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6a347f29-0054-40ec-9f7a-1099d214430e"));
        }
    }
}
