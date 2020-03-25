using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class NetsuiteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetsuiteEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAD_NUMBER = table.Column<string>(nullable: true),
                    PART_SUB = table.Column<string>(nullable: false),
                    MFG_COST = table.Column<string>(nullable: true),
                    PRICE = table.Column<string>(nullable: true),
                    LAST_UPDATE = table.Column<DateTime>(nullable: false),
                    MANUFACTURER = table.Column<string>(nullable: true),
                    SALES_DES = table.Column<string>(nullable: true),
                    PURCHASE_INFO = table.Column<string>(nullable: true),
                    SUB_BY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetsuiteEntry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetsuiteEntry");
        }
    }
}
