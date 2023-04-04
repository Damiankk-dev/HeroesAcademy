﻿// <auto-generated />
using System;
using HeroesAcademy.Application.Repository.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Reservations.Application.Migrations
{
    [DbContext(typeof(ReservationsDbContext))]
    [Migration("20230403174703_NullableTenantRoom")]
    partial class NullableTenantRoom
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Accessory");
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ReservationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservationStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ReservationEnd = new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6355),
                            ReservationStart = new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6366),
                            RoomId = 1,
                            TenantId = 1
                        },
                        new
                        {
                            Id = 3,
                            ReservationEnd = new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6401),
                            ReservationStart = new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6401),
                            RoomId = 1,
                            TenantId = 1
                        });
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WestRoom",
                            Volume = 10
                        });
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Tenant");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Accessory", b =>
                {
                    b.HasOne("HeroesAcademy.Domain.Models.Reservations.Room", "Room")
                        .WithMany("Accessories")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Reservation", b =>
                {
                    b.HasOne("HeroesAcademy.Domain.Models.Reservations.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeroesAcademy.Domain.Models.Reservations.Tenant", "Tenant")
                        .WithMany("Reservations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Room", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Reservations.Tenant", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}