﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AutoGeneretedIdsAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Cottage" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Single-Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Duplex" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
