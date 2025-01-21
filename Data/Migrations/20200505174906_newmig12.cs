using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newmig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "Review",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AvailableDate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    PhotographerPh_Id = table.Column<int>(nullable: true),
                    WeddingHallID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AvailableDate_Photographers_PhotographerPh_Id",
                        column: x => x.PhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableDate_Hotels_WeddingHallID",
                        column: x => x.WeddingHallID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_PhotographerPh_Id",
                table: "AvailableDate",
                column: "PhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_WeddingHallID",
                table: "AvailableDate",
                column: "WeddingHallID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDate");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "Review");
        }
    }
}
