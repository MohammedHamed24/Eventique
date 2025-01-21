using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class la : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendedPhotographerPh_Id = table.Column<int>(nullable: true),
                    RecommendedDesignerID = table.Column<int>(nullable: true),
                    RecommendedWeddingHallID = table.Column<int>(nullable: true),
                    RecommendedInvitationInv_Id = table.Column<int>(nullable: true),
                    Save = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recommendations_Designers_RecommendedDesignerID",
                        column: x => x.RecommendedDesignerID,
                        principalTable: "Designers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendations_InvitationCards_RecommendedInvitationInv_Id",
                        column: x => x.RecommendedInvitationInv_Id,
                        principalTable: "InvitationCards",
                        principalColumn: "Inv_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendations_Photographers_RecommendedPhotographerPh_Id",
                        column: x => x.RecommendedPhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendations_Hotels_RecommendedWeddingHallID",
                        column: x => x.RecommendedWeddingHallID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_RecommendedDesignerID",
                table: "Recommendations",
                column: "RecommendedDesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_RecommendedInvitationInv_Id",
                table: "Recommendations",
                column: "RecommendedInvitationInv_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_RecommendedPhotographerPh_Id",
                table: "Recommendations",
                column: "RecommendedPhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_RecommendedWeddingHallID",
                table: "Recommendations",
                column: "RecommendedWeddingHallID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recommendations");
        }
    }
}
