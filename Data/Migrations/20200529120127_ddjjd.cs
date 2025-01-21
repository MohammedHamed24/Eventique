using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class ddjjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hallsOffersID",
                table: "Recommendations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phOfferOf_ID",
                table: "Recommendations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_hallsOffersID",
                table: "Recommendations",
                column: "hallsOffersID");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_phOfferOf_ID",
                table: "Recommendations",
                column: "phOfferOf_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_weddingHallsOffers_hallsOffersID",
                table: "Recommendations",
                column: "hallsOffersID",
                principalTable: "weddingHallsOffers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_PriceOffers_phOfferOf_ID",
                table: "Recommendations",
                column: "phOfferOf_ID",
                principalTable: "PriceOffers",
                principalColumn: "Of_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_weddingHallsOffers_hallsOffersID",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_PriceOffers_phOfferOf_ID",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_hallsOffersID",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_phOfferOf_ID",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "hallsOffersID",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "phOfferOf_ID",
                table: "Recommendations");
        }
    }
}
