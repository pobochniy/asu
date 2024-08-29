﻿// <auto-generated />
using System;
using Atheneum.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Atheneum.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240825105326_HourlyPayForeignUser")]
    partial class HourlyPayForeignUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Atheneum.Entity.Avatar", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("ImgData")
                        .HasColumnType("longblob");

                    b.HasKey("UserId");

                    b.ToTable("Avatar");
                });

            modelBuilder.Entity("Atheneum.Entity.CashFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Cash")
                        .HasPrecision(18, 10)
                        .HasColumnType("decimal(18,10)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserIdPassed")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserIdReceived")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CashFlow");
                });

            modelBuilder.Entity("Atheneum.Entity.ChatPrivate", b =>
                {
                    b.Property<long>("Tick")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.Property<string>("Msg")
                        .HasColumnType("longtext");

                    b.Property<string>("Privat")
                        .HasColumnType("longtext");

                    b.Property<string>("To")
                        .HasColumnType("longtext");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Tick", "SenderId", "ReceiverId");

                    b.HasIndex("Tick");

                    b.ToTable("ChatPrivate");
                });

            modelBuilder.Entity("Atheneum.Entity.ChatRoom", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.Property<string>("Msg")
                        .HasColumnType("longtext");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("longtext");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("Room");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("Atheneum.Entity.CrystalPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("CrystalProfitPeriodId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CrystalProfitPeriodId");

                    b.ToTable("CrystalPayments");
                });

            modelBuilder.Entity("Atheneum.Entity.CrystalProfitPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("From")
                        .HasColumnType("date");

                    b.Property<DateOnly>("To")
                        .HasColumnType("date");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CrystalProfitPeriods");
                });

            modelBuilder.Entity("Atheneum.Entity.Epic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid?>("Assignee")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid?>("Reporter")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Epic");
                });

            modelBuilder.Entity("Atheneum.Entity.HourlyPay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("StartedDate")
                        .HasColumnType("Date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserIdCreated")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HourlyPay");
                });

            modelBuilder.Entity("Atheneum.Entity.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid?>("Assignee")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("Date");

                    b.Property<int?>("EpicLink")
                        .HasColumnType("int");

                    b.Property<decimal?>("EstimatedTime")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("Reporter")
                        .HasColumnType("char(36)");

                    b.Property<byte>("Size")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("Atheneum.Entity.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Cash")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 10)
                        .HasColumnType("decimal(18,10)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Atheneum.Entity.Sprint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("Date");

                    b.Property<byte>("IsEnded")
                        .HasColumnType("tinyint unsigned");

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

            modelBuilder.Entity("Atheneum.Entity.TimeTracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("EpicId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("From")
                        .HasColumnType("time(6)");

                    b.Property<long?>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<TimeOnly>("To")
                        .HasColumnType("time(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EpicId");

                    b.HasIndex("IssueId");

                    b.HasIndex("UserId");

                    b.ToTable("TimeTracking");
                });

            modelBuilder.Entity("Atheneum.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Atheneum.Entity.UserInRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserInRole");
                });

            modelBuilder.Entity("Atheneum.Entity.Avatar", b =>
                {
                    b.HasOne("Atheneum.Entity.User", "User")
                        .WithOne("Avatar")
                        .HasForeignKey("Atheneum.Entity.Avatar", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.CrystalPayment", b =>
                {
                    b.HasOne("Atheneum.Entity.CrystalProfitPeriod", "CrystalProfitPeriod")
                        .WithMany("Payments")
                        .HasForeignKey("CrystalProfitPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrystalProfitPeriod");
                });

            modelBuilder.Entity("Atheneum.Entity.HourlyPay", b =>
                {
                    b.HasOne("Atheneum.Entity.User", "User")
                        .WithMany("HourlyPays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.Profile", b =>
                {
                    b.HasOne("Atheneum.Entity.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Atheneum.Entity.Profile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.SprintIssues", b =>
                {
                    b.HasOne("Atheneum.Entity.Issue", "Issue")
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

            modelBuilder.Entity("Atheneum.Entity.TimeTracking", b =>
                {
                    b.HasOne("Atheneum.Entity.Epic", "Epic")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("EpicId");

                    b.HasOne("Atheneum.Entity.Issue", "Issue")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("IssueId");

                    b.HasOne("Atheneum.Entity.User", "User")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Epic");

                    b.Navigation("Issue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.UserInRole", b =>
                {
                    b.HasOne("Atheneum.Entity.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Atheneum.Entity.CrystalProfitPeriod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Atheneum.Entity.Epic", b =>
                {
                    b.Navigation("TimeTrackings");
                });

            modelBuilder.Entity("Atheneum.Entity.Issue", b =>
                {
                    b.Navigation("TimeTrackings");
                });

            modelBuilder.Entity("Atheneum.Entity.User", b =>
                {
                    b.Navigation("Avatar");

                    b.Navigation("HourlyPays");

                    b.Navigation("Profile");

                    b.Navigation("TimeTrackings");

                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
