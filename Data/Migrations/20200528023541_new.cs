using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferID",
                table: "WeddingHallsRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHallsRequests_OfferID",
                table: "WeddingHallsRequests",
                column: "OfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHallsRequests_weddingHallsOffers_OfferID",
                table: "WeddingHallsRequests",
                column: "OfferID",
                principalTable: "weddingHallsOffers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHallsRequests_weddingHallsOffers_OfferID",
                table: "WeddingHallsRequests");

            migrationBuilder.DropIndex(
                name: "IX_WeddingHallsRequests_OfferID",
                table: "WeddingHallsRequests");

            migrationBuilder.DropColumn(
                name: "OfferID",
                table: "WeddingHallsRequests");
        }
    }
}
