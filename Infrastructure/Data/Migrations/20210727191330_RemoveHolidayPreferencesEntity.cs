using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RemoveHolidayPreferencesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayPreferencesWebsites");

            migrationBuilder.DropTable(
                name: "HolidayPreferences");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HolidayPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaxPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayPreferences_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HolidayPreferencesWebsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayPreferencesId = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPreferencesWebsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayPreferencesWebsites_HolidayPreferences_HolidayPreferencesId",
                        column: x => x.HolidayPreferencesId,
                        principalTable: "HolidayPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferences_AppUserId",
                table: "HolidayPreferences",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferencesWebsites_HolidayPreferencesId",
                table: "HolidayPreferencesWebsites",
                column: "HolidayPreferencesId");
        }
    }
}
