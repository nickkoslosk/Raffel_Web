using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class updateScope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CONNECTIONS",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CUSTOMER_SCOPE",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATE_NEEDED",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FIRST_DELIVERABLE",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PRODUCT_TYPE",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SCOPE_ORIGINATOR",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIMILAR_TO",
                table: "Scope",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WHERE_SEND",
                table: "Scope",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CONNECTIONS",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "CUSTOMER_SCOPE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "DATE_NEEDED",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "FIRST_DELIVERABLE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "PRODUCT_TYPE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "SCOPE_ORIGINATOR",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "SIMILAR_TO",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "WHERE_SEND",
                table: "Scope");
        }
    }
}
