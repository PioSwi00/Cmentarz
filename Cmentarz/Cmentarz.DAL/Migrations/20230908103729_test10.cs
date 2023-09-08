using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wlasciciele_Uzytkownicy_IdWlasciciel",
                table: "Wlasciciele");

            migrationBuilder.AlterColumn<int>(
                name: "IdWlasciciel",
                table: "Wlasciciele",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdWlasciciel",
                table: "Wlasciciele",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Wlasciciele_Uzytkownicy_IdWlasciciel",
                table: "Wlasciciele",
                column: "IdWlasciciel",
                principalTable: "Uzytkownicy",
                principalColumn: "IdUzytkownik",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
