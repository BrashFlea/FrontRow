﻿// <auto-generated />
using FrontRowCMS2.Data;
using FrontRowCMS2.Models.Secondary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FrontRowCMS2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180326020041_add-migration InitialCreate")]
    partial class addmigrationInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrontRowCMS2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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

            modelBuilder.Entity("FrontRowCMS2.Models.Footer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("FacebookLink");

                    b.Property<string>("HomeImage");

                    b.Property<string>("InstagramLink");

                    b.Property<string>("MailingAddressLine1");

                    b.Property<string>("MailingAddressLine2");

                    b.Property<string>("ShelterAddressLine1");

                    b.Property<string>("ShelterAddressLine2");

                    b.Property<string>("TumblrLink");

                    b.Property<string>("TwitterLink");

                    b.HasKey("ID");

                    b.ToTable("Footer");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.Calendar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.CalendarEvents", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Day");

                    b.Property<string>("Info");

                    b.Property<int>("MonthID");

                    b.Property<string>("What");

                    b.Property<string>("When");

                    b.Property<string>("Where");

                    b.HasKey("ID");

                    b.HasIndex("MonthID");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.CalendarMonths", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CalendarID");

                    b.Property<int>("CalenderID");

                    b.Property<string>("Month");

                    b.Property<string>("Year");

                    b.HasKey("ID");

                    b.HasIndex("CalendarID");

                    b.ToTable("CalendarMonths");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.History", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption1");

                    b.Property<string>("Caption2");

                    b.Property<string>("Caption3");

                    b.Property<string>("Image1");

                    b.Property<string>("Image2");

                    b.Property<string>("Image3");

                    b.Property<string>("TextArea1");

                    b.Property<string>("TextArea2");

                    b.HasKey("ID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.Needs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TextArea1");

                    b.Property<string>("TextArea2");

                    b.Property<string>("TextArea3");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Needs");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.Outreach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("TextArea1");

                    b.Property<string>("TextArea2");

                    b.Property<string>("TextArea3");

                    b.HasKey("ID");

                    b.ToTable("Outreach");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.OutreachTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<int>("OutreachID");

                    b.HasKey("ID");

                    b.HasIndex("OutreachID");

                    b.ToTable("OutreachTable");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Title1");

                    b.Property<string>("Title2");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.CalendarEvents", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.Secondary.CalendarMonths", "Month")
                        .WithMany("Event")
                        .HasForeignKey("MonthID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.CalendarMonths", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.Secondary.Calendar", "Calendar")
                        .WithMany("Month")
                        .HasForeignKey("CalendarID");
                });

            modelBuilder.Entity("FrontRowCMS2.Models.Secondary.OutreachTable", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.Secondary.Outreach", "Outreach")
                        .WithMany("OutreachTable")
                        .HasForeignKey("OutreachID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FrontRowCMS2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FrontRowCMS2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
