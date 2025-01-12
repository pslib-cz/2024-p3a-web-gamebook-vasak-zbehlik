using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class qqwertzu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequierementId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "RequierementId",
                table: "Connections",
                newName: "RequieremenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequieremenId",
                table: "Connections",
                newName: "RequierementId");

            migrationBuilder.AddColumn<int>(
                name: "RequierementId",
                table: "Items",
                type: "INTEGER",
                nullable: true);
        }
    }
}
