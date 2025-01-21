using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newMigrationssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weddingHallsOffers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false),
                    Dinner = table.Column<int>(nullable: false),
                    otherServices = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    WeddingHallID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weddingHallsOffers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_weddingHallsOffers_Hotels_WeddingHallID",
                        column: x => x.WeddingHallID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_weddingHallsOffers_WeddingHallID",
                table: "weddingHallsOffers",
                column: "WeddingHallID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weddingHallsOffers");
        }
    }
}
