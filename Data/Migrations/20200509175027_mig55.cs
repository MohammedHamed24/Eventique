using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class mig55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Designers_DesignerID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Photographers_PhotographerPh_Id",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Members_ReviewedMemberID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Hotels_WeddingHallID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_WeddingHallID",
                table: "Reviews",
                newName: "IX_Reviews_WeddingHallID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewedMemberID",
                table: "Reviews",
                newName: "IX_Reviews_ReviewedMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_PhotographerPh_Id",
                table: "Reviews",
                newName: "IX_Reviews_PhotographerPh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Review_DesignerID",
                table: "Reviews",
                newName: "IX_Reviews_DesignerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "R_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Designers_DesignerID",
                table: "Reviews",
                column: "DesignerID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Photographers_PhotographerPh_Id",
                table: "Reviews",
                column: "PhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Members_ReviewedMemberID",
                table: "Reviews",
                column: "ReviewedMemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotels_WeddingHallID",
                table: "Reviews",
                column: "WeddingHallID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Designers_DesignerID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Photographers_PhotographerPh_Id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Members_ReviewedMemberID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotels_WeddingHallID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_WeddingHallID",
                table: "Review",
                newName: "IX_Review_WeddingHallID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewedMemberID",
                table: "Review",
                newName: "IX_Review_ReviewedMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PhotographerPh_Id",
                table: "Review",
                newName: "IX_Review_PhotographerPh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_DesignerID",
                table: "Review",
                newName: "IX_Review_DesignerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "R_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Designers_DesignerID",
                table: "Review",
                column: "DesignerID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Photographers_PhotographerPh_Id",
                table: "Review",
                column: "PhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Members_ReviewedMemberID",
                table: "Review",
                column: "ReviewedMemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Hotels_WeddingHallID",
                table: "Review",
                column: "WeddingHallID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
