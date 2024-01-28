using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddCreatedOnColumnToHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("2626b91e-db9d-4820-a956-230de2eda556"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4f648f93-eb4c-4ee2-8969-aa5be0ef5c69"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("ce7992c6-b032-4f1d-8588-8ca69e227683"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f8710f38-dafb-4adb-8d90-232bffbd4942"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 54, 1, 685, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "PESHOTHEAGENT@AGENT.COM", "PESHOTHEAGENT@AGENT.COM", "peshoTheAgent@agent.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "GOSHOTHERENTER@RENTER.COM", "GOSHOTHERENTER@RENTER.COM", "goshoTheRenter@renter.com" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("133af32c-628f-4cab-911c-0a26ce2d0c3b"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Family House Comfort" },
                    { new Guid("318fb07c-31a9-49e2-a418-6609991ca936"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" },
                    { new Guid("6d2a9d3f-c384-4092-a598-6feaca7b3cab"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("a4ea3101-1642-4ef1-bd18-267705db3a8e"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe36acb-8c75-42d4-c03d-08dc1ff94547"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { null, null, null });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("2626b91e-db9d-4820-a956-230de2eda556"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("4f648f93-eb4c-4ee2-8969-aa5be0ef5c69"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Family House Comfort" },
                    { new Guid("ce7992c6-b032-4f1d-8588-8ca69e227683"), "North London, UK (near the border)", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 3, "A big house for your whole family. Don't miss to rent a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("6acc5766-87f9-4f30-c03e-08dc1ff94547"), "Big House Marina" },
                    { new Guid("f8710f38-dafb-4adb-8d90-232bffbd4942"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("ace3ab43-264e-4b2d-b56d-274170bacfc5"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" }
                });
        }
    }
}
