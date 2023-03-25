using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.Migrations
{
    /// <inheritdoc />
    public partial class Pierwsza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odzwiedzajacy",
                columns: table => new
                {
                    IdOdzwiedzajacy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odzwiedzajacy", x => x.IdOdzwiedzajacy);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    IdUzytkownik = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.IdUzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Odzwiedzajacy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Odzwiedzajacy",
                        principalColumn: "IdOdzwiedzajacy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wlasciciele",
                columns: table => new
                {
                    IdWlasciciel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlGrobowcow = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wlasciciele", x => x.IdWlasciciel);
                    table.ForeignKey(
                        name: "FK_Wlasciciele_Uzytkownicy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grobowce",
                columns: table => new
                {
                    IdGrobowiec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWlasciciel = table.Column<int>(type: "int", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grobowce", x => x.IdGrobowiec);
                    table.ForeignKey(
                        name: "FK_Grobowce_Wlasciciele_IdWlasciciel",
                        column: x => x.IdWlasciciel,
                        principalTable: "Wlasciciele",
                        principalColumn: "IdWlasciciel",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "OdwiedzajacyGrobowce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOdwiedzajacy = table.Column<int>(type: "int", nullable: false),
                    IdGrobowiec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdwiedzajacyGrobowce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdwiedzajacyGrobowce_Grobowce_IdGrobowiec",
                        column: x => x.IdGrobowiec,
                        principalTable: "Grobowce",
                        principalColumn: "IdGrobowiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdwiedzajacyGrobowce_Odzwiedzajacy_IdOdwiedzajacy",
                        column: x => x.IdOdwiedzajacy,
                        principalTable: "Odzwiedzajacy",
                        principalColumn: "IdOdzwiedzajacy",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zmarli",
                columns: table => new
                {
                    IdZmarly = table.Column<int>(type: "int", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSmierci = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zmarli", x => x.IdZmarly);
                    table.ForeignKey(
                        name: "FK_Zmarli_Grobowce_IdZmarly",
                        column: x => x.IdZmarly,
                        principalTable: "Grobowce",
                        principalColumn: "IdGrobowiec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grobowce_IdWlasciciel",
                table: "Grobowce",
                column: "IdWlasciciel");

            migrationBuilder.CreateIndex(
                name: "IX_OdwiedzajacyGrobowce_IdGrobowiec",
                table: "OdwiedzajacyGrobowce",
                column: "IdGrobowiec");

            migrationBuilder.CreateIndex(
                name: "IX_OdwiedzajacyGrobowce_IdOdwiedzajacy",
                table: "OdwiedzajacyGrobowce",
                column: "IdOdwiedzajacy");

            migrationBuilder.CreateIndex(
                name: "IX_Wlasciciele_IdUzytkownik",
                table: "Wlasciciele",
                column: "IdUzytkownik",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "OdwiedzajacyGrobowce");

            migrationBuilder.DropTable(
                name: "Zmarli");

            migrationBuilder.DropTable(
                name: "Grobowce");

            migrationBuilder.DropTable(
                name: "Wlasciciele");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Odzwiedzajacy");
        }
    }
}
