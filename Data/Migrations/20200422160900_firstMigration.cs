using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Ph_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ph_Name = table.Column<string>(nullable: true),
                    Rate = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Ph_Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Al_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Al_Title = table.Column<string>(nullable: true),
                    PhotographerPh_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Al_Id);
                    table.ForeignKey(
                        name: "FK_Albums_Photographers_PhotographerPh_Id",
                        column: x => x.PhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Img_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Name = table.Column<string>(nullable: true),
                    Img_Path = table.Column<string>(nullable: true),
                    AlbumAl_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Img_Id);
                    table.ForeignKey(
                        name: "FK_Images_Albums_AlbumAl_Id",
                        column: x => x.AlbumAl_Id,
                        principalTable: "Albums",
                        principalColumn: "Al_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_PhotographerPh_Id",
                table: "Albums",
                column: "PhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AlbumAl_Id",
                table: "Images",
                column: "AlbumAl_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Photographers");
        }
    }
}
