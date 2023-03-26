using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class testowa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grobowce",
                columns: table => new
                {
                    IdGrobowiec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWlasciciel = table.Column<int>(type: "int", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzytkownikIdUzytkownik = table.Column<int>(type: "int", nullable: true),
                    WlascicielIdWlasciciel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grobowce", x => x.IdGrobowiec);
                });

            migrationBuilder.CreateTable(
                name: "Odzwiedzajacy",
                columns: table => new
                {
                    IdOdzwiedzajacy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrobowiecIdGrobowiec = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odzwiedzajacy", x => x.IdOdzwiedzajacy);
                    table.ForeignKey(
                        name: "FK_Odzwiedzajacy_Grobowce_GrobowiecIdGrobowiec",
                        column: x => x.GrobowiecIdGrobowiec,
                        principalTable: "Grobowce",
                        principalColumn: "IdGrobowiec");
                });

            migrationBuilder.CreateTable(
                name: "Zmarli",
                columns: table => new
                {
                    IdZmarly = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSmierci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrobowiecID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zmarli", x => x.IdZmarly);
                    table.ForeignKey(
                        name: "FK_Zmarli_Grobowce_GrobowiecID",
                        column: x => x.GrobowiecID,
                        principalTable: "Grobowce",
                        principalColumn: "IdGrobowiec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    IdUzytkownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdwiedzajacyIdOdzwiedzajacy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.IdUzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Odzwiedzajacy_OdwiedzajacyIdOdzwiedzajacy",
                        column: x => x.OdwiedzajacyIdOdzwiedzajacy,
                        principalTable: "Odzwiedzajacy",
                        principalColumn: "IdOdzwiedzajacy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wlasciciele",
                columns: table => new
                {
                    IdWlasciciel = table.Column<int>(type: "int", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlGrobowcow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wlasciciele", x => x.IdWlasciciel);
                    table.ForeignKey(
                        name: "FK_Wlasciciele_Uzytkownicy_IdWlasciciel",
                        column: x => x.IdWlasciciel,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grobowce_UzytkownikIdUzytkownik",
                table: "Grobowce",
                column: "UzytkownikIdUzytkownik");

            migrationBuilder.CreateIndex(
                name: "IX_Grobowce_WlascicielIdWlasciciel",
                table: "Grobowce",
                column: "WlascicielIdWlasciciel");

            migrationBuilder.CreateIndex(
                name: "IX_Odzwiedzajacy_GrobowiecIdGrobowiec",
                table: "Odzwiedzajacy",
                column: "GrobowiecIdGrobowiec");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_OdwiedzajacyIdOdzwiedzajacy",
                table: "Uzytkownicy",
                column: "OdwiedzajacyIdOdzwiedzajacy");

            migrationBuilder.CreateIndex(
                name: "IX_Zmarli_GrobowiecID",
                table: "Zmarli",
                column: "GrobowiecID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grobowce_Uzytkownicy_UzytkownikIdUzytkownik",
                table: "Grobowce",
                column: "UzytkownikIdUzytkownik",
                principalTable: "Uzytkownicy",
                principalColumn: "IdUzytkownik");

            migrationBuilder.AddForeignKey(
                name: "FK_Grobowce_Wlasciciele_WlascicielIdWlasciciel",
                table: "Grobowce",
                column: "WlascicielIdWlasciciel",
                principalTable: "Wlasciciele",
                principalColumn: "IdWlasciciel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grobowce_Uzytkownicy_UzytkownikIdUzytkownik",
                table: "Grobowce");

            migrationBuilder.DropForeignKey(
                name: "FK_Wlasciciele_Uzytkownicy_IdWlasciciel",
                table: "Wlasciciele");

            migrationBuilder.DropTable(
                name: "Zmarli");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Odzwiedzajacy");

            migrationBuilder.DropTable(
                name: "Grobowce");

            migrationBuilder.DropTable(
                name: "Wlasciciele");
        }
    }
}
