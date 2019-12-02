﻿// <auto-generated />
using System;
using Atheneum.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atheneum.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191202061444_ChatRoom")]
    partial class ChatRoom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atheneum.Entity.Identity.ChatRoom", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Login");

                    b.Property<string>("Msg");

                    b.Property<int>("Room");

                    b.Property<string>("To");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.HasIndex("Room");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Profile", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("PasswordHash");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.UserInRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserInRole");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Profile", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Atheneum.Entity.Identity.Profile", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.UserInRole", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}