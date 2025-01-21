using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class migggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequest_InvitationCard_InvitationStyleInv_Id",
                table: "DesignerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_InvitationCard_Images_Img_Id",
                table: "InvitationCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvitationCard",
                table: "InvitationCard");

            migrationBuilder.RenameTable(
                name: "InvitationCard",
                newName: "InvitationCards");

            migrationBuilder.RenameIndex(
                name: "IX_InvitationCard_Img_Id",
                table: "InvitationCards",
                newName: "IX_InvitationCards_Img_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvitationCards",
                table: "InvitationCards",
                column: "Inv_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequest_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequest",
                column: "InvitationStyleInv_Id",
                principalTable: "InvitationCards",
                principalColumn: "Inv_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationCards_Images_Img_Id",
                table: "InvitationCards",
                column: "Img_Id",
                principalTable: "Images",
                principalColumn: "Img_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequest_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_InvitationCards_Images_Img_Id",
                table: "InvitationCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvitationCards",
                table: "InvitationCards");

            migrationBuilder.RenameTable(
                name: "InvitationCards",
                newName: "InvitationCard");

            migrationBuilder.RenameIndex(
                name: "IX_InvitationCards_Img_Id",
                table: "InvitationCard",
                newName: "IX_InvitationCard_Img_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvitationCard",
                table: "InvitationCard",
                column: "Inv_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequest_InvitationCard_InvitationStyleInv_Id",
                table: "DesignerRequest",
                column: "InvitationStyleInv_Id",
                principalTable: "InvitationCard",
                principalColumn: "Inv_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationCard_Images_Img_Id",
                table: "InvitationCard",
                column: "Img_Id",
                principalTable: "Images",
                principalColumn: "Img_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
