using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class make_StatusId_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "UserStatus",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FriendStatusId",
                table: "UserStatus",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus",
                column: "FriendStatusId",
                unique: false,
                filter: "[FriendStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus",
                column: "StatusId",
                unique: false,
                filter: "[StatusId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserStatus_FriendStatusId",
                table: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserStatus_StatusId",
                table: "UserStatus");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "UserStatus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FriendStatusId",
                table: "UserStatus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
        }
    }
}
