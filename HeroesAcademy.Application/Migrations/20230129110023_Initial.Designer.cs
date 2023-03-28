﻿// <auto-generated />
using HeroesAcademy.Application.Repository.Heroes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeroesAcademy.Application.Migrations
{
    [DbContext(typeof(HeroesAcademyDbContext))]
    [Migration("20230129110023_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HeroesAcademy.Domain.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("SecretIdentity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Strength")
                        .HasColumnType("float");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Man with iron suit",
                            IsActive = false,
                            LogoUrl = "assets/logos/iron-man.png",
                            Name = "Iron Man",
                            Salary = 0.99m,
                            SecretIdentity = "Tony Stark",
                            Strength = 4.2000000000000002,
                            Team = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Norse god of thunder",
                            IsActive = false,
                            LogoUrl = "assets/logos/thor.png",
                            Name = "Thor",
                            Salary = 10.99m,
                            SecretIdentity = "Thor Odinson",
                            Strength = 4.5,
                            Team = "Avengers"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Man of steel",
                            IsActive = false,
                            LogoUrl = "assets/logos/superman.png",
                            Name = "Superman",
                            Salary = 3500m,
                            SecretIdentity = "Clark Kent",
                            Strength = 5.0,
                            Team = "Justice League"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
