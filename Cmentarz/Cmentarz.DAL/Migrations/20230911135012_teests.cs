using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class teests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrobowiecOdwiedzajacy_Grobowce_GrobowceIdGrobowiec",
                table: "GrobowiecOdwiedzajacy");

            migrationBuilder.DropForeignKey(
                name: "FK_GrobowiecOdwiedzajacy_Odzwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrobowiecOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy");

            migrationBuilder.RenameTable(
                name: "GrobowiecOdwiedzajacy",
                newName: "GrobowceOdwiedzajacy");

            migrationBuilder.RenameIndex(
                name: "IX_GrobowiecOdwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowceOdwiedzajacy",
                newName: "IX_GrobowceOdwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrobowceOdwiedzajacy",
                table: "GrobowceOdwiedzajacy",
                columns: new[] { "GrobowceIdGrobowiec", "ListaOdwiedzajacyIdOdwiedzajacy" });

            migrationBuilder.AddForeignKey(
                name: "FK_GrobowceOdwiedzajacy_Grobowce_GrobowceIdGrobowiec",
                table: "GrobowceOdwiedzajacy",
                column: "GrobowceIdGrobowiec",
                principalTable: "Grobowce",
                principalColumn: "IdGrobowiec",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrobowceOdwiedzajacy_Odzwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowceOdwiedzajacy",
                column: "ListaOdwiedzajacyIdOdwiedzajacy",
                principalTable: "Odzwiedzajacy",
                principalColumn: "IdOdwiedzajacy",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrobowceOdwiedzajacy_Grobowce_GrobowceIdGrobowiec",
                table: "GrobowceOdwiedzajacy");

            migrationBuilder.DropForeignKey(
                name: "FK_GrobowceOdwiedzajacy_Odzwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowceOdwiedzajacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrobowceOdwiedzajacy",
                table: "GrobowceOdwiedzajacy");

            migrationBuilder.RenameTable(
                name: "GrobowceOdwiedzajacy",
                newName: "GrobowiecOdwiedzajacy");

            migrationBuilder.RenameIndex(
                name: "IX_GrobowceOdwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy",
                newName: "IX_GrobowiecOdwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrobowiecOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy",
                columns: new[] { "GrobowceIdGrobowiec", "ListaOdwiedzajacyIdOdwiedzajacy" });

            migrationBuilder.AddForeignKey(
                name: "FK_GrobowiecOdwiedzajacy_Grobowce_GrobowceIdGrobowiec",
                table: "GrobowiecOdwiedzajacy",
                column: "GrobowceIdGrobowiec",
                principalTable: "Grobowce",
                principalColumn: "IdGrobowiec",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrobowiecOdwiedzajacy_Odzwiedzajacy_ListaOdwiedzajacyIdOdwiedzajacy",
                table: "GrobowiecOdwiedzajacy",
                column: "ListaOdwiedzajacyIdOdwiedzajacy",
                principalTable: "Odzwiedzajacy",
                principalColumn: "IdOdwiedzajacy",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
