using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class el : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "czyZapalilZnicz",
                table: "Odzwiedzajacy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "czyZapalilZnicz",
                table: "Odzwiedzajacy");
        }
    }
}
