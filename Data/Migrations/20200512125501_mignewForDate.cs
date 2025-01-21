using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class mignewForDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestDate",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestDate",
                table: "Hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "Hotels");
        }
    }
}
