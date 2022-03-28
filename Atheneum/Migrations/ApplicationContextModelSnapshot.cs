﻿// <auto-generated />
using System;
using Atheneum.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atheneum.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atheneum.Entity.CashFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cash")
                        .HasPrecision(18, 10)
                        .HasColumnType("decimal(18,10)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserIdPassed")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserIdReceived")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("CashFlow");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.ChatPrivate", b =>
                {
                    b.Property<long>("Tick")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Tick", "SenderId", "ReceiverId");

                    b.HasIndex("Tick");

                    b.ToTable("ChatPrivate");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.ChatRoom", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Room");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Epic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("Assignee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid?>("Reporter")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Epic");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.HourlyPay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("Date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserIdCreated")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("HourlyPay");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("Assignee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("Date");

                    b.Property<int?>("EpicLink")
                        .HasColumnType("int");

                    b.Property<decimal?>("EstimatedTime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("Reporter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Size")
                        .HasColumnType("tinyint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cash")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 10)
                        .HasColumnType("decimal(18,10)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Atheneum.Entity.Identity.TimeTracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EpicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EpicId");

                    b.HasIndex("IssueId");

                    b.HasIndex("UserId");

                    b.ToTable("TimeTracking");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.UserInRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserInRole");
                });

            modelBuilder.Entity("Atheneum.Entity.Sprint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("Date");

                    b.Property<byte>("IsEnded")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("FinishDate")
                        .IsUnique();

                    b.HasIndex("StartDate")
                        .IsUnique();

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("Atheneum.Entity.SprintIssues", b =>
                {
                    b.Property<long>("SprintId")
                        .HasColumnType("bigint");

                    b.Property<long>("IssueId")
                        .HasColumnType("bigint");

                    b.HasKey("SprintId", "IssueId");

                    b.HasIndex("IssueId");

                    b.ToTable("SprintIssues");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Profile", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Atheneum.Entity.Identity.Profile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.TimeTracking", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.Epic", "Epic")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("EpicId");

                    b.HasOne("Atheneum.Entity.Identity.Issue", "Issue")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("IssueId");

                    b.HasOne("Atheneum.Entity.Identity.User", "User")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Epic");

                    b.Navigation("Issue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.UserInRole", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.SprintIssues", b =>
                {
                    b.HasOne("Atheneum.Entity.Identity.Issue", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atheneum.Entity.Sprint", "Sprint")
                        .WithMany()
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Epic", b =>
                {
                    b.Navigation("TimeTrackings");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.Issue", b =>
                {
                    b.Navigation("TimeTrackings");
                });

            modelBuilder.Entity("Atheneum.Entity.Identity.User", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("TimeTrackings");

                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
