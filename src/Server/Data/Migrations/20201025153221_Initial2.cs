using Microsoft.EntityFrameworkCore.Migrations;

namespace VerusDate.Server.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Validated",
                table: "Badge");

            migrationBuilder.AddColumn<int>(
                name: "CompletedProfile_Level",
                table: "Badge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Popular_Level",
                table: "Badge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank_Level",
                table: "Badge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seniority_Level",
                table: "Badge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VerifiedProfile_Level",
                table: "Badge",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedProfile_Level",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Popular_Level",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Rank_Level",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Seniority_Level",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "VerifiedProfile_Level",
                table: "Badge");

            migrationBuilder.AddColumn<bool>(
                name: "Popular",
                table: "Badge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Validated",
                table: "Badge",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
