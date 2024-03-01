using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class ChangeCustomUsersNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("999deb5a-9920-4ffc-992e-462a0db2c30f"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f6d514bf-e266-41ef-bdf6-577f5e8412c1"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f86fcc8b-a7ec-4e18-9940-3781f3dced3f"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "Testov");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "Test");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "petarTheAgent@agent.com", "Petar", "Petrov", "PETARTHEAGENT@AGENT.COM", "PETARTHEAGENT@AGENT.COM", "petarTheAgent@agent.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "georgiTheRenter@renter.com", "Georgi", "Georgiev", "GEORGITHERENTER@RENTER.COM", "GEORGITHERENTER@RENTER.COM", "georgiTheRenter@renter.com" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("46b968e1-7e21-4377-8f4f-4ae2c72d0ae4"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 16, 43, 12, 701, DateTimeKind.Utc).AddTicks(4621), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" },
                    { new Guid("578b06e9-5f14-4938-a222-26128e535966"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 16, 43, 12, 701, DateTimeKind.Utc).AddTicks(4624), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" },
                    { new Guid("82d46e9e-e42c-4f0a-be8d-ed324e8b70f2"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(2024, 3, 1, 16, 43, 12, 701, DateTimeKind.Utc).AddTicks(4596), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://static4.superimoti.bg/property-images/big/84166_1.jpg", true, 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("46b968e1-7e21-4377-8f4f-4ae2c72d0ae4"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("578b06e9-5f14-4938-a222-26128e535966"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("82d46e9e-e42c-4f0a-be8d-ed324e8b70f2"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "peshoTheAgent@agent.com", "Pesho", "Peshov", "PESHOTHEAGENT@AGENT.COM", "PESHOTHEAGENT@AGENT.COM", "peshoTheAgent@agent.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "goshoTheRenter@renter.com", "Gosho", "Goshov", "GOSHOTHERENTER@RENTER.COM", "GOSHOTHERENTER@RENTER.COM", "goshoTheRenter@renter.com" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("999deb5a-9920-4ffc-992e-462a0db2c30f"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(2024, 3, 1, 14, 18, 53, 228, DateTimeKind.Utc).AddTicks(147), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://static4.superimoti.bg/property-images/big/84166_1.jpg", true, 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" },
                    { new Guid("f6d514bf-e266-41ef-bdf6-577f5e8412c1"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 18, 53, 228, DateTimeKind.Utc).AddTicks(172), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" },
                    { new Guid("f86fcc8b-a7ec-4e18-9940-3781f3dced3f"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 18, 53, 228, DateTimeKind.Utc).AddTicks(183), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" }
                });
        }
    }
}
