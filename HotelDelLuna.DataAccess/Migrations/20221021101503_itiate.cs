using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class itiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Username = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                schema: "dbo",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    BirthCity = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    IdNumber = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "dbo",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "BookHistory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RoomNumber = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    FamilyCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookHistory", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BookHistory_Account_Username",
                        column: x => x.Username,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookHistory_Room_RoomNumber",
                        column: x => x.RoomNumber,
                        principalSchema: "dbo",
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookHistory_RoomNumber",
                table: "BookHistory",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BookHistory_Username",
                table: "BookHistory",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_IdNumber",
                schema: "dbo",
                table: "Guest",
                column: "IdNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookHistory");

            migrationBuilder.DropTable(
                name: "Guest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "dbo");
        }
    }
}
