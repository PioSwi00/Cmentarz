using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grobowce_Wlasciciele_WlascicielIdWlasciciel",
                table: "Grobowce");

            migrationBuilder.RenameColumn(
                name: "IdWlasciciel",
                table: "Wlasciciele",
                newName: "IdWlascicielID");

            migrationBuilder.RenameColumn(
                name: "WlascicielIdWlasciciel",
                table: "Grobowce",
                newName: "WlascicielIdWlascicielID");

            migrationBuilder.RenameIndex(
                name: "IX_Grobowce_WlascicielIdWlasciciel",
                table: "Grobowce",
                newName: "IX_Grobowce_WlascicielIdWlascicielID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grobowce_Wlasciciele_WlascicielIdWlascicielID",
                table: "Grobowce",
                column: "WlascicielIdWlascicielID",
                principalTable: "Wlasciciele",
                principalColumn: "IdWlascicielID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grobowce_Wlasciciele_WlascicielIdWlascicielID",
                table: "Grobowce");

            migrationBuilder.RenameColumn(
                name: "IdWlascicielID",
                table: "Wlasciciele",
                newName: "IdWlasciciel");

            migrationBuilder.RenameColumn(
                name: "WlascicielIdWlascicielID",
                table: "Grobowce",
                newName: "WlascicielIdWlasciciel");

            migrationBuilder.RenameIndex(
                name: "IX_Grobowce_WlascicielIdWlascicielID",
                table: "Grobowce",
                newName: "IX_Grobowce_WlascicielIdWlasciciel");

            migrationBuilder.AddForeignKey(
                name: "FK_Grobowce_Wlasciciele_WlascicielIdWlasciciel",
                table: "Grobowce",
                column: "WlascicielIdWlasciciel",
                principalTable: "Wlasciciele",
                principalColumn: "IdWlasciciel");
        }
    }
}
