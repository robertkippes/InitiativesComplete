using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Initiatives.Migrations
{
    public partial class inheritedClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "SolutionType",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Resource",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Note",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Note",
                type: "nchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "MetaTag",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Initiative",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Facility",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "EngagementType",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "DeploymentLocation",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Businesses",
                type: "nchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Note");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "SolutionType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Resource",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "MetaTag",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Initiative",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Facility",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "EngagementType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "DeploymentLocation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedUserName",
                table: "Businesses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(150)");
        }
    }
}
