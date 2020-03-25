using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class UpdateScopeAndRev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COMPLETE_BY",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "DATE_COMPLETE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "ORIGINAL_SCOPE",
                table: "Revision");

            migrationBuilder.DropColumn(
                name: "REQ_REV_DATE",
                table: "Revision");

            migrationBuilder.DropColumn(
                name: "REVISION_DATE",
                table: "Revision");

            migrationBuilder.RenameColumn(
                name: "DATE_STARTED",
                table: "Scope",
                newName: "DATE_ENTERED");

            migrationBuilder.RenameColumn(
                name: "DATE_STARTED",
                table: "Revision",
                newName: "DATE_ENTERED");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATE_ENTERED",
                table: "Scope",
                newName: "DATE_STARTED");

            migrationBuilder.RenameColumn(
                name: "DATE_ENTERED",
                table: "Revision",
                newName: "DATE_STARTED");

            migrationBuilder.AddColumn<string>(
                name: "COMPLETE_BY",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATE_COMPLETE",
                table: "Scope",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ORIGINAL_SCOPE",
                table: "Revision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "REQ_REV_DATE",
                table: "Revision",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "REVISION_DATE",
                table: "Revision",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
