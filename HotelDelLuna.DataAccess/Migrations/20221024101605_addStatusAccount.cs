using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class addStatusAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Account",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Account");
        }
    }
}
