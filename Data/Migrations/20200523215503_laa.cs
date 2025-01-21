using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class laa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Recommendations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvQuantity",
                table: "Recommendations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "InvQuantity",
                table: "Recommendations");
        }
    }
}
