using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class eightOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Albums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_DesignerID",
                table: "Request",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_HotelID",
                table: "Request",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_DesignerID",
                table: "Albums",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_HotelID",
                table: "Albums",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Designers_DesignerID",
                table: "Albums",
                column: "DesignerID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Hotels_HotelID",
                table: "Albums",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Designers_DesignerID",
                table: "Request",
                column: "DesignerID",
                principalTable: "Designers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Hotels_HotelID",
                table: "Request",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Designers_DesignerID",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Hotels_HotelID",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Designers_DesignerID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Hotels_HotelID",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Request_DesignerID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_HotelID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Albums_DesignerID",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_HotelID",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Albums");
        }
    }
}
