using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreEntitiesAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Teams",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Coaches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver Glasner" },
                    { 2, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikel Arteta" },
                    { 3, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7395), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erik ten Hag" },
                    { 4, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pep Guardiola" },
                    { 5, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7398), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enzo Maresca" },
                    { 6, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7400), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arne Slot" },
                    { 7, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7402), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ange Postecoglou" },
                    { 8, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7404), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unai Emery" }
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premiere League" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId", "ModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7198), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId", "ModifiedDate" },
                values: new object[] { 2, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7251), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId", "ModifiedDate" },
                values: new object[] { 3, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7254), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachId", "CreatedDate", "LeagueId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7257), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manchester City" },
                    { 5, 5, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7259), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chelsea" },
                    { 6, 6, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7261), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liverpool" },
                    { 7, 7, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7263), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tottenham" },
                    { 8, 8, new DateTime(2024, 8, 21, 9, 52, 48, 44, DateTimeKind.Local).AddTicks(7265), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aston Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Coaches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 10, 13, 43, 766, DateTimeKind.Local).AddTicks(1367));
        }
    }
}
