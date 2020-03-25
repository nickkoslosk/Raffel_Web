using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class ScopeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EAU",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TARGET_PRICE",
                table: "Scope",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EAU",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "TARGET_PRICE",
                table: "Scope");
        }
    }
}
