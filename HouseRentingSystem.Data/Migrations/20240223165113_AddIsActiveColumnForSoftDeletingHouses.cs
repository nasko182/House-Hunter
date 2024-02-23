using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddIsActiveColumnForSoftDeletingHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("133af32c-628f-4cab-911c-0a26ce2d0c3b"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("318fb07c-31a9-49e2-a418-6609991ca936"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6d2a9d3f-c384-4092-a598-6feaca7b3cab"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("a4ea3101-1642-4ef1-bd18-267705db3a8e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 54, 1, 685, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Houses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 54, 1, 685, DateTimeKind.Utc).AddTicks(6607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("133af32c-628f-4cab-911c-0a26ce2d0c3b"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Family House Comfort" },
                    { new Guid("318fb07c-31a9-49e2-a418-6609991ca936"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" },
                    { new Guid("6d2a9d3f-c384-4092-a598-6feaca7b3cab"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("a4ea3101-1642-4ef1-bd18-267705db3a8e"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" }
                });
        }
    }
}
