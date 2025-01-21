using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Designers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_UsersId",
                table: "Member",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_UsersId",
                table: "Designers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designers_AspNetUsers_UsersId",
                table: "Designers",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_AspNetUsers_UsersId",
                table: "Member",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designers_AspNetUsers_UsersId",
                table: "Designers");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_AspNetUsers_UsersId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_UsersId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Designers_UsersId",
                table: "Designers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Designers");
        }
    }
}
