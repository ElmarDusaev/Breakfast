using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Breakfast.Migrations
{
    public partial class Somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDateTime",
                table: "OrderHdrs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "DeliveryDateTime",
                table: "OrderHdrs");

        }
    }
}
