using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RefactorDaysNumberToDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysNumber",
                table: "HolidayOffers");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "HolidayOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "HolidayOffers");

            migrationBuilder.AddColumn<string>(
                name: "DaysNumber",
                table: "HolidayOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
