using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VerusDate.Server.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Rank_Level = table.Column<int>(type: "int", nullable: true),
                    Seniority_Level = table.Column<int>(type: "int", nullable: true),
                    CompletedProfile_Level = table.Column<int>(type: "int", nullable: true),
                    VerifiedProfile_Level = table.Column<int>(type: "int", nullable: true),
                    Popular_Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    IdChat = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtMessage = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUserSender = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    TypeContent = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsSync = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => new { x.IdChat, x.DtMessage });
                });

            migrationBuilder.CreateTable(
                name: "Gamification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Diamond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    IdUserInteraction = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    Like_Value = table.Column<bool>(type: "bit", nullable: true),
                    Like_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deslike_Value = table.Column<bool>(type: "bit", nullable: true),
                    Deslike_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Match_Value = table.Column<bool>(type: "bit", nullable: true),
                    Match_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Blink_Value = table.Column<bool>(type: "bit", nullable: true),
                    Blink_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Block_Value = table.Column<bool>(type: "bit", nullable: true),
                    Block_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdChat = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => new { x.Id, x.IdUserInteraction });
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DtTopList = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    DtLastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    NickName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BiologicalSex = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Intent = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    GenderIdentity = table.Column<int>(type: "int", nullable: false),
                    SexualOrientation = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    CountryName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    State = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    BodyMass = table.Column<int>(type: "int", nullable: false),
                    RaceCategory = table.Column<int>(type: "int", nullable: false),
                    Smoke = table.Column<int>(type: "int", nullable: false),
                    Drink = table.Column<int>(type: "int", nullable: false),
                    Diet = table.Column<int>(type: "int", nullable: false),
                    HaveChildren = table.Column<int>(type: "int", nullable: true),
                    WantChildren = table.Column<int>(type: "int", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: true),
                    CareerCluster = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<int>(type: "int", nullable: true),
                    MoneyPersonality = table.Column<int>(type: "int", nullable: true),
                    RelationshipPersonality = table.Column<int>(type: "int", nullable: true),
                    MyersBriggsTypeIndicator = table.Column<int>(type: "int", nullable: true),
                    Hobbies = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    PhotoFileName1 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    PhotoFileName2 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    PhotoFileName3 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    PhotoFileName4 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    PhotoFileName5 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    PhotoFaceValidation = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLooking",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Intent = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    MinimalAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    BiologicalSex = table.Column<int>(type: "int", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    GenderIdentity = table.Column<int>(type: "int", nullable: true),
                    SexualOrientation = table.Column<int>(type: "int", nullable: true),
                    MinimalHeight = table.Column<int>(type: "int", nullable: true),
                    MaxHeight = table.Column<int>(type: "int", nullable: true),
                    BodyMass = table.Column<int>(type: "int", nullable: true),
                    RaceCategory = table.Column<int>(type: "int", nullable: true),
                    Smoke = table.Column<int>(type: "int", nullable: true),
                    Drink = table.Column<int>(type: "int", nullable: true),
                    Diet = table.Column<int>(type: "int", nullable: true),
                    HaveChildren = table.Column<int>(type: "int", nullable: true),
                    WantChildren = table.Column<int>(type: "int", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: true),
                    CareerCluster = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLooking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    IdUserOwner = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    DtTicket = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketVote",
                columns: table => new
                {
                    IdTicket = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtVote = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketVote", x => new { x.IdTicket, x.IdUser });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Gamification");

            migrationBuilder.DropTable(
                name: "Interaction");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "ProfileLooking");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketVote");
        }
    }
}