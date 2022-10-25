using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class adduserID_uniqueUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_Account_Username",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Account_Username",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_Username",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_BookHistories_Username",
                table: "BookHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "BookHistories");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Guest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UserId",
                schema: "dbo",
                table: "Guest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookHistories_UserId",
                table: "BookHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                schema: "dbo",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_Account_UserId",
                table: "BookHistories",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Account_UserId",
                schema: "dbo",
                table: "Guest",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_Account_UserId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Account_UserId",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_UserId",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_BookHistories_UserId",
                table: "BookHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_Username",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "BookHistories",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "dbo",
                table: "Account",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Username",
                schema: "dbo",
                table: "Guest",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_BookHistories_Username",
                table: "BookHistories",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_Account_Username",
                table: "BookHistories",
                column: "Username",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Account_Username",
                schema: "dbo",
                table: "Guest",
                column: "Username",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
