using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffel_Web.Migrations
{
    public partial class AddRevisionsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REQ_REV_DATE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "REVISION_DATE",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "REV_DETAILS",
                table: "Scope");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_STARTED",
                table: "Scope",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TOOLING_RELEASED",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TOOLING_COMPLETE",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PPAP_RCVD",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FILES_TO_MANUFACTURE",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_STARTED",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "COMMIT_DATE",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BETA_DATE",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ALPHA_DATE",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Revision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAD_NUMBER = table.Column<string>(nullable: true),
                    ORIGINAL_SCOPE = table.Column<string>(nullable: true),
                    REVISION_DATE = table.Column<DateTime>(nullable: false),
                    DATE_STARTED = table.Column<DateTime>(nullable: true),
                    REQ_REV_DATE = table.Column<DateTime>(nullable: false),
                    REV_DETAILS = table.Column<string>(nullable: true),
                    DATE_COMPLETE = table.Column<DateTime>(nullable: false),
                    COMPLETE_BY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_STARTED",
                table: "Scope",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "REQ_REV_DATE",
                table: "Scope",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "REVISION_DATE",
                table: "Scope",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "REV_DETAILS",
                table: "Scope",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TOOLING_RELEASED",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TOOLING_COMPLETE",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PPAP_RCVD",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FILES_TO_MANUFACTURE",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_STARTED",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "COMMIT_DATE",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BETA_DATE",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ALPHA_DATE",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
