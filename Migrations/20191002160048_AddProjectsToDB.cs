using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class AddProjectsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAD_NUMBER = table.Column<string>(nullable: true),
                    ENTRY_DATE = table.Column<DateTime>(nullable: true),
                    NOTES = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAD_NUMBER = table.Column<string>(maxLength: 7, nullable: false),
                    PROJECT_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    PART_NUMBER = table.Column<string>(maxLength: 30, nullable: true),
                    DATE_STARTED = table.Column<DateTime>(nullable: true),
                    PRIORITY = table.Column<string>(maxLength: 20, nullable: true),
                    CUSTOMER = table.Column<string>(maxLength: 20, nullable: true),
                    DELIVERABLE = table.Column<string>(maxLength: 20, nullable: true),
                    COMMIT_DATE = table.Column<DateTime>(nullable: true),
                    EE_LEAD = table.Column<string>(maxLength: 18, nullable: true),
                    ME_LEAD = table.Column<string>(maxLength: 18, nullable: true),
                    ALPHA_DATE = table.Column<DateTime>(nullable: true),
                    BETA_DATE = table.Column<DateTime>(nullable: true),
                    FILES_TO_MANUFACTURE = table.Column<DateTime>(nullable: true),
                    PPAP_RCVD = table.Column<DateTime>(nullable: true),
                    TOOLING_RELEASED = table.Column<DateTime>(nullable: true),
                    TOOLING_COMPLETE = table.Column<DateTime>(nullable: true),
                    SALESMAN = table.Column<string>(maxLength: 20, nullable: true),
                    USERNAME = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scope",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAD_NUMBER = table.Column<string>(nullable: true),
                    ORIGINAL_SCOPE = table.Column<string>(nullable: true),
                    REVISION_DATE = table.Column<DateTime>(nullable: true),
                    DATE_STARTED = table.Column<DateTime>(nullable: true),
                    REQ_REV_DATE = table.Column<DateTime>(nullable: true),
                    REV_DETAILS = table.Column<string>(nullable: true),
                    DATE_COMPLETE = table.Column<DateTime>(nullable: true),
                    COMPLETE_BY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scope", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Scope");
        }
    }
}
