using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class NewMigrationsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotographerRequest_Photographers_RequestPhotographerPh_Id",
                table: "PhotographerRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotographerRequest_Members_RequestUserID",
                table: "PhotographerRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotographerRequest",
                table: "PhotographerRequest");

            migrationBuilder.RenameTable(
                name: "PhotographerRequest",
                newName: "PhotographerRequests");

            migrationBuilder.RenameIndex(
                name: "IX_PhotographerRequest_RequestUserID",
                table: "PhotographerRequests",
                newName: "IX_PhotographerRequests_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_PhotographerRequest_RequestPhotographerPh_Id",
                table: "PhotographerRequests",
                newName: "IX_PhotographerRequests_RequestPhotographerPh_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotographerRequests",
                table: "PhotographerRequests",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotographerRequests_Photographers_RequestPhotographerPh_Id",
                table: "PhotographerRequests",
                column: "RequestPhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotographerRequests_Members_RequestUserID",
                table: "PhotographerRequests",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotographerRequests_Photographers_RequestPhotographerPh_Id",
                table: "PhotographerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotographerRequests_Members_RequestUserID",
                table: "PhotographerRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotographerRequests",
                table: "PhotographerRequests");

            migrationBuilder.RenameTable(
                name: "PhotographerRequests",
                newName: "PhotographerRequest");

            migrationBuilder.RenameIndex(
                name: "IX_PhotographerRequests_RequestUserID",
                table: "PhotographerRequest",
                newName: "IX_PhotographerRequest_RequestUserID");

            migrationBuilder.RenameIndex(
                name: "IX_PhotographerRequests_RequestPhotographerPh_Id",
                table: "PhotographerRequest",
                newName: "IX_PhotographerRequest_RequestPhotographerPh_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotographerRequest",
                table: "PhotographerRequest",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotographerRequest_Photographers_RequestPhotographerPh_Id",
                table: "PhotographerRequest",
                column: "RequestPhotographerPh_Id",
                principalTable: "Photographers",
                principalColumn: "Ph_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotographerRequest_Members_RequestUserID",
                table: "PhotographerRequest",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
