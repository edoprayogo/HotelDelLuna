using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class EditGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Guest_IdNumber",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Guest",
                type: "CHAR(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BirthCity",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "FamilyCount",
                table: "BookHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_IdNumber",
                schema: "dbo",
                table: "Guest",
                column: "IdNumber",
                unique: true,
                filter: "[IdNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Username",
                schema: "dbo",
                table: "Guest",
                column: "Username");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Account_Username",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_IdNumber",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_Username",
                schema: "dbo",
                table: "Guest");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Guest",
                type: "CHAR(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthCity",
                schema: "dbo",
                table: "Guest",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FamilyCount",
                table: "BookHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_IdNumber",
                schema: "dbo",
                table: "Guest",
                column: "IdNumber",
                unique: true);
        }
    }
}
