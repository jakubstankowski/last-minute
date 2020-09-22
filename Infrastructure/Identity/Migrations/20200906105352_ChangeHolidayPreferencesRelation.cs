using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class ChangeHolidayPreferencesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }
    }
}
