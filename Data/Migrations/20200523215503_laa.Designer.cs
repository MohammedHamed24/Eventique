﻿// <auto-generated />
using System;
using Eventique.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eventique.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200523215503_laa")]
    partial class laa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eventique.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UsersId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Eventique.Models.Album", b =>
                {
                    b.Property<int>("Al_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Al_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DesignerID")
                        .HasColumnType("int");

                    b.Property<int?>("PhotographerPh_Id")
                        .HasColumnType("int");

                    b.HasKey("Al_Id");

                    b.HasIndex("DesignerID");

                    b.HasIndex("PhotographerPh_Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Eventique.Models.AvailableDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhotographerPh_Id")
                        .HasColumnType("int");

                    b.Property<int?>("WeddingHallID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PhotographerPh_Id");

                    b.HasIndex("WeddingHallID");

                    b.ToTable("AvailableDate");
                });

            modelBuilder.Entity("Eventique.Models.Designer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designer_ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Offers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UsersId");

                    b.ToTable("Designers");
                });

            modelBuilder.Entity("Eventique.Models.DesignerRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvitationStyleInv_Id")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RequestHotelID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("InvitationStyleInv_Id");

                    b.HasIndex("RequestHotelID");

                    b.HasIndex("RequestUserID");

                    b.ToTable("DesignerRequests");
                });

            modelBuilder.Entity("Eventique.Models.Image", b =>
                {
                    b.Property<int>("Img_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumAl_Id")
                        .HasColumnType("int");

                    b.Property<string>("Img_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img_Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Img_Id");

                    b.HasIndex("AlbumAl_Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Eventique.Models.InvitationCard", b =>
                {
                    b.Property<int>("Inv_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DesignerID")
                        .HasColumnType("int");

                    b.Property<int?>("Img_Id")
                        .HasColumnType("int");

                    b.Property<float>("Inv_Price")
                        .HasColumnType("real");

                    b.Property<string>("Inv_Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Inv_Id");

                    b.HasIndex("DesignerID");

                    b.HasIndex("Img_Id");

                    b.ToTable("InvitationCards");
                });

            modelBuilder.Entity("Eventique.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UsersId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Eventique.Models.Photographer", b =>
                {
                    b.Property<int>("Ph_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph_CameraType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph_Offers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph_PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Ph_Price")
                        .HasColumnType("real");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<string>("TestDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Ph_Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("Eventique.Models.PhotographerRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestPhotographerPh_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RequestUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RequestPhotographerPh_Id");

                    b.HasIndex("RequestUserID");

                    b.ToTable("PhotographerRequests");
                });

            modelBuilder.Entity("Eventique.Models.Recommendation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedDesignerID")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedInvitationInv_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedPhotographerPh_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedWeddingHallID")
                        .HasColumnType("int");

                    b.Property<float>("Save")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("RecommendedDesignerID");

                    b.HasIndex("RecommendedInvitationInv_Id");

                    b.HasIndex("RecommendedPhotographerPh_Id");

                    b.HasIndex("RecommendedWeddingHallID");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("Eventique.Models.Review", b =>
                {
                    b.Property<int>("R_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeleverTime")
                        .HasColumnType("int");

                    b.Property<int?>("DesignerID")
                        .HasColumnType("int");

                    b.Property<int?>("PhotographerPh_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewedMemberID")
                        .HasColumnType("int");

                    b.Property<int>("TimeManagement")
                        .HasColumnType("int");

                    b.Property<int?>("WeddingHallID")
                        .HasColumnType("int");

                    b.HasKey("R_Id");

                    b.HasIndex("DesignerID");

                    b.HasIndex("PhotographerPh_Id");

                    b.HasIndex("ReviewedMemberID");

                    b.HasIndex("WeddingHallID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Eventique.Models.WeddingHall", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AlbumAl_Id")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("HallType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hall_ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Hall_Price")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Offers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherServices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("TestDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("AlbumAl_Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Eventique.Models.WeddingHallsRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestHotelID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RequestHotelID");

                    b.HasIndex("RequestUserID");

                    b.ToTable("WeddingHallsRequests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Eventique.Models.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Eventique.Models.Album", b =>
                {
                    b.HasOne("Eventique.Models.Designer", null)
                        .WithMany("ListAlbums")
                        .HasForeignKey("DesignerID");

                    b.HasOne("Eventique.Models.Photographer", null)
                        .WithMany("ListAlbum")
                        .HasForeignKey("PhotographerPh_Id");
                });

            modelBuilder.Entity("Eventique.Models.AvailableDate", b =>
                {
                    b.HasOne("Eventique.Models.Photographer", null)
                        .WithMany("Ph_AvailableDate")
                        .HasForeignKey("PhotographerPh_Id");

                    b.HasOne("Eventique.Models.WeddingHall", null)
                        .WithMany("AvailbleDates")
                        .HasForeignKey("WeddingHallID");
                });

            modelBuilder.Entity("Eventique.Models.Designer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Eventique.Models.DesignerRequest", b =>
                {
                    b.HasOne("Eventique.Models.InvitationCard", "InvitationStyle")
                        .WithMany()
                        .HasForeignKey("InvitationStyleInv_Id");

                    b.HasOne("Eventique.Models.Designer", "RequestHotel")
                        .WithMany("DesignerRequest")
                        .HasForeignKey("RequestHotelID");

                    b.HasOne("Eventique.Models.Member", "RequestUser")
                        .WithMany()
                        .HasForeignKey("RequestUserID");
                });

            modelBuilder.Entity("Eventique.Models.Image", b =>
                {
                    b.HasOne("Eventique.Models.Album", null)
                        .WithMany("MyProperty")
                        .HasForeignKey("AlbumAl_Id");
                });

            modelBuilder.Entity("Eventique.Models.InvitationCard", b =>
                {
                    b.HasOne("Eventique.Models.Designer", null)
                        .WithMany("Invitations")
                        .HasForeignKey("DesignerID");

                    b.HasOne("Eventique.Models.Image", "Img")
                        .WithMany()
                        .HasForeignKey("Img_Id");
                });

            modelBuilder.Entity("Eventique.Models.Member", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Eventique.Models.Photographer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Eventique.Models.PhotographerRequest", b =>
                {
                    b.HasOne("Eventique.Models.Photographer", "RequestPhotographer")
                        .WithMany("Ph_Requests")
                        .HasForeignKey("RequestPhotographerPh_Id");

                    b.HasOne("Eventique.Models.Member", "RequestUser")
                        .WithMany()
                        .HasForeignKey("RequestUserID");
                });

            modelBuilder.Entity("Eventique.Models.Recommendation", b =>
                {
                    b.HasOne("Eventique.Models.Designer", "RecommendedDesigner")
                        .WithMany()
                        .HasForeignKey("RecommendedDesignerID");

                    b.HasOne("Eventique.Models.InvitationCard", "RecommendedInvitation")
                        .WithMany()
                        .HasForeignKey("RecommendedInvitationInv_Id");

                    b.HasOne("Eventique.Models.Photographer", "RecommendedPhotographer")
                        .WithMany()
                        .HasForeignKey("RecommendedPhotographerPh_Id");

                    b.HasOne("Eventique.Models.WeddingHall", "RecommendedWeddingHall")
                        .WithMany()
                        .HasForeignKey("RecommendedWeddingHallID");
                });

            modelBuilder.Entity("Eventique.Models.Review", b =>
                {
                    b.HasOne("Eventique.Models.Designer", null)
                        .WithMany("Reviews")
                        .HasForeignKey("DesignerID");

                    b.HasOne("Eventique.Models.Photographer", null)
                        .WithMany("Ph_Reviews")
                        .HasForeignKey("PhotographerPh_Id");

                    b.HasOne("Eventique.Models.Member", "ReviewedMember")
                        .WithMany()
                        .HasForeignKey("ReviewedMemberID");

                    b.HasOne("Eventique.Models.WeddingHall", null)
                        .WithMany("HallsReview")
                        .HasForeignKey("WeddingHallID");
                });

            modelBuilder.Entity("Eventique.Models.WeddingHall", b =>
                {
                    b.HasOne("Eventique.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumAl_Id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Eventique.Models.WeddingHallsRequest", b =>
                {
                    b.HasOne("Eventique.Models.WeddingHall", "RequestHotel")
                        .WithMany("HotelRequest")
                        .HasForeignKey("RequestHotelID");

                    b.HasOne("Eventique.Models.Member", "RequestUser")
                        .WithMany()
                        .HasForeignKey("RequestUserID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
