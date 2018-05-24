using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Initiatives.Migrations
{
    public partial class LastModifiedClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Business",
                table: "Initiative");

            migrationBuilder.DropColumn(
                name: "Facility",
                table: "Initiative");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Initiative",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Initiative",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Initiative");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Initiative");

            migrationBuilder.AddColumn<int>(
                name: "Business",
                table: "Initiative",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Facility",
                table: "Initiative",
                nullable: true);
        }
    }
}
