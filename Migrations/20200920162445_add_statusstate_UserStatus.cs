using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class add_statusstate_UserStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusState",
                table: "UserStatus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusState",
                table: "UserStatus");
        }
    }
}
