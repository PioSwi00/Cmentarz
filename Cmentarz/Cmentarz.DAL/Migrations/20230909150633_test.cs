using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odzwiedzajacy",
                columns: table => new
                {
                    IdOdwiedzajacy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odzwiedzajacy", x => x.IdOdwiedzajacy);
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
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    IdUzytkownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdwiedzajacyIdOdwiedzajacy = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.IdUzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Odzwiedzajacy_OdwiedzajacyIdOdwiedzajacy",
                        column: x => x.OdwiedzajacyIdOdwiedzajacy,
                        principalTable: "Odzwiedzajacy",
                        principalColumn: "IdOdwiedzajacy");
                });

            migrationBuilder.CreateTable(
                name: "Grobowce",
                columns: table => new
                {
                    IdGrobowiec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWlasciciel = table.Column<int>(type: "int", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sektor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyZajety = table.Column<bool>(type: "bit", nullable: false),
                    UzytkownikIdUzytkownik = table.Column<int>(type: "int", nullable: true),
                    WlascicielIdWlasciciel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grobowce", x => x.IdGrobowiec);
                    table.ForeignKey(
                        name: "FK_Grobowce_Uzytkownicy_UzytkownikIdUzytkownik",
                        column: x => x.UzytkownikIdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik");
                    table.ForeignKey(
                        name: "FK_Grobowce_Wlasciciele_WlascicielIdWlasciciel",
                        column: x => x.WlascicielIdWlasciciel,
                        principalTable: "Wlasciciele",
                        principalColumn: "IdWlasciciel");
                });

            migrationBuilder.CreateTable(
                name: "GrobowiecOdwiedzajacy",
                columns: table => new
                {
                    GrobowceIdGrobowiec = table.Column<int>(type: "int", nullable: false),
                    ListaOdwiedzajacyIdOdwiedzajacy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrobowiecOdwiedzajacy", x => new { x.GrobowceIdGrobowiec, x.ListaOdwiedzajacyIdOdwiedzajacy });
                    table.ForeignKey(
                        name: "FK_GrobowiecOdwiedzajacy_Grobowce_GrobowceIdGrobowiec",
                        column: x => x.GrobowceIdGrobowiec,
                        principalTable: "Grobowce",
                        principalColumn: "IdGrobowiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrobowiecOdwiedzajacy_Odzwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                        column: x => x.ListaOdwiedzajacyIdOdwiedzajacy,
                        principalTable: "Odzwiedzajacy",
                        principalColumn: "IdOdwiedzajacy",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Grobowce_UzytkownikIdUzytkownik",
                table: "Grobowce",
                column: "UzytkownikIdUzytkownik");

            migrationBuilder.CreateIndex(
                name: "IX_Grobowce_WlascicielIdWlasciciel",
                table: "Grobowce",
                column: "WlascicielIdWlasciciel");

            migrationBuilder.CreateIndex(
                name: "IX_GrobowiecOdwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy",
                column: "ListaOdwiedzajacyIdOdwiedzajacy");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_OdwiedzajacyIdOdwiedzajacy",
                table: "Uzytkownicy",
                column: "OdwiedzajacyIdOdwiedzajacy");

            migrationBuilder.CreateIndex(
                name: "IX_Zmarli_GrobowiecID",
                table: "Zmarli",
                column: "GrobowiecID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrobowiecOdwiedzajacy");

            migrationBuilder.DropTable(
                name: "Zmarli");

            migrationBuilder.DropTable(
                name: "Grobowce");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Wlasciciele");

            migrationBuilder.DropTable(
                name: "Odzwiedzajacy");
        }
    }
}
