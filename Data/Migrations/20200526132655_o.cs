using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceOffer",
                columns: table => new
                {
                    Of_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTitle = table.Column<string>(nullable: true),
                    OfferDetails = table.Column<string>(nullable: true),
                    OffersPrice = table.Column<int>(nullable: false),
                    OfferEndDate = table.Column<string>(nullable: true),
                    OfferImgPath = table.Column<string>(nullable: true),
                    PhotographerPh_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOffer", x => x.Of_ID);
                    table.ForeignKey(
                        name: "FK_PriceOffer_Photographers_PhotographerPh_Id",
                        column: x => x.PhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffer_PhotographerPh_Id",
                table: "PriceOffer",
                column: "PhotographerPh_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceOffer");
        }
    }
}
