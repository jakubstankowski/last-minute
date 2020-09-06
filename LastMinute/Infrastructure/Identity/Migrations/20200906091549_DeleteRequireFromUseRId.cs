using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class DeleteRequireFromUseRId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayPreferences_AspNetUsers_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.DropIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "HolidayPreferences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                unique: false,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayPreferences_AspNetUsers_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayPreferences_AspNetUsers_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.DropIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "HolidayPreferences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayPreferences_AspNetUsers_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
