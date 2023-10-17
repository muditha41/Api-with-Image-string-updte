using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Remove_UserStatusId_User_Friend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "UserFriends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "UserFriends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
