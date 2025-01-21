using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class mig555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hall_ImgPath",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UsersId",
                table: "Hotels",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_UsersId",
                table: "Hotels",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_UsersId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_UsersId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hall_ImgPath",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Hotels");
        }
    }
}
