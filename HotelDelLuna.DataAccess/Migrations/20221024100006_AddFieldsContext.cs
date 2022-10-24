using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class AddFieldsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistory_Account_Username",
                table: "BookHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistory_Room_RoomNumber",
                table: "BookHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookHistory",
                table: "BookHistory");

            migrationBuilder.RenameTable(
                name: "BookHistory",
                newName: "BookHistories");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistory_Username",
                table: "BookHistories",
                newName: "IX_BookHistories_Username");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistory_RoomNumber",
                table: "BookHistories",
                newName: "IX_BookHistories_RoomNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookHistories",
                table: "BookHistories",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_Account_Username",
                table: "BookHistories",
                column: "Username",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_Room_RoomNumber",
                table: "BookHistories",
                column: "RoomNumber",
                principalSchema: "dbo",
                principalTable: "Room",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_Account_Username",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_Room_RoomNumber",
                table: "BookHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookHistories",
                table: "BookHistories");

            migrationBuilder.RenameTable(
                name: "BookHistories",
                newName: "BookHistory");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_Username",
                table: "BookHistory",
                newName: "IX_BookHistory_Username");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_RoomNumber",
                table: "BookHistory",
                newName: "IX_BookHistory_RoomNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookHistory",
                table: "BookHistory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistory_Account_Username",
                table: "BookHistory",
                column: "Username",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistory_Room_RoomNumber",
                table: "BookHistory",
                column: "RoomNumber",
                principalSchema: "dbo",
                principalTable: "Room",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
