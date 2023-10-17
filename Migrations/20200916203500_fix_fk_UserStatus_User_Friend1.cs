using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class fix_fk_UserStatus_User_Friend1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserStatusId",
                table: "UserFriends",
                column: "UserStatusId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_UserStatus_UserStatusId",
                table: "UserFriends",
                column: "UserStatusId",
                principalTable: "UserStatus",
                principalColumn: "UserStatusId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_UserStatus_UserStatusId",
                table: "UserFriends");

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

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_UserStatusId",
                table: "UserFriends");
        }
    }
}
