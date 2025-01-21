using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class oo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffer_Photographers_PhotographerPh_Id",
                table: "PriceOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceOffer",
                table: "PriceOffer");

            migrationBuilder.RenameTable(
                name: "PriceOffer",
                newName: "PriceOffers");

            migrationBuilder.RenameIndex(
                name: "IX_PriceOffer_PhotographerPh_Id",
                table: "PriceOffers",
                newName: "IX_PriceOffers_PhotographerPh_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceOffers",
                table: "PriceOffers",
                column: "Of_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffers_Photographers_PhotographerPh_Id",
                table: "PriceOffers",
                column: "PhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffers_Photographers_PhotographerPh_Id",
                table: "PriceOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceOffers",
                table: "PriceOffers");

            migrationBuilder.RenameTable(
                name: "PriceOffers",
                newName: "PriceOffer");

            migrationBuilder.RenameIndex(
                name: "IX_PriceOffers_PhotographerPh_Id",
                table: "PriceOffer",
                newName: "IX_PriceOffer_PhotographerPh_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceOffer",
                table: "PriceOffer",
                column: "Of_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffer_Photographers_PhotographerPh_Id",
                table: "PriceOffer",
                column: "PhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
