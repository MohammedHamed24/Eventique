using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Photographers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Photographers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_UsersId",
                table: "Photographers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographers_AspNetUsers_UsersId",
                table: "Photographers",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographers_AspNetUsers_UsersId",
                table: "Photographers");

            migrationBuilder.DropIndex(
                name: "IX_Photographers_UsersId",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Photographers");
        }
    }
}
