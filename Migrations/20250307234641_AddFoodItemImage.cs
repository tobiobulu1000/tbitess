using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tbites_Restaurant.Migrations
{
    public partial class AddFoodItemImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "FoodItems",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                table: "FoodItems",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                table: "FoodItems");
        }
    }
}
