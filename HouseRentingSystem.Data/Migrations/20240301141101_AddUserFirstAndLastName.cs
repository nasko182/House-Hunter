using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddUserFirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("64de976b-348e-467e-bcdf-88822effaafd"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("a0b4e73f-4214-4880-8737-70bc53bb7f91"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("db9d7874-c38c-40f5-99d4-0f0083026cf0"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("267ef549-38ad-4790-951c-0887fd9703fb"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(221), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("49b403b1-5215-48f7-9466-4f6c57911f95"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(206), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("fb68a24e-7eaf-475e-a1c5-8a880e088e4d"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(183), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://static4.superimoti.bg/property-images/big/84166_1.jpg", true, 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("267ef549-38ad-4790-951c-0887fd9703fb"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("49b403b1-5215-48f7-9466-4f6c57911f95"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("fb68a24e-7eaf-475e-a1c5-8a880e088e4d"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("64de976b-348e-467e-bcdf-88822effaafd"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(2024, 2, 23, 16, 51, 13, 177, DateTimeKind.Utc).AddTicks(9597), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://static4.superimoti.bg/property-images/big/84166_1.jpg", true, 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("a0b4e73f-4214-4880-8737-70bc53bb7f91"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 2, 23, 16, 51, 13, 177, DateTimeKind.Utc).AddTicks(9618), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("db9d7874-c38c-40f5-99d4-0f0083026cf0"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 2, 23, 16, 51, 13, 177, DateTimeKind.Utc).AddTicks(9614), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" });
        }
    }
}
