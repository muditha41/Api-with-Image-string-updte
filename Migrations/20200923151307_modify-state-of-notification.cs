using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class modifystateofnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "UserNotification",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "UserNotification",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
