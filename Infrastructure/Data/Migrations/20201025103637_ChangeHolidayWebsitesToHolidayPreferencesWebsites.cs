using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeHolidayWebsitesToHolidayPreferencesWebsites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayWebsites");

            migrationBuilder.CreateTable(
                name: "HolidayPreferencesWebsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayPreferencesId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_HolidayPreferencesWebsites_HolidayPreferencesId",
                table: "HolidayPreferencesWebsites",
                column: "HolidayPreferencesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayPreferencesWebsites");

            migrationBuilder.CreateTable(
                name: "HolidayWebsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayPreferencesId = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayWebsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayWebsites_HolidayPreferences_HolidayPreferencesId",
                        column: x => x.HolidayPreferencesId,
                        principalTable: "HolidayPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayWebsites_HolidayPreferencesId",
                table: "HolidayWebsites",
                column: "HolidayPreferencesId");
        }
    }
}
