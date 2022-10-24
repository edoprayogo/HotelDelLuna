using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDelLuna.DataAccess.Migrations
{
    public partial class AddLoginFail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginFailCount",
                schema: "dbo",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginFailCount",
                schema: "dbo",
                table: "Account");
        }
    }
}
