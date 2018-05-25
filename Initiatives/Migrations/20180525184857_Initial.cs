using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Initiatives.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    BusinessShortDescription = table.Column<string>(type: "nchar(15)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "DeploymentLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LocationDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    LocationShortDescription = table.Column<string>(type: "nchar(15)", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeploymentLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "EngagementType",
                columns: table => new
                {
                    EngagementTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngagementTypeDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    EngagementTypeShortDescription = table.Column<string>(type: "nchar(15)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngagementType", x => x.EngagementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacilityDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    FacilityShortDescription = table.Column<string>(type: "nchar(15)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "MetaTag",
                columns: table => new
                {
                    MetaTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    MetaTagDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    MetaTagShortDescription = table.Column<string>(type: "nchar(15)", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTag", x => x.MetaTagId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nchar(15)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(type: "nchar(15)", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "SolutionType",
                columns: table => new
                {
                    SolutionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true),
                    SolutionTypeDescription = table.Column<string>(type: "nchar(25)", nullable: false),
                    SolutionTypeShortDescription = table.Column<string>(type: "nchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionType", x => x.SolutionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Initiative",
                columns: table => new
                {
                    InitiativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ARBDate = table.Column<DateTime>(type: "date", nullable: true),
                    CompleteDate = table.Column<DateTime>(type: "date", nullable: true),
                    DownStreamSystem = table.Column<string>(type: "nchar(25)", nullable: true),
                    EngagementIdentifier = table.Column<string>(type: "nchar(15)", nullable: true),
                    EngagementName = table.Column<string>(type: "nchar(15)", nullable: true),
                    EngagementTypeId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true),
                    PCI = table.Column<bool>(type: "bit", nullable: false),
                    PHI = table.Column<bool>(type: "bit", nullable: false),
                    ProjectStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Resource = table.Column<int>(nullable: true),
                    SolutionTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpStreamSystem = table.Column<string>(type: "nchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Initiative", x => x.InitiativeId);
                    table.ForeignKey(
                        name: "FK_Initiative_EngagementType",
                        column: x => x.EngagementTypeId,
                        principalTable: "EngagementType",
                        principalColumn: "EngagementTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Initiative_Location",
                        column: x => x.LocationId,
                        principalTable: "DeploymentLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Initiative_Resource",
                        column: x => x.Resource,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Initiative_SolutionType",
                        column: x => x.SolutionTypeId,
                        principalTable: "SolutionType",
                        principalColumn: "SolutionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InitiativeBusiness",
                columns: table => new
                {
                    InitiativeId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeBusiness", x => new { x.InitiativeId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_InitiativeBusiness_Business",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InitiativeBusiness_Initiative",
                        column: x => x.InitiativeId,
                        principalTable: "Initiative",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InitiativeFacility",
                columns: table => new
                {
                    InitiativeId = table.Column<int>(nullable: false),
                    FacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeFacility", x => new { x.InitiativeId, x.FacilityId });
                    table.ForeignKey(
                        name: "FK_InitiativeFacility_Facility",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InitiativeFacility_Initiative",
                        column: x => x.InitiativeId,
                        principalTable: "Initiative",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InitiativeMetaTag",
                columns: table => new
                {
                    InitiativeId = table.Column<int>(nullable: false),
                    MetaTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeMetaTag", x => new { x.InitiativeId, x.MetaTagId });
                    table.ForeignKey(
                        name: "FK_InitiativeMetaTag_Initiative",
                        column: x => x.InitiativeId,
                        principalTable: "Initiative",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InitiativeMetaTag_MetaTags",
                        column: x => x.MetaTagId,
                        principalTable: "MetaTag",
                        principalColumn: "MetaTagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    InitiativeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nchar(150)", nullable: true),
                    Note = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(type: "nchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_Initiative",
                        column: x => x.NoteId,
                        principalTable: "Initiative",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Initiative_EngagementTypeId",
                table: "Initiative",
                column: "EngagementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Initiative_LocationId",
                table: "Initiative",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Initiative_Resource",
                table: "Initiative",
                column: "Resource");

            migrationBuilder.CreateIndex(
                name: "IX_Initiative_SolutionTypeId",
                table: "Initiative",
                column: "SolutionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeBusiness_BusinessId",
                table: "InitiativeBusiness",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeFacility_FacilityId",
                table: "InitiativeFacility",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeMetaTag_MetaTagId",
                table: "InitiativeMetaTag",
                column: "MetaTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiativeBusiness");

            migrationBuilder.DropTable(
                name: "InitiativeFacility");

            migrationBuilder.DropTable(
                name: "InitiativeMetaTag");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "MetaTag");

            migrationBuilder.DropTable(
                name: "Initiative");

            migrationBuilder.DropTable(
                name: "EngagementType");

            migrationBuilder.DropTable(
                name: "DeploymentLocation");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "SolutionType");
        }
    }
}
