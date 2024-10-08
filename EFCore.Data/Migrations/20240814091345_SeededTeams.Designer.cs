﻿// <auto-generated />
using System;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Data.Migrations
{
    [DbContext(typeof(FootballLeagueDbContext))]
    [Migration("20240814091345_SeededTeams")]
    partial class SeededTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EFCore.Domain.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("EFCore.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1285),
                            Name = "Crystal Palace"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1357),
                            Name = "Arsenal"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1367),
                            Name = "Manchester United"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
