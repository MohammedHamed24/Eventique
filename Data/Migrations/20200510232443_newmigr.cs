using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "InvitationCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvitationCards_DesignerID",
                table: "InvitationCards",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationCards_Designers_DesignerID",
                table: "InvitationCards",
                column: "DesignerID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvitationCards_Designers_DesignerID",
                table: "InvitationCards");

            migrationBuilder.DropIndex(
                name: "IX_InvitationCards_DesignerID",
                table: "InvitationCards");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "InvitationCards");
        }
    }
}
