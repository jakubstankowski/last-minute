﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RemoveWebsitestList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayPreferencesWebsitesList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HolidayPreferencesWebsitesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayPreferencesId = table.Column<int>(type: "int", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPreferencesWebsitesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayPreferencesWebsitesList_HolidayPreferences_HolidayPreferencesId",
                        column: x => x.HolidayPreferencesId,
                        principalTable: "HolidayPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPreferencesWebsitesList_HolidayPreferencesId",
                table: "HolidayPreferencesWebsitesList",
                column: "HolidayPreferencesId");
        }
    }
}
