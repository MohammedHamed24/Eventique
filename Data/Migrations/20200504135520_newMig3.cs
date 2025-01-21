using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_AspNetUsers_UsersId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Member_RequestUserID",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Member_UsersId",
                table: "Members",
                newName: "IX_Members_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_UsersId",
                table: "Members",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Members_RequestUserID",
                table: "Request",
                column: "RequestUserID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_UsersId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Members_RequestUserID",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UsersId",
                table: "Member",
                newName: "IX_Member_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_AspNetUsers_UsersId",
                table: "Member",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Member_RequestUserID",
                table: "Request",
                column: "RequestUserID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
