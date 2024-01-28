using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class InicializeUsersAndAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"), 0, "98e12ef7-b59f-4729-af26-db318efad511", "peshoTheAgent@agent.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEO7JovbSo1gy2Vp6mqwYLHj4TZkQjfbpWklUVyzASAC3yKHJT0PD8mn8xatcrgFMNw==", null, false, "VSTG5SK3JGPHVTCZ2P7ZPBS7RPUSSWRQ", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), 0, "11d23514-fa48-496d-9605-7ba6ef6c1260", "goshoTheRenter@renter.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPL07n/1SrJYy2pO6hVqiySKNg3VsgB+cjlr+CvshIEQ70RiD/8WQSu4PSrZ1TSgNw==", null, false, "HS3DCKS3MZ7VNAPRX5DZZWJHID2TSRXW", false, null });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), "+359888888888", new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"));
        }
    }
}
