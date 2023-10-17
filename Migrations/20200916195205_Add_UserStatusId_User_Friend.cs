using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Add_UserStatusId_User_Friend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "UserFriends",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "UserFriends");
        }
    }
}
