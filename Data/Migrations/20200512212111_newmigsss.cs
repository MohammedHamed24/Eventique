using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newmigsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequest_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequest_Designers_RequestHotelID",
                table: "DesignerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequest_Members_RequestUserID",
                table: "DesignerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHallsRequest_Hotels_RequestHotelID",
                table: "WeddingHallsRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHallsRequest_Members_RequestUserID",
                table: "WeddingHallsRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingHallsRequest",
                table: "WeddingHallsRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DesignerRequest",
                table: "DesignerRequest");

            migrationBuilder.RenameTable(
                name: "WeddingHallsRequest",
                newName: "WeddingHallsRequests");

            migrationBuilder.RenameTable(
                name: "DesignerRequest",
                newName: "DesignerRequests");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingHallsRequest_RequestUserID",
                table: "WeddingHallsRequests",
                newName: "IX_WeddingHallsRequests_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingHallsRequest_RequestHotelID",
                table: "WeddingHallsRequests",
                newName: "IX_WeddingHallsRequests_RequestHotelID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequest_RequestUserID",
                table: "DesignerRequests",
                newName: "IX_DesignerRequests_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequest_RequestHotelID",
                table: "DesignerRequests",
                newName: "IX_DesignerRequests_RequestHotelID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequest_InvitationStyleInv_Id",
                table: "DesignerRequests",
                newName: "IX_DesignerRequests_InvitationStyleInv_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingHallsRequests",
                table: "WeddingHallsRequests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DesignerRequests",
                table: "DesignerRequests",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequests_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequests",
                column: "InvitationStyleInv_Id",
                principalTable: "InvitationCards",
                principalColumn: "Inv_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequests_Designers_RequestHotelID",
                table: "DesignerRequests",
                column: "RequestHotelID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequests_Members_RequestUserID",
                table: "DesignerRequests",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHallsRequests_Hotels_RequestHotelID",
                table: "WeddingHallsRequests",
                column: "RequestHotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHallsRequests_Members_RequestUserID",
                table: "WeddingHallsRequests",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequests_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequests_Designers_RequestHotelID",
                table: "DesignerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignerRequests_Members_RequestUserID",
                table: "DesignerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHallsRequests_Hotels_RequestHotelID",
                table: "WeddingHallsRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingHallsRequests_Members_RequestUserID",
                table: "WeddingHallsRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingHallsRequests",
                table: "WeddingHallsRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DesignerRequests",
                table: "DesignerRequests");

            migrationBuilder.RenameTable(
                name: "WeddingHallsRequests",
                newName: "WeddingHallsRequest");

            migrationBuilder.RenameTable(
                name: "DesignerRequests",
                newName: "DesignerRequest");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingHallsRequests_RequestUserID",
                table: "WeddingHallsRequest",
                newName: "IX_WeddingHallsRequest_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingHallsRequests_RequestHotelID",
                table: "WeddingHallsRequest",
                newName: "IX_WeddingHallsRequest_RequestHotelID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequests_RequestUserID",
                table: "DesignerRequest",
                newName: "IX_DesignerRequest_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequests_RequestHotelID",
                table: "DesignerRequest",
                newName: "IX_DesignerRequest_RequestHotelID");

            migrationBuilder.RenameIndex(
                name: "IX_DesignerRequests_InvitationStyleInv_Id",
                table: "DesignerRequest",
                newName: "IX_DesignerRequest_InvitationStyleInv_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingHallsRequest",
                table: "WeddingHallsRequest",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DesignerRequest",
                table: "DesignerRequest",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequest_InvitationCards_InvitationStyleInv_Id",
                table: "DesignerRequest",
                column: "InvitationStyleInv_Id",
                principalTable: "InvitationCards",
                principalColumn: "Inv_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequest_Designers_RequestHotelID",
                table: "DesignerRequest",
                column: "RequestHotelID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignerRequest_Members_RequestUserID",
                table: "DesignerRequest",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHallsRequest_Hotels_RequestHotelID",
                table: "WeddingHallsRequest",
                column: "RequestHotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingHallsRequest_Members_RequestUserID",
                table: "WeddingHallsRequest",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
