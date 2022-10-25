﻿// <auto-generated />
using System;
using HotelDelLuna.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelDelLuna.DataAccess.Migrations
{
    [DbContext(typeof(HotelDelLunaContext))]
    partial class HotelDelLunaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.Account", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LoginFailCount")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Account", "dbo");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.BookHistory", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("FamilyCount")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("RoomNumber");

                    b.HasIndex("UserId");

                    b.ToTable("BookHistories");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.Guest", b =>
                {
                    b.Property<int>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BirthCity")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("IdNumber")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RegisterId");

                    b.HasIndex("IdNumber")
                        .IsUnique()
                        .HasFilter("[IdNumber] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Guest", "dbo");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.Room", b =>
                {
                    b.Property<string>("RoomNumber")
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("MONEY");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("RoomNumber");

                    b.ToTable("Room", "dbo");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.BookHistory", b =>
                {
                    b.HasOne("HotelDelLuna.DataAccess.Models.Room", "Room")
                        .WithMany("ListGuest")
                        .HasForeignKey("RoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelDelLuna.DataAccess.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.Guest", b =>
                {
                    b.HasOne("HotelDelLuna.DataAccess.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("HotelDelLuna.DataAccess.Models.Room", b =>
                {
                    b.Navigation("ListGuest");
                });
#pragma warning restore 612, 618
        }
    }
}
