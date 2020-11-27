using Microsoft.EntityFrameworkCore.Migrations;

namespace VerusDate.Server.Data.Migrations
{
    public partial class MelhoriasCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFaceValidation",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFileName1",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFileName2",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFileName3",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFileName4",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoFileName5",
                table: "Profile");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Profile",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                table: "Profile",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPhotoValidation",
                table: "Profile",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoGallery",
                table: "Profile",
                type: "varchar(4000)",
                unicode: false,
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPhoto",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MainPhotoValidation",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhotoGallery",
                table: "Profile");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Profile",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFaceValidation",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName1",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName2",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName3",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName4",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName5",
                table: "Profile",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);
        }
    }
}
