using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class updateNetsuite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PRIORITY",
                table: "Projects",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "NetsuiteEntry",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "NetsuiteEntry");

            migrationBuilder.AlterColumn<string>(
                name: "PRIORITY",
                table: "Projects",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
