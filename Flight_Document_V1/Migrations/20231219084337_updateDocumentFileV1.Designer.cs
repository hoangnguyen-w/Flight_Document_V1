﻿// <auto-generated />
using System;
using Flight_Document_V1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    [DbContext(typeof(FlightManagerContext))]
    [Migration("20231219084337_updateDocumentFileV1")]
    partial class updateDocumentFileV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Flight_Document_V1.Entity.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("StatusTerminate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountID");

                    b.HasIndex("RoleID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            AccountName = "Admin",
                            Email = "Admin@vietjetair.com",
                            Password = "admin123",
                            RoleID = 1,
                            StatusTerminate = true,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"), 1L, 1);

                    b.Property<DateTime>("CreateDateDocument")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Version")
                        .HasColumnType("float");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentTypeID");

                    b.HasIndex("FlightNo");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeID"), 1L, 1);

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentTypeID");

                    b.ToTable("DocumentTypes");

                    b.HasData(
                        new
                        {
                            DocumentTypeID = 1,
                            DocumentTypeName = "Load Summary"
                        },
                        new
                        {
                            DocumentTypeID = 2,
                            DocumentTypeName = "Summary"
                        },
                        new
                        {
                            DocumentTypeID = 3,
                            DocumentTypeName = "Loading Instruction"
                        });
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Flight", b =>
                {
                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Router")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SecondLocationID")
                        .HasColumnType("int");

                    b.HasKey("FlightNo");

                    b.HasIndex("LocationID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"), 1L, 1);

                    b.Property<DateTime>("CreateDateGroup")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentID")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupID");

                    b.HasIndex("DocumentID");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupID = 1,
                            CreateDateGroup = new DateTime(2023, 12, 19, 15, 43, 37, 238, DateTimeKind.Local).AddTicks(5334),
                            Creator = "DEV",
                            GroupName = "GroupAdmin",
                            Note = "Đây là Group đầu tiên tạo ra cho Database"
                        });
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.GroupPermission", b =>
                {
                    b.Property<int>("GroupPermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupPermissionID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("StatusPermission")
                        .HasColumnType("int");

                    b.HasKey("GroupPermissionID");

                    b.HasIndex("AccountID");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupPermissions");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"), 1L, 1);

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Pilot"
                        },
                        new
                        {
                            RoleID = 4,
                            RoleName = "Stewardess"
                        });
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusCapcha")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountID = 1,
                            StatusCapcha = false
                        });
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Account", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Document", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flight_Document_V1.Entity.Flight", "Flight")
                        .WithMany("Documents")
                        .HasForeignKey("FlightNo");

                    b.Navigation("DocumentType");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Flight", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.Location", "Location")
                        .WithMany("Flights")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Group", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.Document", "Document")
                        .WithMany("Groups")
                        .HasForeignKey("DocumentID");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.GroupPermission", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.Account", "Account")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flight_Document_V1.Entity.Group", "Group")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Setting", b =>
                {
                    b.HasOne("Flight_Document_V1.Entity.Account", "Account")
                        .WithMany("Settings")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Account", b =>
                {
                    b.Navigation("GroupPermissions");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Document", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Flight", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Group", b =>
                {
                    b.Navigation("GroupPermissions");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Location", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Flight_Document_V1.Entity.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
