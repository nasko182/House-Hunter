using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class GenereataAutoAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Pesho", "Peshov" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Gosho", "Goshov" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("50c9caf6-b29d-40bb-805b-60b2239c658d"), 0, "WAU6MNVIDHYI7YF56TCS3MYLIELT4FRQ", "admin@admin.com", false, "Admin", "Adminov", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEZGWOYr44CMMcBewruzlneP9Yk+odUQQLsOdemYZ+mM6ntwsdUi5XVFguLBUJja+w==", null, false, "HS3DCKS3MZ7VNAPRX5DZZWJHID2TSRXW", false, "admin@admin.com" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50c9caf6-b29d-40bb-805b-60b2239c658d"));

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("267ef549-38ad-4790-951c-0887fd9703fb"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(221), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" },
                    { new Guid("49b403b1-5215-48f7-9466-4f6c57911f95"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(206), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" },
                    { new Guid("fb68a24e-7eaf-475e-a1c5-8a880e088e4d"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(2024, 3, 1, 14, 11, 0, 831, DateTimeKind.Utc).AddTicks(183), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://static4.superimoti.bg/property-images/big/84166_1.jpg", true, 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" }
                });
        }
    }
}
