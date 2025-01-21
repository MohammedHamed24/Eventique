using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class ooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceOfferOf_ID",
                table: "PhotographerRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerRequests_PriceOfferOf_ID",
                table: "PhotographerRequests",
                column: "PriceOfferOf_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotographerRequests_PriceOffers_PriceOfferOf_ID",
                table: "PhotographerRequests",
                column: "PriceOfferOf_ID",
                principalTable: "PriceOffers",
                principalColumn: "Of_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotographerRequests_PriceOffers_PriceOfferOf_ID",
                table: "PhotographerRequests");

            migrationBuilder.DropIndex(
                name: "IX_PhotographerRequests_PriceOfferOf_ID",
                table: "PhotographerRequests");

            migrationBuilder.DropColumn(
                name: "PriceOfferOf_ID",
                table: "PhotographerRequests");
        }
    }
}
