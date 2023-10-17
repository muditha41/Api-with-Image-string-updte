using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class addstatetonotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "UserNotification",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "UserNotification");
        }
    }
}
