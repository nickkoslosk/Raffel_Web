using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class updateScopeEAU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RENDER",
                table: "NetsuiteEntry");

            migrationBuilder.AlterColumn<int>(
                name: "TARGET_PRICE",
                table: "Scope",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EAU",
                table: "Scope",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TARGET_PRICE",
                table: "Scope",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "EAU",
                table: "Scope",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<byte[]>(
                name: "RENDER",
                table: "NetsuiteEntry",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
