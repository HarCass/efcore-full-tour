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
    [Migration("20240827084920_AddingConfigAndRelationships")]
    partial class AddingConfigAndRelationships
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

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Oliver Glasner"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Mikel Arteta"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Erik ten Hag"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Pep Guardiola"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Enzo Maresca"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Arne Slot"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Ange Postecoglou"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Unai Emery"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Eddie Howe"
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Steve Cooper"
                        });
                });

            modelBuilder.Entity("EFCore.Domain.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            Name = "Premiere League"
                        });
                });

            modelBuilder.Entity("EFCore.Domain.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("EFCore.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CoachId")
                        .IsUnique();

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoachId = 1,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Crystal Palace"
                        },
                        new
                        {
                            Id = 2,
                            CoachId = 2,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Arsenal"
                        },
                        new
                        {
                            Id = 3,
                            CoachId = 3,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Manchester United"
                        },
                        new
                        {
                            Id = 4,
                            CoachId = 4,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Manchester City"
                        },
                        new
                        {
                            Id = 5,
                            CoachId = 5,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Chelsea"
                        },
                        new
                        {
                            Id = 6,
                            CoachId = 6,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Liverpool"
                        },
                        new
                        {
                            Id = 7,
                            CoachId = 7,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Tottenham"
                        },
                        new
                        {
                            Id = 8,
                            CoachId = 8,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Aston Villa"
                        },
                        new
                        {
                            Id = 9,
                            CoachId = 9,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Newcastle United"
                        },
                        new
                        {
                            Id = 10,
                            CoachId = 10,
                            CreatedDate = new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local),
                            LeagueId = 1,
                            Name = "Leicester City"
                        });
                });

            modelBuilder.Entity("EFCore.Domain.Match", b =>
                {
                    b.HasOne("EFCore.Domain.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Domain.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("EFCore.Domain.Team", b =>
                {
                    b.HasOne("EFCore.Domain.Coach", "Coach")
                        .WithOne("Team")
                        .HasForeignKey("EFCore.Domain.Team", "CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Domain.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("League");
                });

            modelBuilder.Entity("EFCore.Domain.Coach", b =>
                {
                    b.Navigation("Team");
                });

            modelBuilder.Entity("EFCore.Domain.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EFCore.Domain.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("HomeMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
