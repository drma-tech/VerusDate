using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerusDate.Server.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    IdChat = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtMessage = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUserSender = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    TypeContent = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DtRead = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsSync = table.Column<bool>(type: "bit", nullable: false),
                    DtSync = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => new { x.IdChat, x.DtMessage });
                });

            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    IdUserInteraction = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
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
                    IdChat = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => new { x.IdUser, x.IdUserInteraction });
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtTopList = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtLastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    Location = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
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
                    MainPhoto = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    MainPhotoValidation = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    PhotoGallery = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Rank_Level = table.Column<int>(type: "int", nullable: true),
                    Seniority_Level = table.Column<int>(type: "int", nullable: true),
                    CompletedProfile_Level = table.Column<int>(type: "int", nullable: true),
                    VerifiedProfile_Level = table.Column<int>(type: "int", nullable: true),
                    Popular_Level = table.Column<int>(type: "int", nullable: true),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Badge_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false, defaultValueSql: "NEWID()"),
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    DtStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    MinimalAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    Intent = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    SexualOrientation = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    GenderDivision = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.IdEvent);
                    table.ForeignKey(
                        name: "FK_Event_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Gamification",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Diamond = table.Column<int>(type: "int", nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamification", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Gamification_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLooking",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Intent = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    MinimalAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    BiologicalSex = table.Column<int>(type: "int", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    GenderIdentity = table.Column<int>(type: "int", nullable: true),
                    SexualOrientation = table.Column<int>(type: "int", nullable: true),
                    Smoke = table.Column<int>(type: "int", nullable: true),
                    Drink = table.Column<int>(type: "int", nullable: true),
                    Diet = table.Column<int>(type: "int", nullable: true),
                    MinimalHeight = table.Column<int>(type: "int", nullable: true),
                    MaxHeight = table.Column<int>(type: "int", nullable: true),
                    BodyMass = table.Column<int>(type: "int", nullable: true),
                    RaceCategory = table.Column<int>(type: "int", nullable: true),
                    HaveChildren = table.Column<int>(type: "int", nullable: true),
                    WantChildren = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<int>(type: "int", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: true),
                    CareerCluster = table.Column<int>(type: "int", nullable: true),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLooking", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_ProfileLooking_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false, defaultValueSql: "NEWID()"),
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "TicketVote",
                columns: table => new
                {
                    IdTicket = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    IdUser = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    DtInsert = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DtUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketVote", x => new { x.IdTicket, x.IdUser });
                    table.ForeignKey(
                        name: "FK_TicketVote_Profile_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Profile",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_TicketVote_Ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdUser",
                table: "Event",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdUser",
                table: "Ticket",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TicketVote_IdUser",
                table: "TicketVote",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Gamification");

            migrationBuilder.DropTable(
                name: "Interaction");

            migrationBuilder.DropTable(
                name: "ProfileLooking");

            migrationBuilder.DropTable(
                name: "TicketVote");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
