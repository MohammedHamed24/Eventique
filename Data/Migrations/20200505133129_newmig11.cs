using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventique.Data.Migrations
{
    public partial class newmig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Hotels_HotelID",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Albums_HotelID",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "Ph_Address",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ph_CameraType",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ph_Offers",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ph_PhoneNumber",
                table: "Photographers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Ph_Price",
                table: "Photographers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumAl_Id",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HallType",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Hall_Price",
                table: "Hotels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Offers",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherServices",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Designers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designer_ImgPath",
                table: "Designers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Offers",
                table: "Designers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "Designers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvitationCard",
                columns: table => new
                {
                    Inv_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Id = table.Column<int>(nullable: true),
                    Inv_Price = table.Column<float>(nullable: false),
                    Inv_Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationCard", x => x.Inv_Id);
                    table.ForeignKey(
                        name: "FK_InvitationCard_Images_Img_Id",
                        column: x => x.Img_Id,
                        principalTable: "Images",
                        principalColumn: "Img_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotographerRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestUserID = table.Column<int>(nullable: true),
                    RequestPhotographerPh_Id = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhotographerRequest_Photographers_RequestPhotographerPh_Id",
                        column: x => x.RequestPhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotographerRequest_Members_RequestUserID",
                        column: x => x.RequestUserID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    R_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleverTime = table.Column<int>(nullable: false),
                    TimeManagement = table.Column<int>(nullable: false),
                    Quality = table.Column<int>(nullable: false),
                    ReviewMessage = table.Column<string>(nullable: true),
                    ReviewedMemberID = table.Column<int>(nullable: true),
                    DesignerID = table.Column<int>(nullable: true),
                    PhotographerPh_Id = table.Column<int>(nullable: true),
                    WeddingHallID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.R_Id);
                    table.ForeignKey(
                        name: "FK_Review_Designers_DesignerID",
                        column: x => x.DesignerID,
                        principalTable: "Designers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Photographers_PhotographerPh_Id",
                        column: x => x.PhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Members_ReviewedMemberID",
                        column: x => x.ReviewedMemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Hotels_WeddingHallID",
                        column: x => x.WeddingHallID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeddingHallsRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestUserID = table.Column<int>(nullable: true),
                    RequestHotelID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingHallsRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeddingHallsRequest_Hotels_RequestHotelID",
                        column: x => x.RequestHotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeddingHallsRequest_Members_RequestUserID",
                        column: x => x.RequestUserID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesignerRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestUserID = table.Column<int>(nullable: true),
                    RequestHotelID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    InvitationStyleInv_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignerRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DesignerRequest_InvitationCard_InvitationStyleInv_Id",
                        column: x => x.InvitationStyleInv_Id,
                        principalTable: "InvitationCard",
                        principalColumn: "Inv_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DesignerRequest_Designers_RequestHotelID",
                        column: x => x.RequestHotelID,
                        principalTable: "Designers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DesignerRequest_Members_RequestUserID",
                        column: x => x.RequestUserID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AlbumAl_Id",
                table: "Hotels",
                column: "AlbumAl_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DesignerRequest_InvitationStyleInv_Id",
                table: "DesignerRequest",
                column: "InvitationStyleInv_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DesignerRequest_RequestHotelID",
                table: "DesignerRequest",
                column: "RequestHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_DesignerRequest_RequestUserID",
                table: "DesignerRequest",
                column: "RequestUserID");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationCard_Img_Id",
                table: "InvitationCard",
                column: "Img_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerRequest_RequestPhotographerPh_Id",
                table: "PhotographerRequest",
                column: "RequestPhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerRequest_RequestUserID",
                table: "PhotographerRequest",
                column: "RequestUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_DesignerID",
                table: "Review",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PhotographerPh_Id",
                table: "Review",
                column: "PhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewedMemberID",
                table: "Review",
                column: "ReviewedMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_WeddingHallID",
                table: "Review",
                column: "WeddingHallID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHallsRequest_RequestHotelID",
                table: "WeddingHallsRequest",
                column: "RequestHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHallsRequest_RequestUserID",
                table: "WeddingHallsRequest",
                column: "RequestUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Albums_AlbumAl_Id",
                table: "Hotels",
                column: "AlbumAl_Id",
                principalTable: "Albums",
                principalColumn: "Al_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Albums_AlbumAl_Id",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "DesignerRequest");

            migrationBuilder.DropTable(
                name: "PhotographerRequest");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "WeddingHallsRequest");

            migrationBuilder.DropTable(
                name: "InvitationCard");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AlbumAl_Id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Ph_Address",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Ph_CameraType",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Ph_Offers",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Ph_PhoneNumber",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Ph_Price",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AlbumAl_Id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HallType",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hall_Price",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Offers",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "OtherServices",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Designers");

            migrationBuilder.DropColumn(
                name: "Designer_ImgPath",
                table: "Designers");

            migrationBuilder.DropColumn(
                name: "Offers",
                table: "Designers");

            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "Designers");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Photographers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesignerID = table.Column<int>(type: "int", nullable: true),
                    HotelID = table.Column<int>(type: "int", nullable: true),
                    RequestPhotographerPh_Id = table.Column<int>(type: "int", nullable: true),
                    RequestUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Request_Designers_DesignerID",
                        column: x => x.DesignerID,
                        principalTable: "Designers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Photographers_RequestPhotographerPh_Id",
                        column: x => x.RequestPhotographerPh_Id,
                        principalTable: "Photographers",
                        principalColumn: "Ph_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Members_RequestUserID",
                        column: x => x.RequestUserID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_HotelID",
                table: "Albums",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DesignerID",
                table: "Request",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_HotelID",
                table: "Request",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestPhotographerPh_Id",
                table: "Request",
                column: "RequestPhotographerPh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestUserID",
                table: "Request",
                column: "RequestUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Hotels_HotelID",
                table: "Albums",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
