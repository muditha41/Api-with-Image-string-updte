using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class fix_fk_UserStatus_User_Friend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStatus_Status_FriendStatusId",
                table: "UserStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStatus_Status_StatusId",
                table: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus",
                column: "FriendStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStatus_Status_FriendStatusId",
                table: "UserStatus",
                column: "FriendStatusId",
                principalTable: "Status",
                principalColumn: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStatus_Status_StatusId",
                table: "UserStatus",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }
    }
}
