using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Initiatives.Migrations
{
    public partial class Keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Initiative_DeploymentLocation",
                table: "Initiative");

            migrationBuilder.DropForeignKey(
                name: "FK_Initiative_EngagementType",
                table: "Initiative");

            migrationBuilder.RenameColumn(
                name: "SolutionType",
                table: "Initiative",
                newName: "SolutionTypeId");

            migrationBuilder.RenameColumn(
                name: "EngagementType",
                table: "Initiative",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "DeploymentLocation",
                table: "Initiative",
                newName: "EngagementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_SolutionType",
                table: "Initiative",
                newName: "IX_Initiative_SolutionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_EngagementType",
                table: "Initiative",
                newName: "IX_Initiative_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_DeploymentLocation",
                table: "Initiative",
                newName: "IX_Initiative_EngagementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Initiative_EngagementType",
                table: "Initiative",
                column: "EngagementTypeId",
                principalTable: "EngagementType",
                principalColumn: "EngagementTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Initiative_Location",
                table: "Initiative",
                column: "LocationId",
                principalTable: "DeploymentLocation",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Initiative_EngagementType",
                table: "Initiative");

            migrationBuilder.DropForeignKey(
                name: "FK_Initiative_Location",
                table: "Initiative");

            migrationBuilder.RenameColumn(
                name: "SolutionTypeId",
                table: "Initiative",
                newName: "SolutionType");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Initiative",
                newName: "EngagementType");

            migrationBuilder.RenameColumn(
                name: "EngagementTypeId",
                table: "Initiative",
                newName: "DeploymentLocation");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_SolutionTypeId",
                table: "Initiative",
                newName: "IX_Initiative_SolutionType");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_LocationId",
                table: "Initiative",
                newName: "IX_Initiative_EngagementType");

            migrationBuilder.RenameIndex(
                name: "IX_Initiative_EngagementTypeId",
                table: "Initiative",
                newName: "IX_Initiative_DeploymentLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Initiative_DeploymentLocation",
                table: "Initiative",
                column: "DeploymentLocation",
                principalTable: "DeploymentLocation",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Initiative_EngagementType",
                table: "Initiative",
                column: "EngagementType",
                principalTable: "EngagementType",
                principalColumn: "EngagementTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
