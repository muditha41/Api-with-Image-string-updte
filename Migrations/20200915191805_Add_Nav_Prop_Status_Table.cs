using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Add_Nav_Prop_Status_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus",
                column: "FriendStatusId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus",
                column: "StatusId",
                unique: false);

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
        }
    }
}
